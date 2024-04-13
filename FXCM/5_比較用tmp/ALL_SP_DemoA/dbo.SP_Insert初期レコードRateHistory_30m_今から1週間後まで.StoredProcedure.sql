USE [RealA_FX]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[SP_Insert初期レコードRateHistory_30m_今から1週間後まで]
	@口座種別	varchar(10)		-- FX Kabu XAU
AS
BEGIN

	declare @cnt int;
	declare @通貨ペアNo int;
	DECLARE @Start30m datetime
	DECLARE @End30m datetime
	DECLARE @時間外	tinyint;

	DECLARE @now date = GetDate();
	DECLARE @ThisWeek date;
	DECLARE @StartDate datetime;
	DECLARE @EndDate datetime;
	EXECUTE [cmn].[SP_GetThisWeek] @now, 1, @ThisWeek OUTPUT, @StartDate OUTPUT, @EndDate OUTPUT;

	while @StartDate < @EndDate
	begin
		
		EXECUTE [cmn].[SP_GetThis30m] @StartDate, 0, @Start30m OUTPUT, @End30m OUTPUT
		EXECUTE [cmn].[SP_ChkTrade時間外] @Start30m, @時間外 OUTPUT;

		if @時間外 = 1
		begin
			--取引時間外
			Set @StartDate = DateAdd(minute, 30, @Start30m);
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
			from [dbo].[T_RateHistory_30m]
			where 通貨ペアNo = @通貨ペアNo and 日時 = @Start30m;

			if @cnt < 1
			begin
				Insert [dbo].[T_RateHistory_30m] ([通貨ペアNo], [日時]) Values (@通貨ペアNo, @Start30m);
			end;

			Set @通貨ペアNo = @通貨ペアNo + 1;
		end;

		Set @StartDate = DateAdd(minute, 30, @Start30m);
	end;

END

GO
