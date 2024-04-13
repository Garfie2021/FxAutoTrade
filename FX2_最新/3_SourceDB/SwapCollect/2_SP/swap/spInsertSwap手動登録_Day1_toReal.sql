USE SwapCollect
GO
/*
*/
DROP PROCEDURE [swap].[spInsertSwap手動登録_Day1_toReal]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- 日次で実行
CREATE PROCEDURE [swap].[spInsertSwap手動登録_Day1_toReal]
AS
BEGIN

	SET NOCOUNT ON;

	declare @now datetime = GETDATE();

	declare cursor_t通貨ペアMst cursor for
	SELECT [No], [ペア名_OANDA] 
	FROM [OANDA_RealA].[cmn].[t通貨ペアMst];

	open cursor_t通貨ペアMst;

	declare @No tinyint;
	declare @ペア名_OANDA varchar(10);

	FETCH NEXT FROM cursor_t通貨ペアMst INTO @No, @ペア名_OANDA;

	WHILE @@FETCH_STATUS = 0
	BEGIN

		declare @LastDate datetime;

		SELECT TOP 1 @LastDate = StartDate
		FROM [OANDA_RealA].[swap].[tSwap手動登録_Day1]
		WHERE 通貨ペアNo = @No
		ORDER BY StartDate DESC;


		INSERT INTO [OANDA_RealA].[swap].[tSwap手動登録_Day1](
			[通貨ペアNo],
			[StartDate],
			[買いSwap],
			[売りSwap],
			[登録日時])
		SELECT 
		 	@No,
			t1.[time], 
			t1.[買いSwap],
			t2.[売りSwap],
			@now
		FROM (
			SELECT [time], [instrument], [interest] as 買いSwap
			FROM [SwapCollect].[oanda].[tTransaction]
			where [口座No] = 1 AND [type] = 'DAILY_INTEREST' AND [instrument] = @ペア名_OANDA AND [time] > @LastDate
		) as t1 
		INNER JOIN 
		(
			SELECT [time], [instrument], [interest] as 売りSwap
			FROM [SwapCollect].[oanda].[tTransaction]
			where [口座No] = 3 AND [type] = 'DAILY_INTEREST' AND [instrument] = @ペア名_OANDA AND [time] > @LastDate
		) as t2
		ON t1.[time] = t2.[time] AND t1.[instrument] = t2.[instrument];


		INSERT INTO [OANDA_RealA].[swap].[tSwap手動登録_Day1](
			[通貨ペアNo],
			[StartDate],
			[買いSwap],
			[売りSwap],
			[登録日時])
		SELECT 
		 	@No,
			t1.[time], 
			t1.[買いSwap],
			t2.[売りSwap],
			@now
		FROM (
			SELECT [time], [instrument], [interest] as 買いSwap
			FROM [SwapCollect].[oanda].[tTransaction]
			where [口座No] = 2 AND [type] = 'DAILY_INTEREST' AND [instrument] = @ペア名_OANDA AND [time] > @LastDate
		) as t1 
		INNER JOIN 
		(
			SELECT [time], [instrument], [interest] as 売りSwap
			FROM [SwapCollect].[oanda].[tTransaction]
			where [口座No] = 4 AND [type] = 'DAILY_INTEREST' AND [instrument] = @ペア名_OANDA AND [time] > @LastDate
		) as t2
		ON t1.[time] = t2.[time] AND t1.[instrument] = t2.[instrument];


		FETCH NEXT FROM cursor_t通貨ペアMst INTO @No, @ペア名_OANDA;
	END

	CLOSE cursor_t通貨ペアMst;
	DEALLOCATE cursor_t通貨ペアMst;

END
GO
/*
*/
