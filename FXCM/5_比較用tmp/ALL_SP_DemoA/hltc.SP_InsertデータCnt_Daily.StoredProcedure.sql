USE [RealA_FX]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [hltc].[SP_InsertデータCnt_Daily]
	@back_Day int = -1
AS
BEGIN
	SET NOCOUNT ON;

	--DECLARE @back_Day int = -2


	while @back_Day < 1
	begin

		DECLARE @now date = DATEADD(DAY, @back_Day, GETDATE());
				
		DECLARE @StartDate datetime = convert(varchar, YEAR(@now)) + '/' + convert(varchar, MONTH(@now)) + '/' + convert(varchar, DAY(@now)) + ' 6:00:00';		
		DECLARE @EndDate datetime = DATEADD(DAY, 1, @StartDate);

		--select @now, @StartDate, @EndDate
		--select count(*) from [dbo].[T_RateHistory_15m] where 通貨ペアNo = @通貨ペアNo and StartDate <= 日時 and 日時 <= EndDate

		DECLARE @Cnt datetime = 0;

		select @Cnt = Count(*)
		from [hltc].[T_データCnt_Daily]
		where  [日時] = @now;

		if @Cnt < 1
		begin
			INSERT INTO [hltc].[T_データCnt_Daily] ([日時]) VALUES (@now);
		end;

		UPDATE [hltc].[T_データCnt_Daily]
		SET
			[件数_RateHistory_1m] = (select count(*) from [dbo].[T_RateHistory_1m] where @StartDate <= [StartDate] and [StartDate] < @EndDate),
			[件数_RateHistory_5m] = (select count(*) from [dbo].[T_RateHistory_5m] where @StartDate <= [StartDate] and [StartDate] < @EndDate),
			[件数_RateHistory_15m] = (select count(*) from [dbo].[T_RateHistory_15m] where @StartDate <= [StartDate] and [StartDate] < @EndDate),
			[件数_RateHistory_30m] = (select count(*) from [dbo].[T_RateHistory_30m] where @StartDate <= [StartDate] and [StartDate] < @EndDate),
			[件数_RateHistory_1h] = (select count(*) from [dbo].[T_RateHistory_Hourly] where @StartDate <= [StartDate] and [StartDate] < @EndDate),
			[件数_RateHistory_6h] = (select count(*) from [dbo].[T_RateHistory_6h] where @StartDate <= [StartDate] and [StartDate] < @EndDate),
			[件数_RateHistory_Day] = (select count(*) from [dbo].[T_RateHistory_Daily] where @StartDate <= [StartDate] and [StartDate] < @EndDate),
			[件数_Indicator_1m] = (select count(*) from [indi].[T_Indicator_1m] where @StartDate <= [日時] and [日時] < @EndDate),
			[件数_Indicator_5m] = (select count(*) from [indi].[T_Indicator_5m] where @StartDate <= [日時] and [日時] < @EndDate),
			[件数_Indicator_15m] = (select count(*) from [indi].[T_Indicator_15m] where @StartDate <= [日時] and [日時] < @EndDate),
			[件数_Indicator_30m] = (select count(*) from [indi].[T_Indicator_30m] where @StartDate <= [日時] and [日時] < @EndDate),
			[件数_Indicator_1h] = (select count(*) from [indi].[T_Indicator_1h] where @StartDate <= [日時] and [日時] < @EndDate),
			[件数_Indicator_6h] = (select count(*) from [indi].[T_Indicator_6h] where @StartDate <= [日時] and [日時] < @EndDate),
			[件数_Indicator_Day] = (select count(*) from [indi].[T_Indicator_Daily] where @StartDate <= [日時] and [日時] < @EndDate),

			--[件数_RateHistory_1m] = (select count(*) from [acv].[T_RateHistory_1m_Past] where @StartDate <= [StartDate] and [StartDate] < @EndDate),
			--[件数_RateHistory_5m] = (select count(*) from [acv].[T_RateHistory_5m_Past] where @StartDate <= [StartDate] and [StartDate] < @EndDate),
			--[件数_RateHistory_15m] = (select count(*) from [acv].[T_RateHistory_15m_Past] where @StartDate <= [StartDate] and [StartDate] < @EndDate),
			--[件数_RateHistory_30m] = (select count(*) from [acv].[T_RateHistory_30m_Past] where @StartDate <= [StartDate] and [StartDate] < @EndDate),
			--[件数_RateHistory_1h] = (select count(*) from [acv].[T_RateHistory_Hourly_Past] where @StartDate <= [StartDate] and [StartDate] < @EndDate),
			--[件数_RateHistory_6h] = (select count(*) from [acv].[T_RateHistory_6h_Past] where @StartDate <= [StartDate] and [StartDate] < @EndDate),
			--[件数_RateHistory_Day] = (select count(*) from [acv].[T_RateHistory_Daily_Past] where @StartDate <= [StartDate] and [StartDate] < @EndDate),
			--[件数_Indicator_1m] = (select count(*) from [acv].[T_Indicator_1m_Past] where @StartDate <= [日時] and [日時] < @EndDate),
			--[件数_Indicator_5m] = (select count(*) from [acv].[T_Indicator_5m_Past] where @StartDate <= [日時] and [日時] < @EndDate),
			--[件数_Indicator_15m] = (select count(*) from [acv].[T_Indicator_15m_Past] where @StartDate <= [日時] and [日時] < @EndDate),
			--[件数_Indicator_30m] = (select count(*) from [acv].[T_Indicator_30m_Past] where @StartDate <= [日時] and [日時] < @EndDate),
			--[件数_Indicator_1h] = (select count(*) from [acv].[T_Indicator_1h_Past] where @StartDate <= [日時] and [日時] < @EndDate),
			--[件数_Indicator_6h] = (select count(*) from [acv].[T_Indicator_6h_Past] where @StartDate <= [日時] and [日時] < @EndDate),
			--[件数_Indicator_Day] = (select count(*) from [acv].[T_Indicator_Daily_Past] where [日時] = @now),
			[StartDate] = @StartDate,
			[EndDate] = @EndDate
		WHERE [日時] = @now;

		Set @back_Day = @back_Day + 1;
	end;

END

GO
