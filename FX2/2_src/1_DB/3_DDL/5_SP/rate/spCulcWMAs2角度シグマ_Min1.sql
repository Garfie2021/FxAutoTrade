USE [FX2_Demo]
GO

DROP PROCEDURE [rate].[spCulcWMAs2角度シグマ_Min1]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [rate].[spCulcWMAs2角度シグマ_Min1]
	@通貨ペアNo				tinyint,
	@StartDate				datetime,
	@買いWMAs2角度			float,
	@買いWMAs2角度シグマ	float output,
	@売りWMAs2角度			float,
	@売りWMAs2角度シグマ	float output
AS
BEGIN

	Declare @PastDate	datetime = DATEADD(day, -14, @StartDate);

	-- 今回のシグマを計算
	Declare @買いWMAs2角度AVG	float;
	Declare @買いWMAs2角度STDEV	float;
	Declare @売りWMAs2角度AVG	float;
	Declare @売りWMAs2角度STDEV	float;

	-- 過去全期間の角度平均のnσ(何シグマか)

	if @買いWMAs2角度 > 0
	begin
		SELECT @買いWMAs2角度AVG = AVG([買いWMAs2角度]), @買いWMAs2角度STDEV = STDEV([買いWMAs2角度])
		from [rate].[tRateHistory_Min1]
		where 通貨ペアNo = @通貨ペアNo and @PastDate < [StartDate] and [StartDate] < @StartDate 
			and [買いWMAs2角度] > 0;
	end
	else if @買いWMAs2角度 < 0
	begin
		SELECT @買いWMAs2角度AVG = AVG([買いWMAs2角度]), @買いWMAs2角度STDEV = STDEV([買いWMAs2角度])
		from [rate].[tRateHistory_Min1]
		where 通貨ペアNo = @通貨ペアNo and @PastDate < [StartDate] and [StartDate] < @StartDate 
			and [買いWMAs2角度] < 0;
	end;

	if @売りWMAs2角度 > 0
	begin
		SELECT @売りWMAs2角度AVG = AVG([売りWMAs2角度]), @売りWMAs2角度STDEV = STDEV([売りWMAs2角度])
		from [rate].[tRateHistory_Min1]
		where 通貨ペアNo = @通貨ペアNo and @PastDate < [StartDate] and [StartDate] < @StartDate 
			and [売りWMAs2角度] > 0;
	end
	else if @売りWMAs2角度 < 0
	begin
		SELECT @売りWMAs2角度AVG = AVG([売りWMAs2角度]), @売りWMAs2角度STDEV = STDEV([売りWMAs2角度])
		from [rate].[tRateHistory_Min1]
		where 通貨ペアNo = @通貨ペアNo and @PastDate < [StartDate] and [StartDate] < @StartDate 
			and [売りWMAs2角度] < 0;
	end;

	EXECUTE [cmn].[spGetシグマ] @買いWMAs2角度, @買いWMAs2角度AVG, @買いWMAs2角度STDEV, @買いWMAs2角度シグマ output;
	EXECUTE [cmn].[spGetシグマ] @売りWMAs2角度, @売りWMAs2角度AVG, @売りWMAs2角度STDEV, @売りWMAs2角度シグマ output;

END
GO
/*
*/
