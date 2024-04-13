USE OANDA_DemoB
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO

CREATE TABLE [oanda].[tOrderResponse](
	[口座No]			int				NOT NULL,
	[通貨ペアNo]		tinyint			NOT NULL,
	[time]				DateTime		NOT NULL,
	[instrument]		VarChar(50)		NULL,
	[BS開始]			Bit				NULL,
	[price]				Float			NULL,
	[Order_id]			BigInt			NULL,
	[Order_instrument]	VarChar(50)		NULL,
	[Order_units]		Int				NULL,
	[Order_side]		VarChar(50)		NULL,
	[Order_type]		VarChar(50)		NULL,
	[Order_time]		DateTime		NULL,
	[Order_price]		Float		NULL,
	[Order_takeProfit]	Float		NULL,
	[Order_stopLoss]	Float		NULL,
	[Order_expiry]		VarChar		NULL,
	[Order_upperBound]	Float		NULL,
	[Order_lowerBound]	Float		NULL,
	[Order_trailingStop]	Float		NULL,
	[TradeData_id]			BigInt		NOT NULL,
	[TradeData_units]		Int			NULL,
	[TradeData_side]		VarChar(50)		NULL,
	[TradeData_instrument]	VarChar(50)		NULL,
	[TradeData_time]		DateTime		NULL,
	[TradeData_price]		Float		NULL,
	[TradeData_takeProfit]	Float		NULL,
	[TradeData_stopLoss]		Float		NULL,
	[TradeData_trailingStop]	Int			NULL,
	[TradeData_trailingAmount]	Float		NULL,
	[妥当性]				varchar(1000)	NULL,
	[登録日時]				datetime		NULL,
	[更新日時]				datetime		NULL,
CONSTRAINT [PK_tOrderResponse] PRIMARY KEY CLUSTERED 
(
	[口座No]		ASC,
	[通貨ペアNo]	ASC,
	[TradeData_id]	ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, DATA_COMPRESSION = PAGE) ON [PRIMARY]
) ON [PRIMARY]
GO

SET ANSI_PADDING OFF
GO
