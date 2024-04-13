USE [DemoA_FX]
GO
/*
*/
DROP PROCEDURE [hltc].[SP_InsertデータCnt_Daily]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [hltc].[SP_InsertデータCnt_Daily]
	@back_Day int = -30
AS
BEGIN
	SET NOCOUNT ON;

	--DECLARE @back_Day int = -2

	DECLARE @now		Datetime = GETDATE();

	while @back_Day < 1
	begin

		declare @ThisDay date;
		DECLARE @StartDate datetime
		DECLARE @EndDate datetime
		EXECUTE [cmn].[SP_GetThisDay] @now, @back_Day, @ThisDay OUTPUT, @StartDate OUTPUT, @EndDate OUTPUT

		DECLARE @通貨ペアNo tinyint = 0
		while @通貨ペアNo < 44
		begin

			--select @ThisDay, @StartDate, @EndDate, @通貨ペアNo
			--select count(*) from [dbo].[T_RateHistory_15m] where 通貨ペアNo = @通貨ペアNo and StartDate <= 日時 and 日時 <= EndDate

			delete 
			--select *
			from [hltc].[T_データCnt_Daily]
			where  通貨ペアNo = @通貨ペアNo and [日時] = @ThisDay;


			Insert [hltc].[T_データCnt_Daily] (
				 [日時]
				,[通貨ペアNo]
				,[件数_1m]
				,[件数_5m]
				,[件数_15m]
				,[件数_30m]
				,[件数_1h]
				,[件数_1day]
				,[StartDate]
				,[EndDate]
			)
			Values
			(
				@ThisDay,
				@通貨ペアNo,
				0,
				(select count(*) from [dbo].[T_RateHistory_5m] where 通貨ペアNo = @通貨ペアNo and @StartDate <= 日時 and 日時 <= @EndDate),
				(select count(*) from [dbo].[T_RateHistory_15m] where 通貨ペアNo = @通貨ペアNo and @StartDate <= 日時 and 日時 <= @EndDate),
				(select count(*) from [dbo].[T_RateHistory_30m] where 通貨ペアNo = @通貨ペアNo and @StartDate <= 日時 and 日時 <= @EndDate),
				(select count(*) from [dbo].[T_RateHistory_Hourly] where 通貨ペアNo = @通貨ペアNo and @StartDate <= 日時 and 日時 <= @EndDate),
				(select count(*) from [dbo].[T_RateHistory_Daily] where 通貨ペアNo = @通貨ペアNo and @StartDate <= 日時 and 日時 <= @EndDate),
				@StartDate,
				@EndDate
			)

			Set @通貨ペアNo = @通貨ペアNo + 1;
		end;

		Set @back_Day = @back_Day + 1;
	end;

END
GO
/*
*/
