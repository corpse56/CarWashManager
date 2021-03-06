USE [CWM]
GO
/****** Object:  UserDefinedFunction [dbo].[GetTeamReportAllTimeShort]    Script Date: 05/25/2012 13:46:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER FUNCTION [dbo].[GetTeamReportAllTimeShort] ()
RETURNS @ret table
(
ide int,nm nvarchar(400),cost int,cnt int
)
WITH EXECUTE AS CALLER
AS
BEGIN
with 
 gen as(
select B.ID ide,(case when B.DELETED = 1 then B.ENAME+' (уволен)' else B.ENAME end) dt,sum(D.COST) cst,count(A.ID) dts
from CWM..PACKAGE D
left join CWM..JOB A on D.IDJOB = A.ID
left join CWM..EMPLOYEE B on A.IDEMP = B.ID
where D.DELETED is null
group by  B.ID,B.ENAME,B.DELETED
)
insert into @ret
select ide,dt,sum(cst),sum(dts) cnt  from gen
group by dt,ide
return
END;