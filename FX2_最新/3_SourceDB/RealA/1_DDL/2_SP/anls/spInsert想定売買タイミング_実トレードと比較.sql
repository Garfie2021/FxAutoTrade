USE OANDA_RealA
GO

DROP PROCEDURE [anls].[spInsert想定売買タイミング_実トレードと比較]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [anls].[spInsert想定売買タイミング_実トレードと比較]
	@StartDate_Month1	datetime
AS
BEGIN

	DECLARE cursor_想定売買タイミング cursor for
	SELECT  [通貨ペアNo], [売買判定], [StartDateMin1], [StartDateMin5], [StartDateMin15], [StartDateHour1], [StartDateDay1]
	FROM [anls].[t想定売買タイミング]
	WHERE [StartDateMonth1] = @StartDate_Month1;

	OPEN cursor_想定売買タイミング;

	DECLARE @通貨ペアNo			tinyint;
	DECLARE @売買判定			bit;
	DECLARE @StartDateMin1		datetime;
	DECLARE @StartDateMin5		datetime;
	DECLARE @StartDateMin15		datetime;
	DECLARE @StartDateHour1		datetime;
	DECLARE @StartDateDay1		datetime;
	FETCH NEXT FROM cursor_想定売買タイミング INTO @通貨ペアNo, @売買判定, @StartDateMin1, @StartDateMin5, @StartDateMin15, @StartDateHour1, @StartDateDay1;

	WHILE @@FETCH_STATUS = 0
	BEGIN

		DECLARE @比較結果 varchar(8000);


		-- 想定タイミング直近に注文有り

		DECLARE @Cnt int;
		SELECT @Cnt = COUNT(*)
		FROM [oder].[tOrderHistory2]
		WHERE [通貨ペアNo] = @通貨ペアNo AND [売買] = @売買判定 AND @StartDateDay1 <= [日時] AND [日時] < DATEADD(DAY, 1, @StartDateDay1)

		IF @Cnt > 0
		BEGIN
			SET @比較結果 = '1日以内に注文有り。';
		END ELSE BEGIN
			SET @比較結果 = '1日以内に注文無し。';
		END;

		SELECT @Cnt = COUNT(*)
		FROM [oder].[tOrderHistory2]
		WHERE [通貨ペアNo] = @通貨ペアNo AND [売買] = @売買判定 AND @StartDateHour1 <= [日時] AND [日時] < DATEADD(HOUR, 1, @StartDateHour1)

		IF @Cnt > 0
		BEGIN
			SET @比較結果 = '1時間以内に注文有り。';
		END ELSE BEGIN
			SET @比較結果 = '1時間以内に注文無し。';
		END;


		-- 想定タイミング直近のログ

		DECLARE cursor_ExecLog cursor for
		SELECT  [取引状況]
		FROM [pfmc].[tExecLog]
		WHERE [通貨ペアNo] = @通貨ペアNo AND @StartDateMin1 <= [ExecDate] AND [ExecDate] < @StartDateMin1;

		OPEN cursor_ExecLog;

		DECLARE @取引状況 varchar(100);
		FETCH NEXT FROM cursor_ExecLog INTO @取引状況;

		WHILE @@FETCH_STATUS = 0
		BEGIN
			SET @比較結果 = @比較結果 + @取引状況 + '。';

			FETCH NEXT FROM cursor_ExecLog INTO @取引状況;
		END

		CLOSE cursor_ExecLog;
		DEALLOCATE cursor_ExecLog;


		-- 比較結果をWrite

		UPDATE [anls].[t想定売買タイミング]
		SET [比較結果] = @比較結果,
			[更新日時] = getdate()
		WHERE @通貨ペアNo = [通貨ペアNo] AND @売買判定 = [売買判定] AND @StartDateMin1 = [StartDateMin1];

		FETCH NEXT FROM cursor_想定売買タイミング INTO @通貨ペアNo, @売買判定, @StartDateMin1, @StartDateMin5, @StartDateMin15, @StartDateHour1, @StartDateDay1;
	END

	CLOSE cursor_想定売買タイミング;
	DEALLOCATE cursor_想定売買タイミング;


END
GO

