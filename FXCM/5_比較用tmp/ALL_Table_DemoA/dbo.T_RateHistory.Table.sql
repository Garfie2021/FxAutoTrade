USE [RealB_Kabu]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[T_RateHistory](
	[通貨ペア] [tinyint] NOT NULL,
	[Date] [datetime] NOT NULL,
	[Rate_買い] [float] NOT NULL,
	[Rate_売り] [float] NOT NULL,
	[Swap_買い] [float] NOT NULL,
	[Swap_売り] [float] NOT NULL,
	[Rate相反Status_買い] [varchar](5) NULL,
	[Rate相反Status_売り] [varchar](5) NULL,
 CONSTRAINT [PK_RateHistory_買い] PRIMARY KEY CLUSTERED 
(
	[通貨ペア] ASC,
	[Date] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, DATA_COMPRESSION = PAGE) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
