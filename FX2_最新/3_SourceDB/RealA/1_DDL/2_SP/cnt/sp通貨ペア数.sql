USE OANDA_DemoB
GO

DROP PROCEDURE [cnt].[sp�ʉ݃y�A��]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [cnt].[sp�ʉ݃y�A��]
	@�ʉ݃y�A��	tinyint	output
AS
BEGIN

	SELECT @�ʉ݃y�A�� = COUNT(*) FROM  cmn.t�ʉ݃y�AMst;

END
GO

