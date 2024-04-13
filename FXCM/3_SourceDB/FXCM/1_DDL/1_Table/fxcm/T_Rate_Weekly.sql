USE [FXCM]
GO
/****** Object:  Table [dbo].[T_RateHistory_Monthly]    Script Date: 01/30/2014 06:29:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [fxcm].[T_Rate_Weekly](
	通貨ペアNo [tinyint] NOT NULL,
	日時 [date] NOT NULL,
	Rate_始値_買い [float] NOT NULL,
	Rate_高値_買い [float] NOT NULL,
	Rate_安値_買い [float] NOT NULL,
	Rate_終値_買い [float] NOT NULL,
	Rate_始値_売り [float] NOT NULL,
	Rate_高値_売り [float] NOT NULL,
	Rate_安値_売り [float] NOT NULL,
	Rate_終値_売り [float] NOT NULL,
 CONSTRAINT [PK_fxcm_Rate_Weekly] PRIMARY KEY CLUSTERED 
(
	[通貨ペアNo] ASC,
	[日時] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, DATA_COMPRESSION = PAGE) ON [PRIMARY]
) ON [PRIMARY]
GO
