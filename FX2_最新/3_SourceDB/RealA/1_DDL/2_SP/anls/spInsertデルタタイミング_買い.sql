USE OANDA_DemoB
GO
/*
*/
DROP PROCEDURE [anls].[spInsertデルタタイミング_買い]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [anls].[spInsertデルタタイミング_買い]
AS
BEGIN

	DELETE FROM [anls].[tデルタRate]
	WHERE [売買] = '1';


	DECLARE @通貨ペアNo tinyint = 0;
	DECLARE @通貨ペアNoMax tinyint = (SELECT MAX(No) from [cmn].[t通貨ペアMst]);

	DECLARE @5YearBackDate DateTime = DATEADD(year, -5, GETDATE());
	

	while @通貨ペアNo <= @通貨ペアNoMax
	begin

		DECLARE @StartDate1 datetime = null;
		DECLARE @StartDate2 datetime = null;
		DECLARE @StartDate3 datetime = null;
		DECLARE @買いRate_高値1 float = null;
		DECLARE @買いRate_高値2 float = null;
		DECLARE @買いRate_高値3 float = null;

		declare cursor_Month1 cursor for
		SELECT  [StartDate], 買いRate_高値
		FROM [hstr].[tMonth1]
		where 通貨ペアNo = @通貨ペアNo AND [StartDate] > @5YearBackDate
		ORDER BY [StartDate];

		open cursor_Month1;

		DECLARE @StartDate datetime;
		DECLARE @買いRate_高値 float;
		FETCH NEXT FROM cursor_Month1 INTO @StartDate, @買いRate_高値;

		WHILE @@FETCH_STATUS = 0
		BEGIN
			
			--SELECT @通貨ペアNo as 通貨ペアNo, @StartDate as StartDate, @買いRate_高値 as 買いRate_高値;

			SET @StartDate1 = @StartDate2;
			SET @StartDate2 = @StartDate3;
			SET @StartDate3 = @StartDate;

			SET @買いRate_高値1 = @買いRate_高値2;
			SET @買いRate_高値2 = @買いRate_高値3;
			SET @買いRate_高値3 = @買いRate_高値;

			IF @買いRate_高値1 IS NULL OR @買いRate_高値2 IS NULL OR @買いRate_高値3 IS NULL
			BEGIN
				--SELECT '1';
				FETCH NEXT FROM cursor_Month1 INTO @StartDate, @買いRate_高値;
				CONTINUE;
			END;

			IF @買いRate_高値1 >= @買いRate_高値2 OR @買いRate_高値2 <= @買いRate_高値3
			BEGIN
				--SELECT '2';
				FETCH NEXT FROM cursor_Month1 INTO @StartDate, @買いRate_高値;
				CONTINUE;
			END;

			--SELECT @通貨ペアNo as 通貨ペアNo, 'B' as 売買判定, @StartDate1 as StartDate1, @StartDate2 as StartDate2, @StartDate3 as StartDate3, 
			--	@買いRate_高値1 as 買いRate_高値1, @買いRate_高値2 as 買いRate_高値2, @買いRate_高値3 as 買いRate_高値3, GETDATE();

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
				1,
				@StartDate1,
				@StartDate2,
				@StartDate3,
				@買いRate_高値1,
				@買いRate_高値2,
				@買いRate_高値3,
				GETDATE()
			);

			FETCH NEXT FROM cursor_Month1 INTO @StartDate, @買いRate_高値;
		END

		CLOSE cursor_Month1;
		DEALLOCATE cursor_Month1;

		Set @通貨ペアNo = @通貨ペアNo + 1;
	end;

END
GO
/*
*/
