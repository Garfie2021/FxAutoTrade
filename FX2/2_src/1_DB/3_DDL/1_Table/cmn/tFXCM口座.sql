USE [FX2_Demo]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO

CREATE TABLE [cmn].[tFXCM口座](
	[口座名] [varchar](10) NOT NULL,
	[口座タイプ] [tinyint] NOT NULL,	-- Demo:1 Real:2
	[ID] [varchar](100) NOT NULL,
	[PASS] [varchar](100) NOT NULL,
	[フラグ] [tinyint] NOT NULL,		-- 未使用:1  Rate取得のみ:2  Rate取得と注文:3  注文のみ:4 
	[口座説明] [varchar](100) NULL,
	[備考] [varchar](100) NULL,
CONSTRAINT [PK_tFXCM口座] PRIMARY KEY CLUSTERED 
(
	[口座名] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, DATA_COMPRESSION = PAGE) ON [PRIMARY]
) ON [PRIMARY]
GO

SET ANSI_PADDING OFF
GO

