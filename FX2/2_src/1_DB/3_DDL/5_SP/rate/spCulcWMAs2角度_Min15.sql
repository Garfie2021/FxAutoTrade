USE [FX2_Demo]
GO
/*
*/
DROP PROCEDURE [rate].[spCulcWMAs2�p�x_Min15]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [rate].[spCulcWMAs2�p�x_Min15]
	@�ʉ݃y�ANo		tinyint,
	@StartDate		datetime,
	@����WMAs2		float,
	@����WMAs2		float,
	@����WMAs2�p�x	float	output,
	@����WMAs2�p�x	float	output
AS
BEGIN
	/*
	declare @�ʉ݃y�ANo	tinyint = 34;
	declare @StartDate	datetime = '2015-08-29 06:45:00.000';
	declare @����WMAs2�p�x	float;
	declare @����WMAs2�p�x	float;
	*/

	declare @����WMAs2_1�O float = 0;
	declare @����WMAs2_1�O float = 0;

	SELECT TOP 1 @����WMAs2_1�O = [����WMAs2], @����WMAs2_1�O = [����WMAs2]
	FROM [rate].[tRateHistory_Min15]
	where �ʉ݃y�ANo = @�ʉ݃y�ANo and [StartDate] < @StartDate
	order by [StartDate] desc;
	
	declare @����WMAs2����y float = @����WMAs2 - @����WMAs2_1�O;
	declare @����WMAs2����y float = @����WMAs2 - @����WMAs2_1�O;
	EXECUTE [cmn].[spGet�p�x] @����WMAs2����y, @����WMAs2�p�x OUTPUT;
	EXECUTE [cmn].[spGet�p�x] @����WMAs2����y, @����WMAs2�p�x OUTPUT;

END
GO
/*
*/
