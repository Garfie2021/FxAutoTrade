USE [RealA_FX]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [smlt].[SP_InsertBonusStage]
	 @通貨ペアNo	tinyint
	,@StartDate		datetime
	,@EndDate		datetime
AS
BEGIN
	SET NOCOUNT ON;
	/*
	DECLARE @通貨ペアNo	tinyint = 2;
	DECLARE @StartDate DateTime = '2014-05-15 20:00:00';
	DECLARE @EndDate DateTime = '2014-05-16 00:00:00';
	*/

	print convert(varchar, @通貨ペアNo) + '	' + convert(varchar, @StartDate);

	DECLARE @Start15m DateTime;
	DECLARE @End15m datetime;

	DELETE FROM T_BonusStageHistory
	WHERE 通貨ペアNo = @通貨ペアNo AND @StartDate <= 日時 AND 日時 <= @EndDate;

	DECLARE @BonusStage判定 TABLE (
		シグマ閾値			float NOT NULL, 
		BonusStage判定_前	VARCHAR(1) NOT NULL, 
		BonusStage判定_今	VARCHAR(1) NOT NULL, 
		PRIMARY KEY (シグマ閾値)
	);

	DECLARE @シグマ閾値 float = 1.0;
	WHILE @シグマ閾値 < 4.5
	BEGIN
		INSERT INTO @BonusStage判定(シグマ閾値, BonusStage判定_前, BonusStage判定_今) VALUES (@シグマ閾値, '', '');
		SET @シグマ閾値 = @シグマ閾値 + 0.5;
	END;

	DECLARE cursorT_RateHistory CURSOR FOR
	SELECT [Date], Rate_売り, Rate_買い
	FROM T_RateHistory
	WHERE (通貨ペア = @通貨ペアNo) AND (@StartDate <= [Date]) AND ([Date] <= @EndDate)
	ORDER BY [Date]

	OPEN cursorT_RateHistory;

	DECLARE @WMA判定_15m varchar(10);
	DECLARE @BonusStage判定_15m varchar(10);
	DECLARE @BonusStage判定_前 varchar(1);
	DECLARE @BonusStage判定_今 varchar(1);

	declare @now datetime;
	DECLARE @買いRate float
	DECLARE @売りRate float
	FETCH NEXT FROM cursorT_RateHistory INTO @now, @売りRate, @買いRate;

	WHILE @@FETCH_STATUS = 0
	BEGIN

		EXECUTE [cmn].[SP_GetThis15m] @now, 0, @Start15m OUTPUT, @End15m OUTPUT

		EXECUTE [smlt].[SP_InsertRateHistory_15m] @通貨ペアNo, @Start15m, @now;
		EXECUTE [smlt].[SP_InsertIndicator_15m_WMA] @通貨ペアNo, @Start15m;

		SET @シグマ閾値 = 1.0;
		WHILE @シグマ閾値 < 4.5
		BEGIN
			UPDATE @BonusStage判定 SET BonusStage判定_前 = BonusStage判定_今 WHERE シグマ閾値 = @シグマ閾値;

			EXECUTE [smlt].[SP_Chkボーナスステージ_15m] @通貨ペアNo, @Start15m, @シグマ閾値, @WMA判定_15m OUTPUT, @BonusStage判定_15m OUTPUT

			UPDATE @BonusStage判定 SET BonusStage判定_今 = @BonusStage判定_15m WHERE シグマ閾値 = @シグマ閾値;

			SELECT @BonusStage判定_前 = BonusStage判定_前, @BonusStage判定_今 = BonusStage判定_今
			FROM @BonusStage判定
			WHERE シグマ閾値 = @シグマ閾値;

			if @BonusStage判定_前 = '' and @BonusStage判定_今 = 'B'
			begin
				-- Bonus Stage 開始処理 //
				EXECUTE [smlt].[SP_InsertBonusStageHistory] @通貨ペアNo, @now, @シグマ閾値, @買いRate, @売りRate, @WMA判定_15m, 'S', '';
			end
			else if @BonusStage判定_前 = 'B' and @BonusStage判定_今 = ''
			begin
				-- Bonus Stage 終了処理 //
				EXECUTE [smlt].[SP_InsertBonusStageHistory] @通貨ペアNo, @now, @シグマ閾値, @買いRate, @売りRate, @WMA判定_15m, 'E', '';
			end;

			SET @シグマ閾値 = @シグマ閾値 + 0.5;
		END;

		FETCH NEXT FROM cursorT_RateHistory INTO @now, @売りRate, @買いRate;
	END;

	CLOSE cursorT_RateHistory;
	DEALLOCATE cursorT_RateHistory;

END

GO
