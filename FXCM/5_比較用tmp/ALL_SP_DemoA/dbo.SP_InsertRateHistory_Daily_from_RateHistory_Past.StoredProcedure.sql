USE [RealA_FX]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[SP_InsertRateHistory_Daily_from_RateHistory_Past]
AS
BEGIN

	declare @通貨ペアNo	tinyint = 0

	declare @MinDate date;
	declare @MaxDate date;

	while (@通貨ペアNo < 44)
	begin

		select @MinDate = MIN(日時), @MaxDate = MAX(日時)
		from acv.T_RateHistory_Past
		where 通貨ペアNo = @通貨ペアNo;

		declare @StartDate datetime = convert(varchar, YEAR(@MinDate)) + '/' + convert(varchar, MONTH(@MinDate))  + '/' + convert(varchar, DAY(@MinDate)) + ' 6:00:00';
		declare @EndDate datetime = convert(varchar, YEAR(@MaxDate)) + '/' + convert(varchar, MONTH(@MaxDate))  + '/' + convert(varchar, DAY(@MaxDate)) + ' 6:00:00';

		declare @StartDate_Add1Day datetime = DATEADD(day, 1, @StartDate);
		declare @Cnt int;

		while (@StartDate < @EndDate)
		begin

			Set @StartDate_Add1Day = DATEADD(day, 1, @StartDate);

			select @Cnt = COUNT(*)
			from acv.T_RateHistory_Past
			where 通貨ペアNo = @通貨ペアNo and @StartDate <= 日時 and 日時 < @StartDate_Add1Day;

			--select @通貨ペアNo as 通貨ペアNo, @StartDate as StartDate, @StartDate_Add1Day as StartDate_Add1Day, @Cnt as Cnt

			if @Cnt < 1
			begin
				continue;
			end;

			delete from [dbo].[T_RateHistory_Daily]
			where [通貨ペアNo] = @通貨ペアNo and [日時] = @StartDate

			Insert [dbo].[T_RateHistory_Daily] (
				 [通貨ペアNo]
				,[日時]
				,[買い_始値]
				,[買い_高値]
				,[買い_安値]
				,[買い_終値]
				,[売り_始値]
				,[売り_高値]
				,[売り_安値]
				,[売り_終値]
				,[買いSwap_始値]
				,[買いSwap_高値]
				,[買いSwap_安値]
				,[買いSwap_終値]
				,[売りSwap_始値]
				,[売りSwap_高値]
				,[売りSwap_安値]
				,[売りSwap_終値]
				,[StartDate]
				,[EndDate]
			)
			select
				通貨ペアNo, 
				@StartDate as 日時,
				(
					select top 1 Rate_買い from acv.T_RateHistory_Past
					where 通貨ペアNo = a.通貨ペアNo and  @StartDate <= 日時 and 日時 < @StartDate_Add1Day
					order by 日時
				) as 買い_始値,
				MAX(Rate_買い) as 買い_高値, 
				MIN(Rate_買い) as 買い_安値, 
				(
					select top 1 Rate_買い from acv.T_RateHistory_Past
					where 通貨ペアNo = a.通貨ペアNo and  @StartDate <= 日時 and 日時 < @StartDate_Add1Day
					order by 日時 desc
				) as 買い_終値,
				(
					select top 1 Rate_売り from acv.T_RateHistory_Past
					where 通貨ペアNo = a.通貨ペアNo and  @StartDate <= 日時 and 日時 < @StartDate_Add1Day
					order by 日時
				) as 売り_始値,
				MAX(Rate_売り) as 売り_高値, 
				MIN(Rate_売り) as 売り_安値, 
				(
					select top 1 Rate_売り from acv.T_RateHistory_Past
					where 通貨ペアNo = a.通貨ペアNo and  @StartDate <= 日時 and 日時 < @StartDate_Add1Day
					order by 日時 desc
				) as 売り_終値,
				(
					select top 1 Swap_買い from acv.T_RateHistory_Past
					where 通貨ペアNo = a.通貨ペアNo and  @StartDate <= 日時 and 日時 < @StartDate_Add1Day
					order by 日時
				) as 買いSwap_始値,
				MAX(Swap_買い) as 買い_高値, 
				MIN(Swap_買い) as 買い_安値, 
				(
					select top 1 Swap_買い from acv.T_RateHistory_Past
					where 通貨ペアNo = a.通貨ペアNo and  @StartDate <= 日時 and 日時 < @StartDate_Add1Day
					order by 日時 desc
				) as 買いSwap_終値,
				(
					select top 1 Swap_売り from acv.T_RateHistory_Past
					where 通貨ペアNo = a.通貨ペアNo and  @StartDate <= 日時 and 日時 < @StartDate_Add1Day
					order by 日時
				) as 売りSwap_始値,
				MAX(Swap_売り) as 売り_高値, 
				MIN(Swap_売り) as 売り_安値, 
				(
					select top 1 Swap_売り from acv.T_RateHistory_Past
					where 通貨ペアNo = a.通貨ペアNo and  @StartDate <= 日時 and 日時 < @StartDate_Add1Day
					order by 日時 desc
				) as 売りSwap_終値,
				@StartDate as StartDate,
				@EndDate as EndDate
			from acv.T_RateHistory_Past as a
			where 通貨ペアNo = @通貨ペアNo and @StartDate <= 日時 and 日時 < @StartDate_Add1Day
			group by 通貨ペアNo
			--order by 通貨ペア
			;

			Set @StartDate = @StartDate_Add1Day;
		end;

		Set @通貨ペアNo = @通貨ペアNo + 1;
	end;


END


GO
