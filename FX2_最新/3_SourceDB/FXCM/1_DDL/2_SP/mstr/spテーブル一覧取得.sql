USE [FXCM]
GO
/*
*/
DROP PROCEDURE [mstr].[sp�e�[�u���ꗗ�擾]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [mstr].[sp�e�[�u���ꗗ�擾]
AS
BEGIN

	SELECT t.name
	FROM sys.tables t JOIN sys.schemas s ON t.schema_id=s.schema_id
	WHERE s.name = 'rate'
	ORDER BY t.name;

END
GO
/*
*/