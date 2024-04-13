USE [RealB_Kabu]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[T_差損益History](
	[通貨ペア] [tinyint] NOT NULL,
	[Date] [datetime] NOT NULL,
	[GrossPL] [float] NOT NULL,
	[ポジション数] [int] NOT NULL CONSTRAINT [DF_T_差損益History_ポジション数]  DEFAULT ((0)),
	[GrossPL_ポジション数割] [float] NOT NULL,
 CONSTRAINT [PK_差損益History_買い] PRIMARY KEY CLUSTERED 
(
	[通貨ペア] ASC,
	[Date] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, DATA_COMPRESSION = PAGE) ON [PRIMARY]
) ON [PRIMARY]

GO
