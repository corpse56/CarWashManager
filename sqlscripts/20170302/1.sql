USE [CWM]
GO

/****** Object:  Table [dbo].[REMOVEDJOB]    Script Date: 03/02/2017 16:47:22 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[REMOVEDJOB](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[IDEMP] [int] NOT NULL,
	[IDPACKAGE] [int] NOT NULL,
	[JOBDATE] [datetime] NOT NULL,
	[TOTALCOST] [int] NOT NULL,
	[LINE] [int] NOT NULL,
	[IDCLASS] [int] NOT NULL,
	[NPLATE] [nvarchar](50) NOT NULL,
	[IDCAR] [int] NOT NULL,
	[IDORIGINALJOB] [int] NOT NULL,
	[DATEDELETED] [datetime] NOT NULL,
 CONSTRAINT [PK_REMOVEDJOB] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO


