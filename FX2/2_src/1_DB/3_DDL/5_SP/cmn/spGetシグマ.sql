USE [FX2_Demo]
GO

DROP PROCEDURE [cmn].[spGetシグマ]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [cmn].[spGetシグマ]
	@WMA角度		float,
	@WMA角度AVG		float,
	@WMA角度STDEV	float,
	@WMA角度シグマ	float	output
AS
BEGIN

	-- 過去2ヵ月間の角度平均の3σ
	--SELECT	@買いWMA角度_BonusStage閾値 = AVG([買いWMA角度]) + (STDEV([買いWMA角度]) * 3),
	--		@売りWMA角度_BonusStage閾値 = AVG([売りWMA角度]) - (STDEV([売りWMA角度]) * 3)
	--from [rate].[tRateHistory_Min15]
	--where 通貨ペアNo = @通貨ペアNo and DATEADD(month, -2, @StartDate) < [StartDate] and [StartDate] < @StartDate

	Set @WMA角度シグマ = (ABS(@WMA角度) - ABS(@WMA角度AVG)) / ABS(@WMA角度STDEV);

	--角度が上昇していてシグマがマイナスの場合、角度が下降していてシグマがプラスの場合は、明らかに注文対象外。

END

GO

