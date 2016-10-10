USE [CWM]
GO

/****** Object:  UserDefinedFunction [dbo].[GetFullReportByDate]    Script Date: 08/12/2015 13:17:32 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO






ALTER FUNCTION [dbo].[GetFullReportByDate] (@start datetime,@end datetime)
RETURNS @ret table
(
EMP nvarchar(1000),PLATE nvarchar(1000),T  nvarchar(1000), PS  nvarchar(1000), CAR  nvarchar(1000), COST  nvarchar(1000),
EMP2 nvarchar(1000),PLATE2 nvarchar(1000),T2  nvarchar(1000), PS2 nvarchar(1000),CAR2 nvarchar(1000),COST2 nvarchar(1000))
WITH EXECUTE AS CALLER
AS
BEGIN
with FC as(
select J.ID ID,E.ENAME EMP,J.NPLATE PLATE,CONVERT(VARCHAR(8), J.JOBDATE, 4) +' '+CONVERT(VARCHAR(5), J.JOBDATE, 114) as T,J.ID PACK,
PR.PNAME PNAME,
C.CNAME CAR,J.TOTALCOST COST
 from CWM..JOB J
left join CWM..EMPLOYEE E  on J.IDEMP = E.ID
left join CWM..PACKAGE P on J.ID = P.IDJOB
left join CWM..PRICELIST PR on P.IDPRICE = PR.ID
left join CWM..CAR C on C.ID = J.IDCAR
where P.DELETED is null and J.LINE = 1 and cast(cast(J.JOBDATE as nvarchar(11)) as datetime) between @start and @end
), FG as (
select distinct EMP,PLATE,T,
 (select PNAME+', ' as 'data()' from FC t2 where t2.PACK=t1.PACK for xml path('') ) P,
CAR,COST 
from FC t1
group by PNAME,EMP,PLATE,T,CAR,COST,PACK
),
FGG as (
select row_number() over (order by T) ID, EMP,PLATE,T,P,CAR,COST from FG
),
FC2 as(
select J.ID ID2,E.ENAME EMP2,J.NPLATE PLATE2,CONVERT(VARCHAR(8), J.JOBDATE, 4) +' '+CONVERT(VARCHAR(5), J.JOBDATE, 114) as T2,J.ID PACK2,
PR.PNAME PNAME2,
C.CNAME CAR2,J.TOTALCOST COST2
 from CWM..JOB J
left join CWM..EMPLOYEE E  on J.IDEMP = E.ID
left join CWM..PACKAGE P on J.ID = P.IDJOB
left join CWM..PRICELIST PR on P.IDPRICE = PR.ID
left join CWM..CAR C on C.ID = J.IDCAR
where P.DELETED is null and J.LINE = 2 and cast(cast(J.JOBDATE as nvarchar(11)) as datetime) between @start and @end
),
FG2 as (
select distinct ID2,EMP2,PLATE2,T2,
 (select PNAME2+', ' as 'data()' from FC2 t2 where t2.PACK2=t1.PACK2 for xml path('') ) P2,
CAR2,COST2 
from FC2 t1
group by PNAME2,EMP2,PLATE2,T2,CAR2,COST2,PACK2,ID2
),
FGG2 as (
select row_number() over (order by T2) ID2, EMP2,PLATE2,T2,P2,CAR2,COST2 from FG2
),
final  as (
select ISNULL(FGG.EMP,'') EMP,FGG.PLATE,FGG.T, substring(FGG.P,0,len(FGG.P)) PS,FGG.CAR,FGG.COST,
FGG2.EMP2,FGG2.PLATE2,FGG2.T2, substring(FGG2.P2,0,len(FGG2.P2)) PS2,FGG2.CAR2,FGG2.COST2
from FGG
full join FGG2 on FGG.ID = FGG2.ID2
)

insert into @ret
select * from final

return
END;




GO


