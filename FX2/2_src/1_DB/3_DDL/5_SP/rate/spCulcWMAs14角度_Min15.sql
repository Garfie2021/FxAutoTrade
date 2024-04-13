USE [FX2_Demo]
GO
/*
*/
DROP PROCEDURE [rate].[spCulcWMAs14角度_Min15]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [rate].[spCulcWMAs14角度_Min15]
	@通貨ペアNo		tinyint,
	@StartDate		datetime,
	@買いWMAs14		float,
	@売りWMAs14		float,
	@買いWMAs14角度	float	output,
	@売りWMAs14角度	float	output
AS
BEGIN
	/*	
	declare @通貨ペアNo	tinyint = 34;
	declare @StartDate	datetime = '2015-08-29 06:45:00.000';
	declare @買いWMAs14角度	float;
	declare @売りWMAs14角度	float;
	*/

	declare @買いWMAs14_1つ前 float = 0;
	declare @売りWMAs14_1つ前 float = 0;

	SELECT TOP 1 @買いWMAs14_1つ前 = [買いWMAs14], @売りWMAs14_1つ前 = [売りWMAs14]
	FROM [rate].[tRateHistory_Min15]
	where 通貨ペアNo = @通貨ペアNo and [StartDate] < @StartDate
	order by [StartDate] desc;

	--declare @買いWMA高さy float = 1.1 - 1.2;
	--declare @売りWMA高さy float = 1.1 - 1.2;
	declare @買いWMAs14高さy float = @買いWMAs14 - @買いWMAs14_1つ前;
	declare @売りWMAs14高さy float = @売りWMAs14 - @売りWMAs14_1つ前;
	EXECUTE [cmn].[spGet角度] @買いWMAs14高さy, @買いWMAs14角度 OUTPUT;
	EXECUTE [cmn].[spGet角度] @売りWMAs14高さy, @売りWMAs14角度 OUTPUT;

	--SELECT @買いWMA, @買いWMA_1つ前, @買いWMAs14角度;
	--SELECT @売りWMA, @売りWMA_1つ前, @売りWMAs14角度;

END
GO
/*
*/
