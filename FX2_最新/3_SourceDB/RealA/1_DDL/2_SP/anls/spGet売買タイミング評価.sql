USE OANDA_RealB
GO
/*
*/
DROP PROCEDURE [anls].[spGet売買タイミング評価]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [anls].[spGet売買タイミング評価]
	@now		datetime,
	@評価		varchar(8000)	output
AS
BEGIN

	/*
	DECLARE @now	datetime = '2017/04/21 6:00:00';
	DECLARE @評価	varchar(8000) = '';
	*/

	DECLARE @通貨ペアNo tinyint = 0;
	DECLARE @通貨ペアNoMax tinyint = (SELECT MAX(No) from [cmn].[t通貨ペアMst]);

	DECLARE @通貨ペア名 varchar(10) = '';
	DECLARE @買いSwap float;
	DECLARE @売りSwap float;
	DECLARE @Swap判定 varchar(10) = '';
	DECLARE @月Rate判定 varchar(10) = '';
	DECLARE @週Rate判定 varchar(10) = '';
	DECLARE @日Rate判定 varchar(10) = '';
	DECLARE @Hour1Rate有効回数	varchar(10) = '';
	DECLARE @Min30Rate有効回数	varchar(10) = '';
	DECLARE @Min15Rate有効回数	varchar(10) = '';
	DECLARE @Min5Rate有効回数	varchar(10) = '';
	DECLARE @Min1Rate有効回数	varchar(10) = '';
	DECLARE @Min15BS発生回数	varchar(10) = '';

	DECLARE @back_Month1		int = 0;
	DECLARE @ThisMonth1			Datetime;
	DECLARE @StartDateMonth1	Datetime;
	DECLARE @EndDateMonth1		Datetime;
	EXEC [cmn].[spGetThisMonth1] @now, @back_Month1, @ThisMonth1, @StartDateMonth1, @EndDateMonth1;

	DECLARE @back_Week1		int = 0;
	DECLARE @ThisWeek1		Datetime;
	DECLARE @StartDateWeek1	Datetime;
	DECLARE @EndDateWeek1	Datetime;
	EXEC [cmn].[spGetThisWeek1] @now, @back_Week1, @ThisWeek1, @StartDateWeek1, @EndDateWeek1;

	DECLARE @back_Day1		int = 0;
	DECLARE @ThisDay1		Datetime;
	DECLARE @StartDateDay1	Datetime;
	DECLARE @EndDateDay1	Datetime;
	EXEC [cmn].[spGetThisDay1] @now, @back_Day1, @ThisDay1, @StartDateDay1, @EndDateDay1;

	DECLARE @Cnt tinyint = 0;


	SET @評価 = '通貨ペアNo\t通貨ペア名\tSwap判定\t月Rate判定\t週Rate判定\t日Rate判定\r\n';

	-- 縦は通貨ペア
	while @通貨ペアNo <= @通貨ペアNoMax
	begin

		-- 通貨ペア名

		SELECT @通貨ペア名 = [ペア名]
		FROM [cmn].[t通貨ペアMst]
		WHERE [No] = @通貨ペアNo;


		-- Swap判定

		SELECT TOP 1 @買いSwap = [買いSwap], @売りSwap = [売りSwap]
		FROM [swap].[tSwap手動登録_Day1]
		WHERE [通貨ペアNo] = @通貨ペアNo
		ORDER BY [StartDate] DESC;

		IF @買いSwap = NULL OR @売りSwap = NULL
		BEGIN
			SET @評価 = @評価 + CONVERT(varchar, @通貨ペアNo) + '\t' + @通貨ペア名 + '\t\t\t\r\n';
			SET @通貨ペアNo = @通貨ペアNo + 1;
			CONTINUE;
		END;

		IF @買いSwap > @売りSwap AND @買いSwap > 0
		BEGIN
			SET @Swap判定 = '買い';
		END
		ELSE IF @売りSwap > @買いSwap AND @売りSwap > 0
		BEGIN
			SET @Swap判定 = '売り';
		END;


		-- 月Rate判定

		IF @Swap判定 = '買い'
		BEGIN

			SELECT @Cnt = count(*)
			FROM [hstr].[tMonth1]
			WHERE 通貨ペアNo = @通貨ペアNo and [StartDate] = @StartDateMonth1 and 
				[買いWMAs2] > [買いWMAs14] and [買いWMAs2角度] > 0;

			IF @Cnt > 0
			BEGIN
				SET @月Rate判定 = '買い';
			END
			ELSE
			BEGIN
				SET @月Rate判定 = '';
			END;

		END
		ELSE IF @Swap判定 = '売り'
		BEGIN

			SELECT @Cnt = count(*)
			FROM [hstr].[tMonth1]
			WHERE 通貨ペアNo = @通貨ペアNo and [StartDate] = @StartDateMonth1 and 
				[売りWMAs2] < [売りWMAs14] and [売りWMAs2角度] < 0;

			IF @Cnt > 0
			BEGIN
				SET @月Rate判定 = '売り';
			END
			ELSE
			BEGIN
				SET @月Rate判定 = '';
			END;

		END;

		IF @月Rate判定 = ''
		BEGIN
			SET @評価 = @評価 + CONVERT(varchar, @通貨ペアNo) + '\t' + @通貨ペア名 + '\t' + @Swap判定 + '\t\t\r\n';
			SET @通貨ペアNo = @通貨ペアNo + 1;
			CONTINUE;
		END;


		-- 週Rate判定

		IF @Swap判定 = '買い'
		BEGIN

			SELECT @Cnt = count(*)
			FROM [hstr].[tWeek1]
			WHERE 通貨ペアNo = @通貨ペアNo and [StartDate] = @StartDateWeek1 and 
				[買いWMAs2] > [買いWMAs14] and [買いWMAs2角度] > 0;

			IF @Cnt > 0
			BEGIN
				SET @週Rate判定 = '買い';
			END
			ELSE
			BEGIN
				SET @週Rate判定 = '';
			END;

		END
		ELSE IF @Swap判定 = '売り'
		BEGIN

			SELECT @Cnt = count(*)
			FROM [hstr].[tWeek1]
			WHERE 通貨ペアNo = @通貨ペアNo and [StartDate] = @StartDateWeek1 and 
				[売りWMAs2] < [売りWMAs14] and [売りWMAs2角度] < 0;

			IF @Cnt > 0
			BEGIN
				SET @週Rate判定 = '売り';
			END
			ELSE
			BEGIN
				SET @週Rate判定 = '';
			END;

		END;

		IF @週Rate判定 = ''
		BEGIN
			SET @評価 = @評価 + CONVERT(varchar, @通貨ペアNo) + '\t' + @通貨ペア名 + '\t' + @Swap判定 + '\t' + @月Rate判定 + '\t\r\n';
			SET @通貨ペアNo = @通貨ペアNo + 1;
			CONTINUE;
		END;


		-- 日Rate判定

		IF @Swap判定 = '買い'
		BEGIN

			SELECT @Cnt = count(*)
			FROM [hstr].[tDay1]
			WHERE 通貨ペアNo = @通貨ペアNo and [StartDate] = @StartDateDay1 and
				[買いWMAs2] > [買いWMAs14] and [買いWMAs2角度] > 0;

			IF @Cnt > 0
			BEGIN
				SET @日Rate判定 = '買い';
			END
			ELSE
			BEGIN
				SET @日Rate判定 = '';
			END;

		END
		ELSE IF @Swap判定 = '売り'
		BEGIN

			SELECT @Cnt = count(*)
			FROM [hstr].[tDay1]
			WHERE 通貨ペアNo = @通貨ペアNo and [StartDate] = @StartDateDay1 and
				[売りWMAs2] < [売りWMAs14] and [売りWMAs2角度] < 0;

			IF @Cnt > 0
			BEGIN
				SET @日Rate判定 = '売り';
			END
			ELSE
			BEGIN
				SET @日Rate判定 = '';
			END;

		END;

		IF @日Rate判定 = ''
		BEGIN
			SET @評価 = @評価 + CONVERT(varchar, @通貨ペアNo) + '\t' + @通貨ペア名 + '\t' + @Swap判定 + '\t' + @月Rate判定 + '\t' + @週Rate判定 + '\r\n';
			SET @通貨ペアNo = @通貨ペアNo + 1;
			CONTINUE;
		END;


		-- Hour1Rate判定

		IF @Swap判定 = '買い'
		BEGIN

			SELECT @Cnt = count(*)
			FROM [hstr].[tHour1]
			WHERE 通貨ペアNo = @通貨ペアNo and @StartDateDay1 <= [StartDate] and [StartDate] < @StartDateDay1 and
				[買いWMAs2] > [買いWMAs14] and [買いWMAs2角度] > 0;

			SET @Hour1Rate有効回数 = '買い(' + CONVERT(varchar, @Cnt) + ')';

		END
		ELSE IF @Swap判定 = '売り'
		BEGIN

			SELECT @Cnt = count(*)
			FROM [hstr].[tHour1]
			WHERE 通貨ペアNo = @通貨ペアNo and @StartDateDay1 <= [StartDate] and [StartDate] < @StartDateDay1 and
				[売りWMAs2] < [売りWMAs14] and [売りWMAs2角度] < 0;

			SET @Hour1Rate有効回数 = '売り(' + CONVERT(varchar, @Cnt) + ')';

		END;


		-- Min15Rate判定

		IF @Swap判定 = '買い'
		BEGIN

			SELECT @Cnt = count(*)
			FROM [hstr].[tMin15]
			WHERE 通貨ペアNo = @通貨ペアNo and @StartDateDay1 <= [StartDate] and [StartDate] < @EndDateDay1 and
				[買いWMAs2] > [買いWMAs14] and [買いWMAs2角度] > 0;

			SET @Min15Rate有効回数 = '買い(' + CONVERT(varchar, @Cnt) + ')';

		END
		ELSE IF @Swap判定 = '売り'
		BEGIN

			SELECT @Cnt = count(*)
			FROM [hstr].[tMin15]
			WHERE 通貨ペアNo = @通貨ペアNo and @StartDateDay1 <= [StartDate] and [StartDate] < @EndDateDay1 and
				[売りWMAs2] < [売りWMAs14] and [売りWMAs2角度] < 0;

			SET @Min15Rate有効回数 = '売り(' + CONVERT(varchar, @Cnt) + ')';

		END;


		-- Min5Rate判定

		IF @Swap判定 = '買い'
		BEGIN

			SELECT @Cnt = count(*)
			FROM [hstr].[tMin5]
			WHERE 通貨ペアNo = @通貨ペアNo and @StartDateDay1 <= [StartDate] and [StartDate] < @EndDateDay1 and
				[買いWMAs2] > [買いWMAs14] and [買いWMAs2角度] > 0;

			SET @Min5Rate有効回数 = '買い(' + CONVERT(varchar, @Cnt) + ')';

		END
		ELSE IF @Swap判定 = '売り'
		BEGIN

			SELECT @Cnt = count(*)
			FROM [hstr].[tMin5]
			WHERE 通貨ペアNo = @通貨ペアNo and @StartDateDay1 <= [StartDate] and [StartDate] < @EndDateDay1 and
				[売りWMAs2] < [売りWMAs14] and [売りWMAs2角度] < 0;

			SET @Min5Rate有効回数 = '売り(' + CONVERT(varchar, @Cnt) + ')';

		END;


		-- Min1Rate判定

		IF @Swap判定 = '買い'
		BEGIN

			SELECT @Cnt = count(*)
			FROM [hstr].[tMin1]
			WHERE 通貨ペアNo = @通貨ペアNo and @StartDateDay1 <= [StartDate] and [StartDate] < @EndDateDay1 and
				[買いWMAs2] > [買いWMAs14] and [買いWMAs2角度] > 0;

			SET @Min1Rate有効回数 = '買い(' + CONVERT(varchar, @Cnt) + ')';

		END
		ELSE IF @Swap判定 = '売り'
		BEGIN

			SELECT @Cnt = count(*)
			FROM [hstr].[tMin1]
			WHERE 通貨ペアNo = @通貨ペアNo and @StartDateDay1 <= [StartDate] and [StartDate] < @EndDateDay1 and
				[売りWMAs2] < [売りWMAs14] and [売りWMAs2角度] < 0;

			SET @Min1Rate有効回数 = '売り(' + CONVERT(varchar, @Cnt) + ')';

		END;


		-- Min15BS発生回数

		SELECT @Cnt = count(*)
		FROM [hstr].[tBonusStage]
		WHERE 通貨ペアNo = @通貨ペアNo and @StartDateDay1 <= [日時] and [日時] < @EndDateDay1 and
			[BS判定_前] = 'B';

		SET @Min15BS発生回数 = 'BS(' + CONVERT(varchar, @Cnt) + ')';


		-- 1行の結果

		SET @評価 = @評価 + 
			CONVERT(varchar, @通貨ペアNo) + '\t' + @通貨ペア名 + '\t' + @Swap判定 + '\t' + 
			@月Rate判定 + '\t' + @週Rate判定 + '\t' + @日Rate判定 + '\t' + 
			@Hour1Rate有効回数 + '\t' + @Min30Rate有効回数 + '\t' + @Min15Rate有効回数 + '\t' + 
			@Min15BS発生回数 + '\t' + 
			@Min5Rate有効回数 + '\t' + @Min1Rate有効回数 + 
			'\r\n';

		SET @通貨ペアNo = @通貨ペアNo + 1;
	end;

	--select @評価
END
GO
/*
*/

