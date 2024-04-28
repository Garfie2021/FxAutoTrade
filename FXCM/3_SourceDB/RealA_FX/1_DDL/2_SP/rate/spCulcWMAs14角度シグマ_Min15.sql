USE [DemoA_FX]
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
	@����WMAs14�p�x�V�O�}	float output,
	@����WMAs14�p�x			float,
	@����WMAs14�p�x�V�O�}	float output
AS
BEGIN
	/*	
	declare @�ʉ݃y�ANo		tinyint = 34;
	declare @StartDate		datetime = '2016-02-24 23:45:00.000';
	declare @����WMAs14�p�x			float = -2.32057354547405;
	declare @����WMAs14�p�x�V�O�}	float;
	declare @����WMAs14�p�x			float = -2.45729970855088;
	declare @����WMAs14�p�x�V�O�}	float;
	*/

	-- �ߋ��S���Ԃ̊p�x���ς�n��(���V�O�}��)�B
	-- ����̃V�O�}���v�Z�B

	IF 0 < @����WMAs14�p�x
	BEGIN
		--�}�C�i�X�̒l�̓{�[�i�X�X�e�[�W���f�Ɏg���Ȃ��B�v���X�̒l�����Ŕ��f����B
		SELECT @����WMAs14�p�x�V�O�} = (@����WMAs14�p�x - AVG([����WMAs14�p�x])) / STDEV([����WMAs14�p�x])
		FROM [hstr].[tMin15]
		WHERE �ʉ݃y�ANo = @�ʉ݃y�ANo and 0 < [����WMAs14�p�x] and 
			DATEADD(month, -2, @StartDate) < [StartDate] and [StartDate] < @StartDate;
	END;
	
	IF @����WMAs14�p�x < 0
	BEGIN
		--�v���X�̒l�̓{�[�i�X�X�e�[�W���f�Ɏg���Ȃ��B�}�C�i�X�̒l�����Ŕ��f����B
		SELECT @����WMAs14�p�x�V�O�} = ABS((@����WMAs14�p�x - AVG([����WMAs14�p�x])) / ABS(STDEV([����WMAs14�p�x])))
		FROM [hstr].[tMin15]
		WHERE �ʉ݃y�ANo = @�ʉ݃y�ANo and 0 > [����WMAs14�p�x] and 
			DATEADD(month, -2, @StartDate) < [StartDate] and [StartDate] < @StartDate;
	END;

	--select @����WMAs14�p�x, @����WMAs14�p�x�V�O�}, @����WMAs14�p�x, @����WMAs14�p�x�V�O�}

END
GO
/*
*/
