USE OANDA_DemoB
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO

CREATE TABLE [oanda].[tAccount](
	[口座No]			int				NOT NULL,
	[日時]				[DateTime]		NOT NULL,
	[accountId]			[Int]			NULL,
	[accountName]		[VarChar](50)	NULL,
	[accountCurrency]	[VarChar](5)	NULL,
	[marginRate]		float			NULL,
	[balance]			float			NULL,
	[unrealizedPl]		float			NULL,
	[realizedPl]		float			NULL,
	[marginUsed]		float			NULL,
	[marginAvail]		float			NULL,
	[openTrades]		int				NULL,
	[openOrders]		int				NULL,
	[登録日時]			[DateTime]		NULL,
	[更新日時]			[DateTime]		NULL,
CONSTRAINT [PK_tAccount2] PRIMARY KEY CLUSTERED 
(
	[口座No]	ASC,
	[日時]		ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, DATA_COMPRESSION = PAGE) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
