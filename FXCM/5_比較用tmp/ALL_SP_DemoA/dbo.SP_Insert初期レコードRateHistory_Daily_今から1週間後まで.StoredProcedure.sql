USE [RealA_FX]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[SP_Insert初期レコードRateHistory_Daily_今から1週間後まで]
	@口座種別	varchar(10)		-- FX Kabu XAU
AS
BEGIN

	declare @cnt int;
	declare @通貨ペアNo int;
	DECLARE @StartDay datetime
	DECLARE @EndDay datetime
	DECLARE @時間外	tinyint;

	DECLARE @now date = GetDate();
	DECLARE @ThisWeek date;
	DECLARE @StartDate datetime;
	DECLARE @EndDate datetime;
	EXECUTE [cmn].[SP_GetThisWeek] @now, 1, @ThisWeek OUTPUT, @StartDate OUTPUT, @EndDate OUTPUT;

	while @StartDate < @EndDate
	begin
		
		EXECUTE [cmn].[SP_GetThisDay] @StartDate, 0, @StartDay OUTPUT, @EndDay OUTPUT
		EXECUTE [cmn].[SP_ChkTrade時間外] @StartDay, @時間外 OUTPUT;

		if @時間外 = 1
		begin
			--取引時間外
			Set @StartDate = DateAdd(day, 1, @StartDay);
			continue;
		end;

		Set @通貨ペアNo = 0;
		while @通貨ペアNo < 44
		begin

			select @cnt = count(*)
			from [dbo].[T_通貨ペアMst]
			where [No] = @通貨ペアNo and 口座種別 = @口座種別;

			if @cnt < 1
			begin
				--対象外通貨
				continue;
			end;

			select @cnt = count(*)
			from [dbo].[T_RateHistory_Daily]
			where 通貨ペアNo = @通貨ペアNo and 日時 = @StartDay;

			if @cnt < 1
			begin
				Insert [dbo].[T_RateHistory_Daily] ([通貨ペアNo], [日時]) Values (@通貨ペアNo, @StartDay);
			end;

			Set @通貨ペアNo = @通貨ペアNo + 1;
		end;

		Set @StartDate = DateAdd(day, 1, @StartDay);
	end;

END

GO
