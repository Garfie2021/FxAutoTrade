USE [RealA_FX]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[SP_GetRate幅]
	@通貨ペアNo		tinyint,
	@now			datetime,
	@n日前まで対象	tinyint,	-- プラス値にしか対応していない
	@割合			float,
	@買い_Rate幅	float	output,
	@売り_Rate幅	float	output
AS
BEGIN

	/*
	*/

	declare @FromDate datetime = DATEADD(day, @n日前まで対象 * -1, @now);

	SELECT
		@買い_Rate幅 = (MAX(Rate_買い) - MIN(Rate_買い)), @売り_Rate幅 = (MAX(Rate_買い) - MIN(Rate_買い))
	FROM
		T_RateHistory
	WHERE
		(通貨ペア = @通貨ペアNo) AND (@FromDate <= [Date]) AND ([Date] <= @now);

	Set @買い_Rate幅 = (@買い_Rate幅 / @n日前まで対象) * @割合;
	Set @売り_Rate幅 = (@売り_Rate幅 / @n日前まで対象) * @割合;

	--select @危険Rate;

END


GO
