USE [FX2_Demo]
GO
/*
*/
DROP PROCEDURE [rate].[spCulcWMAs14�p�x�V�O�}_Min15]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [rate].[spCulcWMAs14�p�x�V�O�}_Min15]
	@�ʉ݃y�ANo				tinyint,
	@StartDate				datetime,
	@����WMAs14�p�x			float,
	@����WMAs14�p�x			float,
	@����WMAs14�p�x�V�O�}	float output,
	@����WMAs14�p�x�V�O�}	float output
AS
BEGIN
	/*	
	declare @�ʉ݃y�ANo		tinyint = 34;
	declare @StartDate		datetime = '2015-08-29 06:45:00.000';
	declare @����WMAs14�p�x			float = 2.0366887781301;
	declare @����WMAs14�p�x�V�O�}	float;
	declare @����WMAs14�p�x			float = 1.98327850524559;
	declare @����WMAs14�p�x�V�O�}	float;
	*/

	-- ����̃V�O�}���v�Z
	Declare @����WMAs14�p�xAVG		float;
	Declare @����WMAs14�p�xSTDEV	float;
	Declare @����WMAs14�p�xAVG		float;
	Declare @����WMAs14�p�xSTDEV	float;

	--SELECT AVG([����WMAs14�p�x]), STDEV([����WMAs14�p�x]), AVG([����WMAs14�p�x]), STDEV([����WMAs14�p�x])
	--from [rate].[tRateHistory_Min15]
	--where �ʉ݃y�ANo = @�ʉ݃y�ANo and [StartDate] < @StartDate;	-- �ߋ��S���Ԃ̊p�x���ς�n��(���V�O�}��)

	--SELECT AVG([����WMAs14�p�x]), STDEV([����WMAs14�p�x]), AVG([����WMAs14�p�x]), STDEV([����WMAs14�p�x])
	--from [rate].[tRateHistory_Min15]
	--where �ʉ݃y�ANo = @�ʉ݃y�ANo and [StartDate] < @StartDate;	-- �ߋ��S���Ԃ̊p�x���ς�n��(���V�O�}��)

	-- �ߋ��S���Ԃ̊p�x���ς�n��(���V�O�}��)

	if @����WMAs14�p�x > 0
	begin
		SELECT @����WMAs14�p�xAVG = AVG([����WMAs14�p�x]), @����WMAs14�p�xSTDEV = STDEV([����WMAs14�p�x])
		from [rate].[tRateHistory_Min15]
		where �ʉ݃y�ANo = @�ʉ݃y�ANo and [StartDate] < @StartDate --and [����WMAs14�p�x] > 0;
	end
	else if @����WMAs14�p�x < 0
	begin
		SELECT @����WMAs14�p�xAVG = AVG([����WMAs14�p�x]), @����WMAs14�p�xSTDEV = STDEV([����WMAs14�p�x])
		from [rate].[tRateHistory_Min15]
		where �ʉ݃y�ANo = @�ʉ݃y�ANo and [StartDate] < @StartDate and [����WMAs14�p�x] < 0;
	end;

	if @����WMAs14�p�x > 0
	begin
		SELECT @����WMAs14�p�xAVG = AVG([����WMAs14�p�x]), @����WMAs14�p�xSTDEV = STDEV([����WMAs14�p�x])
		from [rate].[tRateHistory_Min15]
		where �ʉ݃y�ANo = @�ʉ݃y�ANo and [StartDate] < @StartDate --and [����WMAs14�p�x] > 0;
	end
	else if @����WMAs14�p�x < 0
	begin
		SELECT @����WMAs14�p�xAVG = AVG([����WMAs14�p�x]), @����WMAs14�p�xSTDEV = STDEV([����WMAs14�p�x])
		from [rate].[tRateHistory_Min15]
		where �ʉ݃y�ANo = @�ʉ݃y�ANo and [StartDate] < @StartDate and [����WMAs14�p�x] < 0;
	end;

	EXECUTE [cmn].[spGet�V�O�}] @����WMAs14�p�x, @����WMAs14�p�xAVG, @����WMAs14�p�xSTDEV, @����WMAs14�p�x�V�O�} output;
	EXECUTE [cmn].[spGet�V�O�}] @����WMAs14�p�x, @����WMAs14�p�xAVG, @����WMAs14�p�xSTDEV, @����WMAs14�p�x�V�O�} output;

	--select @����WMAs14�p�x, @����WMAs14�p�xAVG, @����WMAs14�p�xSTDEV, @����WMAs14�p�x�V�O�};
	--select @����WMAs14�p�x, @����WMAs14�p�xAVG, @����WMAs14�p�xSTDEV, @����WMAs14�p�x�V�O�};
END
GO
/*
*/
