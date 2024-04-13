USE [DemoA_FX]
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
	@買いWMAs14角度シグマ	float output,
	@売りWMAs14角度			float,
	@売りWMAs14角度シグマ	float output
AS
BEGIN
	/*	
	declare @通貨ペアNo		tinyint = 34;
	declare @StartDate		datetime = '2016-02-24 23:45:00.000';
	declare @買いWMAs14角度			float = -2.32057354547405;
	declare @買いWMAs14角度シグマ	float;
	declare @売りWMAs14角度			float = -2.45729970855088;
	declare @売りWMAs14角度シグマ	float;
	*/

	-- 過去全期間の角度平均のnσ(何シグマか)。
	-- 今回のシグマを計算。

	IF 0 < @買いWMAs14角度
	BEGIN
		--マイナスの値はボーナスステージ判断に使えない。プラスの値だけで判断する。
		SELECT @買いWMAs14角度シグマ = (@買いWMAs14角度 - AVG([買いWMAs14角度])) / STDEV([買いWMAs14角度])
		FROM [hstr].[tMin15]
		WHERE 通貨ペアNo = @通貨ペアNo and 0 < [買いWMAs14角度] and 
			DATEADD(month, -2, @StartDate) < [StartDate] and [StartDate] < @StartDate;
	END;
	
	IF @売りWMAs14角度 < 0
	BEGIN
		--プラスの値はボーナスステージ判断に使えない。マイナスの値だけで判断する。
		SELECT @売りWMAs14角度シグマ = ABS((@売りWMAs14角度 - AVG([売りWMAs14角度])) / ABS(STDEV([売りWMAs14角度])))
		FROM [hstr].[tMin15]
		WHERE 通貨ペアNo = @通貨ペアNo and 0 > [売りWMAs14角度] and 
			DATEADD(month, -2, @StartDate) < [StartDate] and [StartDate] < @StartDate;
	END;

	--select @買いWMAs14角度, @買いWMAs14角度シグマ, @売りWMAs14角度, @売りWMAs14角度シグマ

END
GO
/*
*/
