USE [DemoA_FX]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO

CREATE TABLE [hltc].[T_データCnt_Monthly](
	[日時] [date] NOT NULL,
	[通貨ペアNo] [tinyint] NOT NULL,
	[件数_Weekly] [int] NULL,
	[件数_Monthly] [int] NULL,
	[StartDate] [datetime] NULL,
	[EndDate] [datetime] NULL,
CONSTRAINT [PK_T_データCnt_Monthly] PRIMARY KEY CLUSTERED 
(
	[日時] ASC,
	[通貨ペアNo] ASC	
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, DATA_COMPRESSION = PAGE) ON [PRIMARY]
) ON [PRIMARY]
GO

SET ANSI_PADDING OFF
GO


