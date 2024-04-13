USE [RealA_FX]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [indi].[SP_WMA_Weekly_計算_n週前から今週まで]
	@back_Week int = -1
AS
BEGIN
	/*
	declare @back_Week int = -200
	*/

	declare @now	datetime = getdate();
	declare @通貨ペアNo tinyint;

	DECLARE @ThisWeek date;
	DECLARE @StartDate datetime;
	DECLARE @EndDate datetime;

	while @back_Week < 1
	begin

		--計算対象時間取得

		EXECUTE [cmn].[SP_GetThisWeek] @now, @back_Week, @ThisWeek OUTPUT, @StartDate OUTPUT, @EndDate OUTPUT;
		--select @now as now, @back_Week as back_Week, @StartDate as StartDate, @EndDate as EndDate


		--計算

		Set @通貨ペアNo = 0;

		while @通貨ペアNo < 44
		begin

			EXECUTE [indi].[SP_InsertIndicator_Weekly_WMA_S2のみ] @通貨ペアNo, @ThisWeek;

			Set @通貨ペアNo = @通貨ペアNo + 1;
		end;

		Set @back_Week = @back_Week + 1;
	end;

END

GO
