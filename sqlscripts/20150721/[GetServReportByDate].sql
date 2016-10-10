USE [CWM]
GO

/****** Object:  UserDefinedFunction [dbo].[GetServReportByDate]    Script Date: 08/12/2015 13:18:33 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



ALTER FUNCTION [dbo].[GetServReportByDate] (@start datetime,@end datetime)
RETURNS @ret table
(
pn nvarchar(400),en nvarchar(400), cnt int
)
WITH EXECUTE AS CALLER
AS
BEGIN
with gen as (
select A.PNAME pn,(case when B.DELETED = 1 then B.ENAME+' (уволен)' else B.ENAME end) en,count(B.ENAME) cnt
from CWM..PRICELIST A
left join CWM..PACKAGE D on D.IDPRICE = A.ID
left join CWM..JOB C on C.ID = D.IDJOB 
left join CWM..EMPLOYEE B on B.ID = C.IDEMP
where B.ENAME is not null and D.DELETED is null
and cast(cast(C.JOBDATE as varchar(11)) as DATETIME) between @start and @end
group by A.PNAME,B.ENAME,B.DELETED
)

insert into @ret
select * from gen
order by pn,en
return
END;

GO


