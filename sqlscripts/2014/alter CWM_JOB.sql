alter table CWM..JOB add  IDADDPACKAGE int null
alter table CWM..JOB add PLUS_50 bit 
alter table CWM..PACKAGEADDSERV add DELETED bit null
go
update CWM..JOB set PLUS_50 = 0