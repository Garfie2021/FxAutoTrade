USE [OANDA_DemoB]
GO

DROP PROCEDURE [acv].[spSave_anls_t想定売買タイミング_Swap判定無し]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [acv].[spSave_anls_t想定売買タイミング_Swap判定無し]
AS
BEGIN

	SET NOCOUNT ON;

	INSERT INTO [OANDA_DemoB_ACV].anls.t想定売買タイミング_Swap判定無し(
		[通貨ペアNo],
		[売買判定],
		[StartDateMin1],
		[StartDateMin5],
		[StartDateMin15],
		[StartDateHour1],
		[StartDateDay1],
		[StartDateWeek1],
		[StartDateMonth1],
		[登録日時],
		[更新日時],
		[比較結果])
	SELECT 
		[通貨ペアNo],
		[売買判定],
		[StartDateMin1],
		[StartDateMin5],
		[StartDateMin15],
		[StartDateHour1],
		[StartDateDay1],
		[StartDateWeek1],
		[StartDateMonth1],
		[登録日時],
		[更新日時],
		[比較結果]
	FROM [OANDA_DemoB].anls.t想定売買タイミング_Swap判定無し as a
	WHERE not exists 
		(
			SELECT *
			FROM [OANDA_DemoB_ACV].anls.t想定売買タイミング_Swap判定無し as b
			WHERE a.[通貨ペアNo] = b.[通貨ペアNo] AND a.[売買判定] = b.[売買判定] AND a.[StartDateMin1] = b.[StartDateMin1]
		);

END
GO

