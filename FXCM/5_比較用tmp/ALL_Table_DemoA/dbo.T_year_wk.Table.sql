USE [RealB_Kabu]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[T_year_wk](
	[year] [smallint] NOT NULL,
	[wk] [tinyint] NOT NULL,
	[year_wk] [varchar](20) NOT NULL,
	[start_year] [smallint] NOT NULL,
	[start_month] [tinyint] NOT NULL,
	[start_day] [tinyint] NOT NULL,
	[end_year] [smallint] NOT NULL,
	[end_month] [tinyint] NOT NULL,
	[end_day] [tinyint] NOT NULL,
	[StartDate] [datetime] NOT NULL,
	[EndDate] [datetime] NOT NULL,
 CONSTRAINT [PK_year_wk] PRIMARY KEY CLUSTERED 
(
	[year] ASC,
	[wk] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, DATA_COMPRESSION = PAGE) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
