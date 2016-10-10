USE [CWM]
GO

/****** Object:  UserDefinedFunction [dbo].[EditJob]    Script Date: 08/12/2015 13:15:58 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


ALTER FUNCTION [dbo].[EditJob] (@date datetime)
RETURNS @ret table
(
id int,en nvarchar(400),pl nvarchar(400),tim nvarchar(400), serv nvarchar(1000),car nvarchar(1000), cost int,
id2 int,en2 nvarchar(400),pl2 nvarchar(400),tim2 nvarchar(400), serv2 nvarchar(1000),car2 nvarchar(1000), cost2 int
)
WITH EXECUTE AS CALLER
AS
BEGIN
with FC as(
select J.ID ID,E.ENAME EMP,J.NPLATE PLATE,CONVERT(VARCHAR(5), J.JOBDATE, 114) as T,J.ID PACK,
PR.PNAME PNAME,
C.CNAME CAR,J.TOTALCOST COST
 from CWM..JOB J
left join CWM..EMPLOYEE E  on J.IDEMP = E.ID
left join CWM..PACKAGE P on J.ID = P.IDJOB
left join CWM..PRICELIST PR on P.IDPRICE = PR.ID
left join CWM..CAR C on C.ID = J.IDCAR
where J.LINE = 1 and cast(cast(J.JOBDATE as nvarchar(11)) as datetime) = cast(cast(@date as nvarchar(11)) as datetime)
), FG as (
select distinct ID,EMP,PLATE,T,
 (select PNAME+', ' as 'data()' from FC t2 where t2.PACK=t1.PACK for xml path('') ) P,
CAR,COST 
from FC t1
group by ID,PNAME,EMP,PLATE,T,CAR,COST,PACK
),
FGG as (
select ID IDJ,row_number() over (order by T) ID, EMP,PLATE,T,P,CAR,COST from FG
),
FC2 as(
select J.ID ID2,E.ENAME EMP2,J.NPLATE PLATE2,CONVERT(VARCHAR(5), J.JOBDATE, 114) as T2,J.ID PACK2,
PR.PNAME PNAME2,
C.CNAME CAR2,J.TOTALCOST COST2
 from CWM..JOB J
left join CWM..EMPLOYEE E  on J.IDEMP = E.ID
left join CWM..PACKAGE P on J.ID = P.IDJOB
left join CWM..PRICELIST PR on P.IDPRICE = PR.ID
left join CWM..CAR C on C.ID = J.IDCAR
where J.LINE = 2 and cast(cast(J.JOBDATE as nvarchar(11)) as datetime) = cast(cast(@date as nvarchar(11)) as datetime)
),
FG2 as (
select distinct ID2,EMP2,PLATE2,T2,
 (select PNAME2+', ' as 'data()' from FC2 t2 where t2.PACK2=t1.PACK2 for xml path('') ) P2,
CAR2,COST2 
from FC2 t1
group by ID2,PNAME2,EMP2,PLATE2,T2,CAR2,COST2,PACK2,ID2
),
FGG2 as (
select ID2 IDJ2,row_number() over (order by T2) ID2, EMP2,PLATE2,T2,P2,CAR2,COST2 from FG2
)
insert into @ret
select IDJ,ISNULL(FGG.EMP,'') EMP,FGG.PLATE,FGG.T, substring(FGG.P,0,len(FGG.P)) PS,FGG.CAR,FGG.COST,
IDJ2,FGG2.EMP2,FGG2.PLATE2,FGG2.T2, substring(FGG2.P2,0,len(FGG2.P2)) PS2,FGG2.CAR2,FGG2.COST2
from FGG
full join FGG2 on FGG.ID = FGG2.ID2

return
END;

--select * from CWM..EditJob('20120524');
GO


