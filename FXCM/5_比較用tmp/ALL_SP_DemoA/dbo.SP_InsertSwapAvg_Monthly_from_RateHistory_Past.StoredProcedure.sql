USE [RealA_FX]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[SP_InsertSwapAvg_Monthly_from_RateHistory_Past]
AS
BEGIN

	declare @通貨ペアNo	tinyint = 0;
	declare @Min年月日 datetime;
	declare @Min年月日2 datetime;
	declare @Max年月日 datetime;
	declare @年 smallint;
	declare @月 tinyint;

	while @通貨ペアNo < 44
	begin

		select @Min年月日 = MIN(日時), @Max年月日 = MAX(日時)
		from acv.T_RateHistory_Past
		Where 通貨ペアNo = @通貨ペアNo

		Set @Min年月日 = CONVERT(varchar, YEAR(@Min年月日)) + '/' + convert(varchar, MONTH(@Min年月日))  + '/01 0:00:00';
		Set @Min年月日2 = DATEADD(month, +1, @Min年月日);

		Set @Max年月日 = CONVERT(varchar, YEAR(@Max年月日)) + '/' + convert(varchar, MONTH(@Max年月日))  + '/01 0:00:00';
		Set @Max年月日 = DATEADD(month, +1, @Max年月日);

		while @Min年月日 < @Max年月日
		begin
			--select @通貨ペアNo as 通貨ペアNo, @Min年月日 as Min年月日, @Min年月日2 as Min年月日2

			DELETE FROM [dbo].[T_SwapAvg_Monthly]
			WHERE 通貨ペアNo = @通貨ペアNo and [年] = YEAR(@Min年月日) and [月] = MONTH(@Min年月日)

			INSERT INTO [dbo].[T_SwapAvg_Monthly]
			(
				[通貨ペアNo],
				[年],
				[月],
				[AvgSwap_買い],
				[AvgSwap_売り]
			)
			SELECT @通貨ペアNo as 通貨ペアNo, YEAR(@Min年月日) as 年, MONTH(@Min年月日) as 月, AVG([Swap_買い]) as AvgSwap_買い, AVG([Swap_売り]) as AvgSwap_売り
			FROM [acv].[T_RateHistory_Past]
			WHERE [通貨ペアNo] = @通貨ペアNo and @Min年月日 <= [日時] and [日時] < @Min年月日2

			Set @Min年月日 = @Min年月日2;
			Set @Min年月日2 = DATEADD(month, +1, @Min年月日2);
		end

		Set @通貨ペアNo = @通貨ペアNo + 1;
	end

END


GO
