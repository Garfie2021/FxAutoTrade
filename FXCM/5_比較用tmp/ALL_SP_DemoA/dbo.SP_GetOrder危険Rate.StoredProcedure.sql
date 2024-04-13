USE [RealA_FX]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[SP_GetOrder危険Rate]
	@通貨ペアNo		tinyint,
	@売買モード		varchar(2),
	@現在日時		datetime,	-- シュミレーションを行う場合は、この日付を変更する
	@割合			float,		-- 1 ～ 0.01
	@n分以内		tinyint,	-- +値にしか対応していない
	@危険Rate		float	output
AS
BEGIN

	/*
	declare @通貨ペアNo		tinyint = 12
	declare @売買モード		varchar(2) = 'B'
	declare @現在日時		datetime = getdate()
	declare @割合			float = 0.25
	declare @危険Rate		float = 0
	*/

	declare @15分前 datetime = DATEADD(minute, @n分以内 * -5, @現在日時);

	declare @MaxRate float = 0;
	declare @MinRate float = 0;

	if @売買モード = 'B'
	begin
		SELECT @MaxRate = MAX([Rate_買い]), @MinRate = MIN([Rate_買い])
		FROM [dbo].[T_RateHistory]
		where  [通貨ペア] = @通貨ペアNo and @15分前 < [Date] and [Date] < @現在日時
	end
	else
	begin
		SELECT @MaxRate = MAX([Rate_売り]), @MinRate = MIN([Rate_売り])
		FROM [dbo].[T_RateHistory]
		where  [通貨ペア] = @通貨ペアNo and @15分前 < [Date] and [Date] < @現在日時
	end

	declare @MaxMinRate差 float = (@MaxRate - @MinRate) * @割合;

	if @売買モード = 'B'
	begin
		Set @危険Rate = @MaxRate - @MaxMinRate差;
	end
	else
	begin
		Set @危険Rate = @MinRate + @MaxMinRate差;
	end


	--select @危険Rate;

END


GO
