USE [RealA_FX]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [indi].[SP_WMA_Monthly_計算_n月前から今月まで]
	@back_Month int = -1
AS
BEGIN
	/*
	declare @back_Month int = -200
	*/

	declare @now	datetime = getdate();
	declare @通貨ペアNo tinyint;

	DECLARE @ThisMonth date;
	DECLARE @StartDate datetime;
	DECLARE @EndDate datetime;

	while @back_Month < 1
	begin

		--計算対象時間取得

		EXECUTE [cmn].[SP_GetThisMonth] @now, @back_Month, @ThisMonth OUTPUT, @StartDate OUTPUT, @EndDate OUTPUT;
		--select @now as now, @back_Month as back_Month, @StartDate as StartDate, @EndDate as EndDate


		--計算

		Set @通貨ペアNo = 0;

		while @通貨ペアNo < 44
		begin

			EXECUTE [indi].[SP_InsertIndicator_Monthly_WMA] @通貨ペアNo, @ThisMonth;

			Set @通貨ペアNo = @通貨ペアNo + 1;
		end;

		Set @back_Month = @back_Month + 1;
	end;

END

GO
