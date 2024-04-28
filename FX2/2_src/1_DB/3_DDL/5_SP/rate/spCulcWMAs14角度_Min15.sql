USE [FX2_Demo]
GO
/*
*/
DROP PROCEDURE [rate].[spCulcWMAs14�p�x_Min15]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [rate].[spCulcWMAs14�p�x_Min15]
	@�ʉ݃y�ANo		tinyint,
	@StartDate		datetime,
	@����WMAs14		float,
	@����WMAs14		float,
	@����WMAs14�p�x	float	output,
	@����WMAs14�p�x	float	output
AS
BEGIN
	/*	
	declare @�ʉ݃y�ANo	tinyint = 34;
	declare @StartDate	datetime = '2015-08-29 06:45:00.000';
	declare @����WMAs14�p�x	float;
	declare @����WMAs14�p�x	float;
	*/

	declare @����WMAs14_1�O float = 0;
	declare @����WMAs14_1�O float = 0;

	SELECT TOP 1 @����WMAs14_1�O = [����WMAs14], @����WMAs14_1�O = [����WMAs14]
	FROM [rate].[tRateHistory_Min15]
	where �ʉ݃y�ANo = @�ʉ݃y�ANo and [StartDate] < @StartDate
	order by [StartDate] desc;

	--declare @����WMA����y float = 1.1 - 1.2;
	--declare @����WMA����y float = 1.1 - 1.2;
	declare @����WMAs14����y float = @����WMAs14 - @����WMAs14_1�O;
	declare @����WMAs14����y float = @����WMAs14 - @����WMAs14_1�O;
	EXECUTE [cmn].[spGet�p�x] @����WMAs14����y, @����WMAs14�p�x OUTPUT;
	EXECUTE [cmn].[spGet�p�x] @����WMAs14����y, @����WMAs14�p�x OUTPUT;

	--SELECT @����WMA, @����WMA_1�O, @����WMAs14�p�x;
	--SELECT @����WMA, @����WMA_1�O, @����WMAs14�p�x;

END
GO
/*
*/
