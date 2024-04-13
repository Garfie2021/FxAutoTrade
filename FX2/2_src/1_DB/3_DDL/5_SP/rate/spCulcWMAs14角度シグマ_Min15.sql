USE [FX2_Demo]
GO
/*
*/
DROP PROCEDURE [rate].[spCulcWMAs14角度シグマ_Min15]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [rate].[spCulcWMAs14角度シグマ_Min15]
	@通貨ペアNo				tinyint,
	@StartDate				datetime,
	@買いWMAs14角度			float,
	@売りWMAs14角度			float,
	@買いWMAs14角度シグマ	float output,
	@売りWMAs14角度シグマ	float output
AS
BEGIN
	/*	
	declare @通貨ペアNo		tinyint = 34;
	declare @StartDate		datetime = '2015-08-29 06:45:00.000';
	declare @買いWMAs14角度			float = 2.0366887781301;
	declare @買いWMAs14角度シグマ	float;
	declare @売りWMAs14角度			float = 1.98327850524559;
	declare @売りWMAs14角度シグマ	float;
	*/

	-- 今回のシグマを計算
	Declare @買いWMAs14角度AVG		float;
	Declare @買いWMAs14角度STDEV	float;
	Declare @売りWMAs14角度AVG		float;
	Declare @売りWMAs14角度STDEV	float;

	--SELECT AVG([買いWMAs14角度]), STDEV([買いWMAs14角度]), AVG([売りWMAs14角度]), STDEV([売りWMAs14角度])
	--from [rate].[tRateHistory_Min15]
	--where 通貨ペアNo = @通貨ペアNo and [StartDate] < @StartDate;	-- 過去全期間の角度平均のnσ(何シグマか)

	--SELECT AVG([買いWMAs14角度]), STDEV([買いWMAs14角度]), AVG([売りWMAs14角度]), STDEV([売りWMAs14角度])
	--from [rate].[tRateHistory_Min15]
	--where 通貨ペアNo = @通貨ペアNo and [StartDate] < @StartDate;	-- 過去全期間の角度平均のnσ(何シグマか)

	-- 過去全期間の角度平均のnσ(何シグマか)

	if @買いWMAs14角度 > 0
	begin
		SELECT @買いWMAs14角度AVG = AVG([買いWMAs14角度]), @買いWMAs14角度STDEV = STDEV([買いWMAs14角度])
		from [rate].[tRateHistory_Min15]
		where 通貨ペアNo = @通貨ペアNo and [StartDate] < @StartDate --and [買いWMAs14角度] > 0;
	end
	else if @買いWMAs14角度 < 0
	begin
		SELECT @買いWMAs14角度AVG = AVG([買いWMAs14角度]), @買いWMAs14角度STDEV = STDEV([買いWMAs14角度])
		from [rate].[tRateHistory_Min15]
		where 通貨ペアNo = @通貨ペアNo and [StartDate] < @StartDate and [買いWMAs14角度] < 0;
	end;

	if @売りWMAs14角度 > 0
	begin
		SELECT @売りWMAs14角度AVG = AVG([売りWMAs14角度]), @売りWMAs14角度STDEV = STDEV([売りWMAs14角度])
		from [rate].[tRateHistory_Min15]
		where 通貨ペアNo = @通貨ペアNo and [StartDate] < @StartDate --and [買いWMAs14角度] > 0;
	end
	else if @売りWMAs14角度 < 0
	begin
		SELECT @売りWMAs14角度AVG = AVG([売りWMAs14角度]), @売りWMAs14角度STDEV = STDEV([売りWMAs14角度])
		from [rate].[tRateHistory_Min15]
		where 通貨ペアNo = @通貨ペアNo and [StartDate] < @StartDate and [買いWMAs14角度] < 0;
	end;

	EXECUTE [cmn].[spGetシグマ] @買いWMAs14角度, @買いWMAs14角度AVG, @買いWMAs14角度STDEV, @買いWMAs14角度シグマ output;
	EXECUTE [cmn].[spGetシグマ] @売りWMAs14角度, @売りWMAs14角度AVG, @売りWMAs14角度STDEV, @売りWMAs14角度シグマ output;

	--select @買いWMAs14角度, @買いWMAs14角度AVG, @買いWMAs14角度STDEV, @買いWMAs14角度シグマ;
	--select @売りWMAs14角度, @売りWMAs14角度AVG, @売りWMAs14角度STDEV, @売りWMAs14角度シグマ;
END
GO
/*
*/
