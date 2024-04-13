USE DemoA_FX
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO

CREATE TABLE [fxcm].[tClosedTrades](
	[TradeID] [varchar](100) NOT NULL,
	[AccountID] [varchar](100) NULL,
	[AccountName] [varchar](100) NULL,
	[OfferID] [varchar](100) NULL,
	[Instrument] [varchar](100) NULL,
	[Lot] [int] NULL,
	[AmountK] [float] NULL,
	[BS] [varchar](100) NULL,
	[Open] [float] NULL,
	[Close] [float] NULL,
	[PL] [float] NULL,
	[GrossPL] [float] NULL,
	[Com] [float] NULL,
	[Int] [float] NULL,
	[OpenTime] [datetime] NULL,
	[CloseTime] [datetime] NULL,
	[Kind] [varchar](100) NULL,
	[OpenOrderID] [varchar](100) NULL,
	[OpenOrderReqID] [varchar](100) NULL,
	[CloseOrderID] [varchar](100) NULL,
	[CloseOrderReqID] [varchar](100) NULL,
	[OQTXT] [varchar](100) NULL,
	[CQTXT] [varchar](100) NULL,
	[TradeIDOrigin] [varchar](100) NULL,
	[TradeIDRemain] [varchar](100) NULL,
CONSTRAINT [PK_tClosedTrades] PRIMARY KEY CLUSTERED 
(
	[TradeID]	ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, DATA_COMPRESSION = PAGE) ON [PRIMARY]
) ON [PRIMARY]
GO

SET ANSI_PADDING OFF
GO
