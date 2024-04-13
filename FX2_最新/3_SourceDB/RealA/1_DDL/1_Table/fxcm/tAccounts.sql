USE DemoA_FX
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO

CREATE TABLE [fxcm].[tAccounts](
	[口座No]			int				NOT NULL,
	[日時] [datetime] NOT NULL,
	[AccountID] [varchar](50) NULL,
	[AccountName] [varchar](50) NULL,
	[Balance] [float] NULL,
	[Equity] [float] NULL,
	[DayPL] [float] NULL,
	[NontrdEqty] [float] NULL,
	[M2MEquity] [float] NULL,
	[UsedMargin] [float] NULL,
	[UsableMargin] [float] NULL,
	[GrossPL] [float] NULL,
	[Kind] [varchar](50) NULL,
	[MarginCall] [varchar](50) NULL,
	[IsUnderMarginCall] [varchar](50) NULL,
	[Hedging] [varchar](50) NULL,
	[AmountLimit] [int] NULL,
	[BaseUnitSize] [int] NULL,
CONSTRAINT [PK_tAccounts] PRIMARY KEY CLUSTERED 
(
	[口座No]	ASC,
	[日時] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, DATA_COMPRESSION = PAGE) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
