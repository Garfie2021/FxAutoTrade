USE OANDA_DemoB
GO
/*
*/
DROP PROCEDURE [oanda].[sp注文可能通貨ペア確認]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [oanda].[sp注文可能通貨ペア確認]
	@result	varchar(8000)	output
AS
BEGIN

	SET NOCOUNT ON;

	--declare @result	varchar(8000);


	SET @result = '通貨ペアNo\t通貨ペア名\tCount_tSwap手動登録_Day1\tDiffDate_tMin15\tDiffDate_tMonth1\t注文可不可\r\n';

	DECLARE @通貨ペアNo tinyint = 0;
	DECLARE @通貨ペアNoMax tinyint = (SELECT MAX(No) from [cmn].[t通貨ペアMst]);

	DECLARE @cnt tinyint = 0;
	WHILE @通貨ペアNo <= @通貨ペアNoMax
	begin

		SELECT @cnt = COUNT([No]) from [cmn].[t通貨ペアMst] WHERE [No] = @通貨ペアNo;

		IF @cnt < 1
		BEGIN
			Set @通貨ペアNo = @通貨ペアNo + 1;
			CONTINUE;	-- OANDAには無い通貨ペア。
		END;

		--print CONVERT(varchar, @通貨ペアNo) + '/' + CONVERT(varchar, @通貨ペアNoMax) + '/' + CONVERT(varchar, LEN(@result));

		SET @result += CONVERT(varchar, @通貨ペアNo) + '\t';
		SET @result += (SELECT ペア名 from [cmn].[t通貨ペアMst] WHERE [No] = @通貨ペアNo) + '\t';

		DECLARE @Count_tSwap手動登録_Day1 int = (SELECT COUNT(通貨ペアNo) FROM [swap].[tSwap手動登録_Day1] WHERE 通貨ペアNo = @通貨ペアNo);
		DECLARE @DiffDate_tMin15 int = (SELECT DATEDIFF(MONTH, MIN(StartDate), MAX(StartDate)) FROM [hstr].[tMin15] WHERE 通貨ペアNo = @通貨ペアNo);
		DECLARE @DiffDate_tMonth1 int = (SELECT DATEDIFF(MONTH, MIN(StartDate), MAX(StartDate)) FROM [hstr].[tMonth1] WHERE 通貨ペアNo = @通貨ペアNo);

		SET @result += CONVERT(varchar, @Count_tSwap手動登録_Day1) + '\t';
		SET @result += CONVERT(varchar, @DiffDate_tMin15) + '\t';
		SET @result += CONVERT(varchar, @DiffDate_tMonth1) + '\t';

		IF @Count_tSwap手動登録_Day1 > 0 AND @DiffDate_tMin15 >= 2 AND @DiffDate_tMonth1 >= 14
		BEGIN
			SET @result += '可\t';
		END
		ELSE
		BEGIN
			SET @result += '不可\t';
		END;

		SET @result += '\r\n';

		Set @通貨ペアNo = @通貨ペアNo + 1;
	end;

	--print @result;
END
GO
/*
*/
