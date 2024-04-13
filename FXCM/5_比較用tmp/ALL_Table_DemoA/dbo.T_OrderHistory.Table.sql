USE [RealB_Kabu]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[T_OrderHistory](
	[通貨ペアNo] [tinyint] NOT NULL,
	[日時] [datetime] NOT NULL,
	[売買モード] [varchar](5) NOT NULL,
	[Close済み] [tinyint] NOT NULL,
	[Rate_買い] [float] NULL,
	[Rate_売り] [float] NULL,
	[Close区分] [varchar](50) NULL,
	[BonusStage] [varchar](1) NULL,
	[注文単位] [tinyint] NULL,
	[OpenOrderID] [varchar](50) NULL,
	[TradeID] [varchar](50) NULL,
	[リミット拡張OrderID] [varchar](50) NULL,
	[リミット初期化OrderID] [varchar](50) NULL,
	[CloseOrderID] [varchar](50) NULL,
	[Order区分] [tinyint] NULL,
 CONSTRAINT [PK_T_OrderHistory] PRIMARY KEY CLUSTERED 
(
	[通貨ペアNo] ASC,
	[日時] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, DATA_COMPRESSION = PAGE) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
