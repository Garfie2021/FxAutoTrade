USE DemoA_FX
GO
/*
*/
DROP PROCEDURE [hltc].[spInsert処理時間]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [hltc].[spInsert処理時間]
	@処理区分	tinyint,
	@処理開始	datetime,
	@処理終了	datetime
AS
BEGIN
	SET NOCOUNT ON;

	INSERT INTO [hltc].[t処理時間]
		([処理区分]
		,[処理開始]
		,[処理終了])
	VALUES
		(@処理区分
		,@処理開始
		,@処理終了);

END
GO
/*
*/
