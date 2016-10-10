USE [CWM]
GO

/****** Object:  UserDefinedFunction [dbo].[GetSearch]    Script Date: 08/12/2015 13:18:14 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



ALTER FUNCTION [dbo].[GetSearch] ()
RETURNS @ret table
(
en nvarchar(400),jd datetime, pn nvarchar(400), cst int, ln int, idc int, car nvarchar(400), plate nvarchar(400)
)
WITH EXECUTE AS CALLER
AS
BEGIN
with gen as (

select 
(case when B.DELETED = 1 then B.ENAME+' (уволен)' else B.ENAME end) en,A.JOBDATE jd, D.PNAME pn,
  C.COST cst,A.LINE ln,A.IDCLASS idc,E.CNAME car,A.NPLATE plate
from CWM..JOB A
left join CWM..EMPLOYEE B on A.IDEMP = B.ID
left join CWM..PACKAGE C on A.ID = C.IDJOB
left join CWM..PRICELIST D on C.IDPRICE = D.ID
left join CWM..CAR E on E.ID = A.IDCAR
where C.DELETED is null
)

insert into @ret
select * from gen
return
END;

GO


