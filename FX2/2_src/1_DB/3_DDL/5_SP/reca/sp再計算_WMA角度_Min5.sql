USE [FX2_Demo]
GO

DROP PROCEDURE [reca].[sp再計算_WMA角度_Min5]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [reca].[sp再計算_WMA角度_Min5]
	@back_Min5	int = -2,		-- マイナス値にしか対応していない
	@now		Datetime
AS
BEGIN

	DECLARE @StartDate	datetime;
	DECLARE @EndDate	datetime;

	DECLARE @買いWMAs2		float;
	DECLARE @売りWMAs2		float;
	DECLARE @買いWMAs2角度	float;
	DECLARE @売りWMAs2角度	float;

	DECLARE @通貨ペアNo tinyint = 0;

	while @back_Min5 < 1
	begin

		--処理対象期間取得
		EXECUTE [cmn].[spGetTerm_Min5] @now, @back_Min5, @StartDate OUTPUT, @EndDate OUTPUT;

		SET @通貨ペアNo = 0;
		while @通貨ペアNo < 44
		begin

			SELECT TOP 1 @買いWMAs2 = [買いWMAs2], @売りWMAs2 = [売りWMAs2]
			FROM [rate].[tRateHistory_Min5]
			where 通貨ペアNo = @通貨ペアNo and [StartDate] = @StartDate
			order by [StartDate] desc;

			EXECUTE [rate].[spCulcWMAs2角度_Min5] @通貨ペアNo, @StartDate, @買いWMAs2, @売りWMAs2, @買いWMAs2角度 OUTPUT, @売りWMAs2角度 OUTPUT;

			UPDATE [rate].[tRateHistory_Min5]
			SET
				買いWMAs2角度 = @買いWMAs2角度,
				売りWMAs2角度 = @売りWMAs2角度,
				[更新日時] = @now
			where 通貨ペアNo = @通貨ペアNo and [StartDate] = @StartDate;

			Set @通貨ペアNo = @通貨ペアNo + 1;
		end;

		Set @back_Min5 = @back_Min5 + 1;
	end;

END

GO


