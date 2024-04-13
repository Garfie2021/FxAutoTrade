USE [RealA_FX]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [indi].[SP_WMA_6h_計算_n日前から今日まで]
	@back_6h int = -1
AS
BEGIN
	/*
	declare @back_6h int = -20
	*/

	declare @now	datetime = getdate();
	declare @通貨ペアNo tinyint;

	DECLARE @StartDate datetime;
	DECLARE @EndDate datetime;

	while @back_6h < 1
	begin

		--計算対象時間取得

		EXECUTE [cmn].[SP_GetThis6h] @now, @back_6h, @StartDate OUTPUT, @EndDate OUTPUT;

		--取引時間外チェック

		declare @時間外 tinyint = 1;
		EXECUTE [cmn].[SP_ChkTrade時間外] @StartDate, @時間外 OUTPUT;

		if @時間外 = 1
		begin
			Set @back_6h = @back_6h + 1;
			continue;
		end;

		--select @now as now, @back_6h as back_6h, @StartDate as StartDate, @EndDate as EndDate

		--計算

		Set @通貨ペアNo = 0;

		while @通貨ペアNo < 44
		begin

			EXECUTE [indi].[SP_InsertIndicator_6h_WMA_S2のみ] @通貨ペアNo, @StartDate;

			Set @通貨ペアNo = @通貨ペアNo + 1;
		end;
		/*
		*/
		Set @back_6h = @back_6h + 1;
	end;

END

GO
