USE [FX2_Demo]
GO

DROP PROCEDURE [cmn].[spGet�V�O�}]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [cmn].[spGet�V�O�}]
	@WMA�p�x		float,
	@WMA�p�xAVG		float,
	@WMA�p�xSTDEV	float,
	@WMA�p�x�V�O�}	float	output
AS
BEGIN

	-- �ߋ�2�����Ԃ̊p�x���ς�3��
	--SELECT	@����WMA�p�x_BonusStage臒l = AVG([����WMA�p�x]) + (STDEV([����WMA�p�x]) * 3),
	--		@����WMA�p�x_BonusStage臒l = AVG([����WMA�p�x]) - (STDEV([����WMA�p�x]) * 3)
	--from [rate].[tRateHistory_Min15]
	--where �ʉ݃y�ANo = @�ʉ݃y�ANo and DATEADD(month, -2, @StartDate) < [StartDate] and [StartDate] < @StartDate

	Set @WMA�p�x�V�O�} = (ABS(@WMA�p�x) - ABS(@WMA�p�xAVG)) / ABS(@WMA�p�xSTDEV);

	--�p�x���㏸���Ă��ăV�O�}���}�C�i�X�̏ꍇ�A�p�x�����~���Ă��ăV�O�}���v���X�̏ꍇ�́A���炩�ɒ����ΏۊO�B

END

GO

