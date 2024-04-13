USE OANDA_DemoB
GO

DROP PROCEDURE [acvdel].[spDropCreate_pfmc_tExecLog]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [acvdel].[spDropCreate_pfmc_tExecLog]
AS
BEGIN

	SET NOCOUNT ON;

	DROP TABLE [pfmc].[tExecLog];


	CREATE TABLE [pfmc].[tExecLog](
		[口座No]		int				NOT NULL,
		[ExecDate]		[datetime2](7)	NOT NULL,
		[処理区分]		[varchar](10)	NOT NULL,
		[通貨ペアNo]	[tinyint]		NULL,
		[処理名]		[varchar](50)	NULL,
		[取引状況]		[varchar](100)	NULL,
		[Order開始日時]	[datetime]		NULL
	) ON [PRIMARY]


	ALTER TABLE [pfmc].[tExecLog] REBUILD PARTITION = ALL WITH  (DATA_COMPRESSION = PAGE);

END
GO
