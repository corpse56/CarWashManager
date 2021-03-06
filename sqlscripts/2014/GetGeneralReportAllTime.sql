USE [CWM]
GO
/****** Object:  UserDefinedFunction [dbo].[GetGeneralReportAllTime]    Script Date: 11/16/2014 16:29:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


ALTER FUNCTION [dbo].[GetGeneralReportAllTime] ()
RETURNS @ret table
(
dt datetime,cost int
)
WITH EXECUTE AS CALLER
AS
BEGIN
with 
 gen as(
select A.JOBDATE dt, case when A.PLUS_50 = 1 then D.COST else D.COST+D.COST/2 end cost
from CWM..PACKAGE D
left join CWM..JOB A on D.IDJOB = A.ID
where D.DELETED is null
)
insert into @ret
select * from gen
return
END;
