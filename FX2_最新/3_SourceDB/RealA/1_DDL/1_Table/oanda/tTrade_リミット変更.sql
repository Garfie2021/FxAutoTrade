USE OANDA_DemoB
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO

CREATE TABLE [oanda].[tTrade_リミット変更](
	[口座No]				int			NOT NULL,
	[日時]					Datetime	NOT NULL,
	[リミット変更対象id]	BigInt		NOT NULL,
	[id]					BigInt		NOT NULL,
	[instrument]			VarChar(10) NOT NULL,
	[units]					Int			NULL,
	[side]					VarChar(10) NULL,
	[time]					Datetime	NOT NULL,
	[price]					Float NULL,
	[takeProfit]			Float NULL,
	[stopLoss]				Float NULL,
	[trailingStop]			Int NULL,
	[trailingAmount]		Float NULL,
	[登録日時]				datetime		NULL,
	[更新日時]				datetime		NULL,
CONSTRAINT [PK_tTrade_リミット変更] PRIMARY KEY CLUSTERED 
(
	[口座No]				ASC,
	[日時]					ASC,
	[リミット変更対象id]	ASC,
	[id]					ASC,
	[instrument]			ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, DATA_COMPRESSION = PAGE) ON [PRIMARY]
) ON [PRIMARY]
GO

SET ANSI_PADDING OFF
GO
