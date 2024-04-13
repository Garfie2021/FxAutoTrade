USE [FXCM]
GO
/*
*/
DROP PROCEDURE [mstr].[spテーブル一覧取得]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [mstr].[spテーブル一覧取得]
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