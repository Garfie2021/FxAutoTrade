USE [FX_DemoA]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO

CREATE TABLE [hltc].[T_システム異常発生件数_Daily](
	[年月日] [date] NOT NULL,
	[取引状況でデータ不足が発生した件数] [int] NOT NULL,
	[通常Order件数] [int] NOT NULL,
CONSTRAINT [PK_T_通貨ペア別異常発生件数_Daily] PRIMARY KEY CLUSTERED 
(
	[年月日] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, DATA_COMPRESSION = PAGE) ON [PRIMARY]
) ON [PRIMARY]
GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [hltc].[T_システム異常発生件数_Daily] ADD  CONSTRAINT [DF_T_システム異常発生件数_Daily_取引状況でデータ不足が発生した件数]  DEFAULT ((0)) FOR [取引状況でデータ不足が発生した件数]
GO

ALTER TABLE [hltc].[T_システム異常発生件数_Daily] ADD  CONSTRAINT [DF_T_システム異常発生件数_Daily_通常Order件数]  DEFAULT ((0)) FOR [通常Order件数]
GO

