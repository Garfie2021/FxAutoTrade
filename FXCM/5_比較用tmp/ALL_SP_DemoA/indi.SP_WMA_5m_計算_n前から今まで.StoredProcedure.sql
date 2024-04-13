USE [RealA_FX]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [indi].[SP_WMA_5m_計算_n前から今まで]
	@back_5m int = -1
AS
BEGIN
	/*
	declare @back_5m int = -200
	*/

	declare @now	datetime = getdate();
	declare @通貨ペアNo tinyint;

	DECLARE @StartDate datetime;
	DECLARE @EndDate datetime;

	while @back_5m < 1
	begin

		--計算対象時間取得

		EXECUTE [cmn].[SP_GetThis5m] @now, @back_5m, @StartDate OUTPUT, @EndDate OUTPUT;
		--select @now as now, @back_5m as back_5m, @StartDate as StartDate, @EndDate as EndDate


		--取引時間外チェック

		declare @時間外 tinyint = 1;
		EXECUTE [cmn].[SP_ChkTrade時間外] @StartDate, @時間外 OUTPUT;

		if @時間外 = 1
		begin
			Set @back_5m = @back_5m + 1;
			continue;
		end;


		--計算

		Set @通貨ペアNo = 0;

		while @通貨ペアNo < 44
		begin

			EXECUTE [indi].[SP_InsertIndicator_5m_WMA_S2のみ] @通貨ペアNo, @StartDate;

			Set @通貨ペアNo = @通貨ペアNo + 1;
		end;

		Set @back_5m = @back_5m + 1;
	end;

END

GO
