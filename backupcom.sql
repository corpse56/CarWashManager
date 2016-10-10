exec expressmaint
   @database      = 'TM', 
   @optype        = 'DB',
   @backupfldr    = 'c:\backup',
   @reportfldr    = 'c:\backup',
   @verify        = 1,
   @dbretainunit  = 'days',
   @dbretainval   = 7,
   @rptretainunit = 'weeks',
   @rptretainval  = 1,
   @report        = 1