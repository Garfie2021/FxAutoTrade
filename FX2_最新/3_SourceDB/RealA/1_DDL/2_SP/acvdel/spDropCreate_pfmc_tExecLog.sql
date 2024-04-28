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
		[����No]		int				NOT NULL,
		[ExecDate]		[datetime2](7)	NOT NULL,
		[�����敪]		[varchar](10)	NOT NULL,
		[�ʉ݃y�ANo]	[tinyint]		NULL,
		[������]		[varchar](50)	NULL,
		[�����]		[varchar](100)	NULL,
		[Order�J�n����]	[datetime]		NULL
	) ON [PRIMARY]


	ALTER TABLE [pfmc].[tExecLog] REBUILD PARTITION = ALL WITH  (DATA_COMPRESSION = PAGE);

END
GO
