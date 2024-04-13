USE OANDA_DemoB
GO
/*
*/
DROP PROCEDURE [oanda].[sp通貨ペア別の売買スワップ]
GO
DROP PROCEDURE [oanda].[sp通貨ペア別の最新売買スワップ]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [oanda].[sp通貨ペア別の最新売買スワップ]
	@result	varchar(8000)	output
AS
BEGIN

	SET NOCOUNT ON;

	--declare @result	varchar(8000);

	SET @result = '通貨ペアNo\t通貨ペア名\t買いSwap\t売りSwap\tLastUpdate\r\n';

	declare cursor_Swap手動登録_Day1 cursor for
	SELECT [通貨ペアNo] as 通貨ペアNo, MAX([StartDate]) as StartDate
	FROM [swap].[tSwap手動登録_Day1]
	group by [通貨ペアNo]
	order by [通貨ペアNo];

	open cursor_Swap手動登録_Day1;

	declare @通貨ペアNo	tinyint;
	declare @通貨ペア名	varchar(10);
	declare @StartDate	datetime;
	declare @買いSwap	float;
	declare @売りSwap	float;

	FETCH NEXT FROM cursor_Swap手動登録_Day1 INTO @通貨ペアNo, @StartDate;

	WHILE @@FETCH_STATUS = 0
	BEGIN

		SELECT @通貨ペア名 = [ペア名]
		FROM [cmn].[t通貨ペアMst]
		WHERE [No] = @通貨ペアNo;

		SELECT @買いSwap = [買いSwap], @売りSwap = [売りSwap]
		FROM [swap].[tSwap手動登録_Day1]
		WHERE [通貨ペアNo] = @通貨ペアNo AND [StartDate] = @StartDate;

		SET @result += CONVERT(varchar, @通貨ペアNo) + '\t';
		SET @result += @通貨ペア名 + '\t';
		SET @result += CONVERT(varchar, @買いSwap) + '\t';
		SET @result += CONVERT(varchar, @売りSwap) + '\t';
		SET @result += CONVERT(varchar, @StartDate) + '\t';

		IF @買いSwap < 0 AND @売りSwap < 0
		BEGIN
			SET @result += '売買ともにマイナス';
		END
		ELSE IF @買いSwap > 0 AND @売りSwap > 0
		BEGIN
			SET @result += '売買ともにプラス';
		END;
		
		SET @result += '\r\n';

		FETCH NEXT FROM cursor_Swap手動登録_Day1 INTO @通貨ペアNo, @StartDate;
	END

	CLOSE cursor_Swap手動登録_Day1;
	DEALLOCATE cursor_Swap手動登録_Day1;

	print @result;
END
GO
/*
*/
