USE [FX2_Demo]
GO
/*
*/
DROP PROCEDURE [rate].[spCulcWMAs2角度_Min15]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [rate].[spCulcWMAs2角度_Min15]
	@通貨ペアNo		tinyint,
	@StartDate		datetime,
	@買いWMAs2		float,
	@売りWMAs2		float,
	@買いWMAs2角度	float	output,
	@売りWMAs2角度	float	output
AS
BEGIN
	/*
	declare @通貨ペアNo	tinyint = 34;
	declare @StartDate	datetime = '2015-08-29 06:45:00.000';
	declare @買いWMAs2角度	float;
	declare @売りWMAs2角度	float;
	*/

	declare @買いWMAs2_1つ前 float = 0;
	declare @売りWMAs2_1つ前 float = 0;

	SELECT TOP 1 @買いWMAs2_1つ前 = [買いWMAs2], @売りWMAs2_1つ前 = [売りWMAs2]
	FROM [rate].[tRateHistory_Min15]
	where 通貨ペアNo = @通貨ペアNo and [StartDate] < @StartDate
	order by [StartDate] desc;
	
	declare @買いWMAs2高さy float = @買いWMAs2 - @買いWMAs2_1つ前;
	declare @売りWMAs2高さy float = @売りWMAs2 - @売りWMAs2_1つ前;
	EXECUTE [cmn].[spGet角度] @買いWMAs2高さy, @買いWMAs2角度 OUTPUT;
	EXECUTE [cmn].[spGet角度] @売りWMAs2高さy, @売りWMAs2角度 OUTPUT;

END
GO
/*
*/
