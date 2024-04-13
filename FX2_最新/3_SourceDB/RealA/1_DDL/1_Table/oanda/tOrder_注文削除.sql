USE OANDA_DemoB
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO

CREATE TABLE [oanda].[tOrder_注文削除](
	[口座No]			int				NOT NULL,
	[日時]				Datetime		NOT NULL,
	[注文削除対象id]	[BigInt]		NOT NULL,
	[id]				[BigInt]		NOT NULL,
	[instrument]		[VarChar](50)	NOT NULL,
	[units]				[Int]			NULL,
	[side]				[VarChar](50)	NULL,
	[type]				[VarChar](50)	NULL,
	[time]				Datetime		NOT NULL,
	[price]				[Float]			NULL,
	[takeProfit]		[Float]			NULL,
	[stopLoss]			[Float]			NULL,
	[expiry]			[VarChar](50)	NULL,
	[upperBound]		[Float]			NULL,
	[lowerBound]		[Float]			NULL,
	[trailingStop]		[Int]			NULL,
	[登録日時]			Datetime		NULL,
	[更新日時]			Datetime		NULL,
CONSTRAINT [PK_tOrder_注文削除] PRIMARY KEY CLUSTERED 
(
	[口座No]			ASC,
	[日時]				ASC,
	[注文削除対象id]	ASC,
	[id]				ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, DATA_COMPRESSION = PAGE) ON [PRIMARY]
) ON [PRIMARY]
GO

SET ANSI_PADDING OFF
GO
