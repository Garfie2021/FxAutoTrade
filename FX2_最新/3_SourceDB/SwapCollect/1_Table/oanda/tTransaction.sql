USE SwapCollect
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO

CREATE TABLE [oanda].[tTransaction](
	[口座No]		int			NOT NULL,
	[accountId]		[Int]		NOT NULL,
	[id]			[BigInt]	NOT NULL,
	[time] [DateTime]			NULL,
	[type] [VarChar](50) NULL,
	[instrument] [VarChar](50) NULL,
	[side] [VarChar](50) NULL,
	[units] [Int] NULL,
	[price] [Float] NULL,
	[lowerBound] [Float] NULL,
	[upperBound] [Float] NULL,
	[takeProfitPrice] [Float] NULL,
	[stopLossPrice] [Float] NULL,
	[trailingStopLossDistance] [Float] NULL,
	[pl] [Float] NULL,
	[interest] [Float] NULL,
	[accountBalance] [Float] NULL,
	[tradeId] [BigInt] NULL,
	[orderId] [BigInt] NULL,
	[tradeOpened_id] [BigInt] NULL,
	[tradeOpened_units] [Int] NULL,
	[tradeOpened_side] [VarChar](50) NULL,
	[tradeOpened_instrument] [VarChar](50) NULL,
	[tradeOpened_time] [VarChar](50) NULL,
	[tradeOpened_price] [Float] NULL,
	[tradeOpened_takeProfit] [Float] NULL,
	[tradeOpened_stopLoss] [Float] NULL,
	[tradeOpened_trailingStop] [Int] NULL,
	[tradeOpened_trailingAmount] [Float] NULL,
	[tradeReduced_id] [BigInt] NULL,
	[tradeReduced_units] [Int] NULL,
	[tradeReduced_side] [VarChar](50) NULL,
	[tradeReduced_instrument] [VarChar](50) NULL,
	[tradeReduced_time] [VarChar](50) NULL,
	[tradeReduced_price] [Float] NULL,
	[tradeReduced_takeProfit] [Float] NULL,
	[tradeReduced_stopLoss] [Float] NULL,
	[tradeReduced_trailingStop] [Int] NULL,
	[tradeReduced_trailingAmount] [Float] NULL,
	[reason] [VarChar](50) NULL,
	[expiry] [VarChar](50) NULL,
	[登録日時]	Datetime	NULL,
	[更新日時]	datetime	NULL,
CONSTRAINT [PK_oanda_tTransaction] PRIMARY KEY CLUSTERED 
(
	[口座No]	ASC,
	[accountId]	ASC,
	[id]		ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, DATA_COMPRESSION = PAGE) ON [PRIMARY]
) ON [PRIMARY]
GO

SET ANSI_PADDING OFF
GO
