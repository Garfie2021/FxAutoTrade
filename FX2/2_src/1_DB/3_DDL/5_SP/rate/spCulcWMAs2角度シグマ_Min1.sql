USE [FX2_Demo]
GO

DROP PROCEDURE [rate].[spCulcWMAs2�p�x�V�O�}_Min1]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [rate].[spCulcWMAs2�p�x�V�O�}_Min1]
	@�ʉ݃y�ANo				tinyint,
	@StartDate				datetime,
	@����WMAs2�p�x			float,
	@����WMAs2�p�x�V�O�}	float output,
	@����WMAs2�p�x			float,
	@����WMAs2�p�x�V�O�}	float output
AS
BEGIN

	Declare @PastDate	datetime = DATEADD(day, -14, @StartDate);

	-- ����̃V�O�}���v�Z
	Declare @����WMAs2�p�xAVG	float;
	Declare @����WMAs2�p�xSTDEV	float;
	Declare @����WMAs2�p�xAVG	float;
	Declare @����WMAs2�p�xSTDEV	float;

	-- �ߋ��S���Ԃ̊p�x���ς�n��(���V�O�}��)

	if @����WMAs2�p�x > 0
	begin
		SELECT @����WMAs2�p�xAVG = AVG([����WMAs2�p�x]), @����WMAs2�p�xSTDEV = STDEV([����WMAs2�p�x])
		from [rate].[tRateHistory_Min1]
		where �ʉ݃y�ANo = @�ʉ݃y�ANo and @PastDate < [StartDate] and [StartDate] < @StartDate 
			and [����WMAs2�p�x] > 0;
	end
	else if @����WMAs2�p�x < 0
	begin
		SELECT @����WMAs2�p�xAVG = AVG([����WMAs2�p�x]), @����WMAs2�p�xSTDEV = STDEV([����WMAs2�p�x])
		from [rate].[tRateHistory_Min1]
		where �ʉ݃y�ANo = @�ʉ݃y�ANo and @PastDate < [StartDate] and [StartDate] < @StartDate 
			and [����WMAs2�p�x] < 0;
	end;

	if @����WMAs2�p�x > 0
	begin
		SELECT @����WMAs2�p�xAVG = AVG([����WMAs2�p�x]), @����WMAs2�p�xSTDEV = STDEV([����WMAs2�p�x])
		from [rate].[tRateHistory_Min1]
		where �ʉ݃y�ANo = @�ʉ݃y�ANo and @PastDate < [StartDate] and [StartDate] < @StartDate 
			and [����WMAs2�p�x] > 0;
	end
	else if @����WMAs2�p�x < 0
	begin
		SELECT @����WMAs2�p�xAVG = AVG([����WMAs2�p�x]), @����WMAs2�p�xSTDEV = STDEV([����WMAs2�p�x])
		from [rate].[tRateHistory_Min1]
		where �ʉ݃y�ANo = @�ʉ݃y�ANo and @PastDate < [StartDate] and [StartDate] < @StartDate 
			and [����WMAs2�p�x] < 0;
	end;

	EXECUTE [cmn].[spGet�V�O�}] @����WMAs2�p�x, @����WMAs2�p�xAVG, @����WMAs2�p�xSTDEV, @����WMAs2�p�x�V�O�} output;
	EXECUTE [cmn].[spGet�V�O�}] @����WMAs2�p�x, @����WMAs2�p�xAVG, @����WMAs2�p�xSTDEV, @����WMAs2�p�x�V�O�} output;

END
GO
/*
*/
