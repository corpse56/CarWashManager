USE [CWM]
GO

/****** Object:  UserDefinedFunction [dbo].[GetTeamReportByDate]    Script Date: 08/12/2015 13:19:03 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO





ALTER FUNCTION [dbo].[GetTeamReportByDate] (@start datetime,@end datetime)
RETURNS @ret table
(
ide int,nm nvarchar(300),serv nvarchar(300),cls nvarchar(300),dt datetime,cost int,cnt int
)
WITH EXECUTE AS CALLER
AS
BEGIN
with 
 gen as(
select B.ID ide,(case when B.DELETED = 1 then B.ENAME+' (уволен)' else B.ENAME end) en,C.PNAME pn,cast(A.IDCLASS as varchar) idc,
A.JOBDATE dt, D.COST cst,1 cnt
from CWM..PACKAGE D
left join CWM..JOB A on D.IDJOB = A.ID 
left join CWM..EMPLOYEE B on A.IDEMP = B.ID
left join CWM..PRICELIST C on C.ID = D.IDPRICE
where D.DELETED is null
and cast(cast(A.JOBDATE as varchar(11)) as DATETIME) between @start and @end
--union all
--select B.ID ide,(case when B.DELETED = 1 then B.ENAME+' (уволен)' else B.ENAME end) en,C.ASNAME pn,cast(A.IDCLASS as varchar) idc,
--A.JOBDATE dt, D.COST cst,1 cnt
--from CWM..PACKAGEADDSERV D
--left join CWM..JOB A on D.IDJOB = A.ID 
--left join CWM..EMPLOYEE B on A.IDEMP = B.ID
--left join CWM..ADDITIONALSERVICE C on C.ID = D.IDADDSERV
--where D.DELETED is null
--and cast(cast(A.JOBDATE as varchar(11)) as DATETIME) between @start and @end

--and A.IDEMP = @idemp
)

insert into @ret
select * from gen
order by dt

return
END;



GO


