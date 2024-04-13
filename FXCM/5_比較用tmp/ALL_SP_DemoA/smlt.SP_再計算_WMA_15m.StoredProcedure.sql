USE [RealA_FX]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [smlt].[SP_再計算_WMA_15m]
	@通貨ペアNo		tinyint,
	@StartDate			datetime,
	@back_Minute	int		-- マイナス値にしか対応していない
AS
BEGIN

	/*
	declare @通貨ペアNo		tinyint = 12;
	declare @now			datetime = '2014/03/06 22:00:00';
	declare @back_Minute	int		-- マイナス値にしか対応していない
	*/

	declare @This15m datetime;
	declare @WMA float;


	EXECUTE [smlt].[SP_CulcWMA_15m] @通貨ペアNo, @StartDate, @back_Minute, @This15m OUTPUT, @WMA OUTPUT

	--select @通貨ペアNo, @back_Month, @ThisMonth, @WMA

	EXECUTE [smlt].[SP_InsertIndicator_15m_WMA] @通貨ペアNo, @This15m, @WMA, 0


END


GO
