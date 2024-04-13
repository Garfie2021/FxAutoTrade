USE [RealA_FX]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[SP_Chkボーナスステージ開始_Rate判定_15m]
	@通貨ペアNo		tinyint,
	@売買モード		varchar(5),
	@now			datetime,
	@Rate差AVG倍数	float,			-- n倍 1.8倍か？
	@判定			tinyint	output	-- n倍 1.8倍か？
AS
BEGIN

	/*	
	declare @通貨ペアNo		tinyint = 12;
	declare @売買モード		varchar(5) = '買い';
	declare @now			datetime = '2014-03-06 22:30:00';
	declare @Rate差AVG倍数	float = 1.8;
	declare @判定			tinyint;
	*/

	if @売買モード = '買い'
	begin

		declare @EndDate datetime = @now;
		Set @EndDate = convert(varchar, YEAR(@EndDate)) + '-' + convert(varchar, MONTH(@EndDate))  + '-' + convert(varchar, DAY(@EndDate)) + 
			' ' + convert(varchar, DATEPART(hour, @EndDate)) + ':00:00';

		declare @StartDate datetime = @EndDate;
		if DATEPART(hour, @StartDate) <= 6
		begin
			Set @StartDate = DateAdd(dayofyear, -1, @StartDate);
		end
		Set @StartDate = convert(varchar, YEAR(@StartDate)) + '-' + convert(varchar, MONTH(@StartDate))  + '-' + convert(varchar, DAY(@StartDate)) + ' 6:00:00';

		declare @Rate差AVG	float = 0;
		SELECT @Rate差AVG = AVG(ABS([買い_始値] - [買い_終値]))
		FROM [dbo].[T_RateHistory_15m]
		where [通貨ペアNo] = @通貨ペアNo and @StartDate < [日時] and [日時] < @EndDate

		select @通貨ペアNo as 通貨ペアNo, @StartDate as StartDate, @EndDate as EndDate, @Rate差AVG as Rate差AVG

		DECLARE @2つ前_買い_始値 float;
		DECLARE @2つ前_買い_高値 float;
		DECLARE @2つ前_買い_終値 float;
		DECLARE @1つ前_買い_始値 float;
		DECLARE @1つ前_買い_高値 float;
		DECLARE @1つ前_買い_終値 float;
		DECLARE @今_買い_始値 float;
		DECLARE @今_買い_高値 float;
		DECLARE @今_買い_終値 float;

		SELECT TOP 3 [日時], [買い_始値], [買い_高値], [買い_終値]
		FROM [dbo].[T_RateHistory_15m]
		where 通貨ペアNo = @通貨ペアNo and [日時] <= DateAdd(MINUTE, -15, @now)
		order by [日時] desc

		DECLARE cursor_RateHistory_15m CURSOR FOR
		SELECT TOP 3 [買い_始値], [買い_高値], [買い_終値]
		FROM [dbo].[T_RateHistory_15m]
		where 通貨ペアNo = @通貨ペアNo and [日時] <= DateAdd(MINUTE, -15, @now)
		order by [日時] desc

		open cursor_RateHistory_15m;
	
		FETCH NEXT FROM cursor_RateHistory_15m INTO @今_買い_始値, @今_買い_高値, @今_買い_終値;
		FETCH NEXT FROM cursor_RateHistory_15m INTO @1つ前_買い_始値, @1つ前_買い_高値, @1つ前_買い_終値;
		FETCH NEXT FROM cursor_RateHistory_15m INTO @2つ前_買い_始値, @2つ前_買い_高値, @2つ前_買い_終値;

		CLOSE cursor_RateHistory_15m;
		DEALLOCATE cursor_RateHistory_15m;

			--select @1つ前_買い_始値 as _1つ前_買い_始値, @今_買い_終値 as 今_買い_終値

			DECLARE @直近のRate変動値 float = ABS(@2つ前_買い_始値 - @今_買い_終値);

			select @直近のRate変動値 as 直近のRate変動値, @Rate差AVG as Rate差AVG, @Rate差AVG * @Rate差AVG倍数 as [@Rate差AVG * @Rate差AVG倍数]

			if @直近のRate変動値 > @Rate差AVG * @Rate差AVG倍数
			begin
				Set @判定 = 1;	--ボーナスステージ
			end
			else
			begin
				Set @判定 = 0;	--ボーナスステージじゃない
			end

		select @判定 as 判定;



	end
	else
	begin

		Set @判定 = 0;	--ボーナスステージじゃない

	end


END

GO
