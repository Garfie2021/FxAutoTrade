USE OANDA_DemoB
GO
/*
*/
DROP PROCEDURE [anls].[spInsertデルタタイミング_売り]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [anls].[spInsertデルタタイミング_売り]
AS
BEGIN

	DELETE FROM [anls].[tデルタRate]
	WHERE [売買] = 0;


	DECLARE @通貨ペアNo tinyint = 0;
	DECLARE @通貨ペアNoMax tinyint = (SELECT MAX(No) from [cmn].[t通貨ペアMst]);

	DECLARE @5YearBackDate DateTime = DATEADD(year, -5, GETDATE());


	while @通貨ペアNo <= @通貨ペアNoMax
	begin

		DECLARE @StartDate1 datetime = null;
		DECLARE @StartDate2 datetime = null;
		DECLARE @StartDate3 datetime = null;
		DECLARE @売りRate_安値1 float = null;
		DECLARE @売りRate_安値2 float = null;
		DECLARE @売りRate_安値3 float = null;

		declare cursor_Month1 cursor for
		SELECT  [StartDate], 売りRate_安値
		FROM [hstr].[tMonth1]
		where 通貨ペアNo = @通貨ペアNo AND [StartDate] > @5YearBackDate
		ORDER BY [StartDate];

		open cursor_Month1;

		DECLARE @StartDate datetime;
		DECLARE @売りRate_安値 float;
		FETCH NEXT FROM cursor_Month1 INTO @StartDate, @売りRate_安値;

		WHILE @@FETCH_STATUS = 0
		BEGIN
			
			--SELECT @通貨ペアNo as 通貨ペアNo, @StartDate as StartDate, @売りRate_安値 as 売りRate_安値;

			SET @StartDate1 = @StartDate2;
			SET @StartDate2 = @StartDate3;
			SET @StartDate3 = @StartDate;

			SET @売りRate_安値1 = @売りRate_安値2;
			SET @売りRate_安値2 = @売りRate_安値3;
			SET @売りRate_安値3 = @売りRate_安値;

			IF @売りRate_安値1 IS NULL OR @売りRate_安値2 IS NULL OR @売りRate_安値3 IS NULL
			BEGIN
				--SELECT '1';
				FETCH NEXT FROM cursor_Month1 INTO @StartDate, @売りRate_安値;
				CONTINUE;
			END;

			IF @売りRate_安値1 <= @売りRate_安値2 OR @売りRate_安値2 >= @売りRate_安値3
			BEGIN
				--SELECT '2';
				FETCH NEXT FROM cursor_Month1 INTO @StartDate, @売りRate_安値;
				CONTINUE;
			END;

			--SELECT @通貨ペアNo as 通貨ペアNo, 'B' as 売買判定, @StartDate1 as StartDate1, @StartDate2 as StartDate2, @StartDate3 as StartDate3, 
			--	@売りRate_安値1 as 売りRate_安値1, @売りRate_安値2 as 売りRate_安値2, @売りRate_安値3 as 売りRate_安値3, GETDATE();

			INSERT INTO [anls].[tデルタRate](
				[通貨ペアNo],
				[売買],
				[StartDateMonth1_Begin],
				[StartDateMonth1_Center],
				[StartDateMonth1_End],
				[Rate_Begin],
				[Rate_Center],
				[Rate_End],
				[登録日時]
			)VALUES(
				@通貨ペアNo,
				0,
				@StartDate1,
				@StartDate2,
				@StartDate3,
				@売りRate_安値1,
				@売りRate_安値2,
				@売りRate_安値3,
				GETDATE()
			);

			FETCH NEXT FROM cursor_Month1 INTO @StartDate, @売りRate_安値;
		END

		CLOSE cursor_Month1;
		DEALLOCATE cursor_Month1;

		Set @通貨ペアNo = @通貨ペアNo + 1;
	end;

END
GO
/*
*/
