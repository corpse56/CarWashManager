USE [CWM]
GO
/****** Object:  UserDefinedFunction [dbo].[GetGeneralReportByDate]    Script Date: 11/16/2014 16:30:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


ALTER FUNCTION [dbo].[GetGeneralReportByDate] (@start datetime,@end datetime)
RETURNS @ret table
(
dt datetime,cost int
)
WITH EXECUTE AS CALLER
AS
BEGIN
with 
 gen as(
select A.JOBDATE dt,case when A.PLUS_50 = 1 then D.COST else D.COST+D.COST/2 end cost
from CWM..PACKAGE D
left join CWM..JOB A on D.IDJOB = A.ID
where D.DELETED is null and cast(cast(A.JOBDATE as varchar(11)) as DATETIME) between @start and @end
)
insert into @ret
select * from gen
return
END;
