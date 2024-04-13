USE OANDA_DemoB
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO

CREATE TABLE [oanda].[tTrade](
	[口座No]			int				NOT NULL,
	[id]				[BigInt] NOT NULL,
	[units]				[Int] NULL,
	[side]				[VarChar](50) NULL,
	[instrument]		[VarChar](50) NULL,
	[time]				Datetime NULL,
	[price]				[Float] NULL,
	[takeProfit]		[Float] NULL,
	[stopLoss]			[Float] NULL,
	[trailingStop]		[Int] NULL,
	[trailingAmount]	[Float] NULL,
	[登録日時]			[datetime]		NULL,
	[更新日時]			[datetime]		NULL,
CONSTRAINT [PK_tTrade] PRIMARY KEY CLUSTERED 
(
	[口座No]	ASC,
	[id]		ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, DATA_COMPRESSION = PAGE) ON [PRIMARY]
) ON [PRIMARY]
GO

SET ANSI_PADDING OFF
GO
