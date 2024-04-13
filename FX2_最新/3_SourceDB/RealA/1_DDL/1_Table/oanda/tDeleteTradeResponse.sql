USE OANDA_DemoB
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO

CREATE TABLE [oanda].[tDeleteTradeResponse](
	[口座No]		int			NOT NULL,
	[id]			BigInt		NOT NULL,
	[price]			Float		NULL,
	[instrument]	varchar(50) NULL,
	[profit]		Float		NULL,
	[side]			VarChar(50) NULL,
	[time]			DateTime	NULL,
	[登録日時]		Datetime	NULL,
	[更新日時]		Datetime	NULL,
CONSTRAINT [PK_tDeleteTradeResponse] PRIMARY KEY CLUSTERED 
(
	[口座No]	ASC,
	[id]		ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, DATA_COMPRESSION = PAGE) ON [PRIMARY]
) ON [PRIMARY]
GO

SET ANSI_PADDING OFF
GO
