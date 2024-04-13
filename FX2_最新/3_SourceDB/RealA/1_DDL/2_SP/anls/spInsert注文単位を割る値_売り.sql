USE OANDA_DemoB
GO
/*
*/
DROP PROCEDURE [anls].[spInsert注文単位を割る値_売り]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [anls].[spInsert注文単位を割る値_売り]
AS
BEGIN

	-- 定数
	-- 10～1000の間で注文単位を割る。危険なRate域では注文単位を最大1000で割る。
	DECLARE @注文単位を割る値_最大 int;
	DECLARE @注文単位を割る値_最小 int;
	DECLARE @YearDiff smallint = 0;

	SELECT @注文単位を割る値_最大 = [値] FROM [cmn].[t環境設定] WHERE [No] = 1;	-- spInsert注文単位を割る値_買い  @注文単位を割る値_最大


	DELETE FROM [anls].[t注文単位を割る値]
	WHERE [売買] = 0;


	DECLARE @通貨ペアNo tinyint = 0;
	DECLARE @通貨ペアNoMax tinyint = (SELECT MAX(No) from [cmn].[t通貨ペアMst]);

	while @通貨ペアNo <= @通貨ペアNoMax
	begin

		DECLARE @Rate_Center1 float = 0;
		DECLARE @Rate_Center2 float = 0;
		DECLARE @RowCnt int = 0;

		SELECT @注文単位を割る値_最小 = [値] FROM [cmn].[t環境設定] WHERE [No] = 2;	-- spInsert注文単位を割る値_買い  @注文単位を割る値_最小

		SELECT @YearDiff = DATEDIFF(year, MIN([StartDate]), MAX([StartDate]))
		FROM [hstr].[tMonth1]
		where [通貨ペアNo] = @通貨ペアNo

		IF @YearDiff < 2
		BEGIN
			-- 2年未満は最低400で割る。
			SET @注文単位を割る値_最小 = 400;
		END
		ELSE IF @YearDiff < 3
		BEGIN
			-- 3年未満は最低300で割る。
			SET @注文単位を割る値_最小 = 300;
		END
		ELSE IF @YearDiff < 4
		BEGIN
			-- 4年未満は最低200で割る。
			SET @注文単位を割る値_最小 = 200;
		END;

		DECLARE @Cnt int = 0;
		SELECT @CNT = COUNT(*)
		FROM [anls].[tデルタRate]
		WHERE [通貨ペアNo] = @通貨ペアNo AND [売買] = 0;

		IF @Cnt < 1
		BEGIN
			Set @通貨ペアNo = @通貨ペアNo + 1;
			CONTINUE;
		END;

		--print @通貨ペアNo;
		--print @注文単位を割る値_最大;
		--print @注文単位を割る値_最小;
		--print @CNT;

		DECLARE @OneTime int = (@注文単位を割る値_最大 - @注文単位を割る値_最小) / @CNT;

		declare cursor_デルタRate cursor for
		SELECT [Rate_Center]
		FROM [anls].[tデルタRate]
		WHERE [通貨ペアNo] = @通貨ペアNo AND [売買] = 0
		ORDER BY [Rate_Center] DESC;

		open cursor_デルタRate;

		DECLARE @Rate_Center float;
		FETCH NEXT FROM cursor_デルタRate INTO @Rate_Center;

		SET @Rate_Center1 = @Rate_Center * 2;
		
		WHILE @@FETCH_STATUS = 0
		BEGIN
			
			SET @Rate_Center2 = @Rate_Center1;
			SET @Rate_Center1 = @Rate_Center;

			--IF @Rate_Center1 = 0 OR @Rate_Center2 = 0
			--BEGIN
			--	--SELECT '1';
			--	FETCH NEXT FROM cursor_デルタRate INTO @Rate_Center;
			--	CONTINUE;
			--END;

			IF @Rate_Center1 = @Rate_Center2
			BEGIN
				--SELECT '2';
				FETCH NEXT FROM cursor_デルタRate INTO @Rate_Center;
				CONTINUE;
			END;

			INSERT INTO [anls].[t注文単位を割る値] (
				[通貨ペアNo],
				[売買],
				[Rate_High],
				[Rate_Low],
				[注文単位を割る値],
				[登録日時]
			) VALUES (
				@通貨ペアNo,
				0,
				@Rate_Center2,
				@Rate_Center1,
				@注文単位を割る値_最小 + (@OneTime * @RowCnt),
				GETDATE()
			);

			SET @RowCnt = @RowCnt +1;
			FETCH NEXT FROM cursor_デルタRate INTO @Rate_Center;
		END

		CLOSE cursor_デルタRate;
		DEALLOCATE cursor_デルタRate;

		INSERT INTO [anls].[t注文単位を割る値] (
			[通貨ペアNo],
			[売買],
			[Rate_High],
			[Rate_Low],
			[注文単位を割る値],
			[登録日時]
		) VALUES (
			@通貨ペアNo,
			0,
			@Rate_Center1,
			@Rate_Center1 - (@Rate_Center1 * 0.1), --最高値の-10%までは注文対象にしとく
			@注文単位を割る値_最大,
			GETDATE()
		);

		Set @通貨ペアNo = @通貨ペアNo + 1;
	end;

END
GO
/*
*/
