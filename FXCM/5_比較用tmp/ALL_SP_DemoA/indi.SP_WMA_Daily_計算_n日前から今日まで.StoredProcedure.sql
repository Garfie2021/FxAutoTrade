USE [RealA_FX]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [indi].[SP_WMA_Daily_計算_n日前から今日まで]
	@back_Day int = -1
AS
BEGIN

	/*
	declare @back_Day int = -200
	*/

	declare @now	datetime = getdate();
	declare @通貨ペアNo tinyint;

	DECLARE @ThisDay date;
	DECLARE @StartDate datetime;
	DECLARE @EndDate datetime;

	while @back_Day < 1
	begin

		--計算対象時間取得

		EXECUTE [cmn].[SP_GetThisDay] @now, @back_Day, @ThisDay OUTPUT, @StartDate OUTPUT, @EndDate OUTPUT;
		--select @now as now, @back_Day as back_Day, @StartDate as StartDate, @EndDate as EndDate


		--取引時間外チェック

		declare @時間外 tinyint = 1;
		EXECUTE [cmn].[SP_ChkTrade時間外] @StartDate, @時間外 OUTPUT;

		if @時間外 = 1
		begin
			Set @back_Day = @back_Day + 1;
			continue;
		end;


		--計算

		Set @通貨ペアNo = 0;

		while @通貨ペアNo < 44
		begin

			EXECUTE [indi].[SP_InsertIndicator_Daily_WMA_S2のみ] @通貨ペアNo, @ThisDay;

			Set @通貨ペアNo = @通貨ペアNo + 1;
		end;

		Set @back_Day = @back_Day + 1;
	end;

END

GO
