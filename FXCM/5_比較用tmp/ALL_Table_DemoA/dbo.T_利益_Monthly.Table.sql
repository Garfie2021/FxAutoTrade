USE [RealB_Kabu]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[T_利益_Monthly](
	[年月] [date] NOT NULL,
	[利益] [int] NOT NULL,
	[利益Plus] [int] NULL,
	[利益Minus] [int] NULL,
	[利益確定開始以降の利益] [int] NOT NULL,
	[出金可能Percent] [tinyint] NOT NULL,
	[出金可能額] [int] NOT NULL,
	[出金済フラグ] [tinyint] NOT NULL,
	[出金判定時_1時間前の取引証拠金] [int] NULL,
	[出金判定時_現在の取引証拠金] [int] NULL,
	[出金判定時_先月利益] [int] NULL,
 CONSTRAINT [PK_T_利益_Monthly_tmp] PRIMARY KEY CLUSTERED 
(
	[年月] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, DATA_COMPRESSION = PAGE) ON [PRIMARY]
) ON [PRIMARY]

GO
