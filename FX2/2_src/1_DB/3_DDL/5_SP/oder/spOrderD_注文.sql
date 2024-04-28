USE [FX2_Demo]
GO

DROP PROCEDURE [oder].[spOrderD_����]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [oder].[spOrderD_����]
	@Rate�L�^�ȍ~�̏������X�L�b�v		bit,				-- 0:�X�L�b�v���Ȃ��@1:�X�L�b�v����
	@���ԕ�Rate�v�Z�ȍ~�̏������X�L�b�v	bit,				-- 0:�X�L�b�v���Ȃ��@1:�X�L�b�v����
	@�ʉ݃y�ANo							tinyint,
	@StartDate							datetime,
	@����Rate							float,
	@����Rate							float,
	@��������							tinyint		output,	-- 0:�������Ȃ��@1:��������
	@��������							tinyint		output,	-- 1:�����@2:����
	@Close�\��Date						datetime	output,	-- �ߋ��̃f�[�^��\�z�Ƃ��Ďg��
	@������								int			output,
	@�萔��								int			output
AS
BEGIN
	/*
	DECLARE @�ʉ݃y�ANo		tinyint = 21
	DECLARE @StartDate		datetime = getdate()
	DECLARE @�V�O�}臒l		float = 2.5
	DECLARE @WMA����		varchar(5)
	DECLARE @BonusStage����	varchar(5)
	DECLARE @WMA�O_S2		float = 2.5
	DECLARE @WMA��_S2		float = 2.5
	*/


	SET @�������� = 0;
	SET @�������� = 1;
	SET @Close�\��Date = 0;
	SET @������ = 0;
	SET @�萔�� = 0;

	/*** Rate�L�^ ***/

	EXECUTE [rate].[spInsertRateHistory] @�ʉ݃y�ANo ,@StartDate ,@����Rate ,@����Rate;

	if @Rate�L�^�ȍ~�̏������X�L�b�v = 1
	begin
		EXECUTE [oder].[spUpdateOrderStatus_�����] @�ʉ݃y�ANo, 'Rate�L�^�ȍ~�̏������X�L�b�v';
		return;
	end;

	EXECUTE [oder].[spUpdateOrderStatus_�����] @�ʉ݃y�ANo, 'Rate�L�^�ȍ~�̏����𑱍s';

	DECLARE @Start1m datetime
	DECLARE @End1m datetime
	EXECUTE [cmn].[spGetTerm_Min1] @StartDate, 0, @Start1m OUTPUT, @End1m OUTPUT

	DECLARE @Start5m datetime
	DECLARE @End5m datetime
	EXECUTE [cmn].[spGetTerm_Min5] @StartDate, 0, @Start5m OUTPUT, @End1m OUTPUT

	DECLARE @Start15m datetime
	DECLARE @End15m datetime
	EXECUTE [cmn].[spGetTerm_Min15] @StartDate, 0, @Start15m OUTPUT, @End1m OUTPUT

	EXECUTE [rate].[spInsertRateHistory_Min1] @�ʉ݃y�ANo, @Start1m;
	EXECUTE [rate].[spInsertRateHistory_Min5] @�ʉ݃y�ANo, @Start5m;
	EXECUTE [rate].[spInsertRateHistory_Min15] @�ʉ݃y�ANo, @Start15m;

	if @���ԕ�Rate�v�Z�ȍ~�̏������X�L�b�v = 1
	begin
		EXECUTE [oder].[spUpdateOrderStatus_�����] @�ʉ݃y�ANo, '���ԕ�Rate�v�Z�ȍ~�̏������X�L�b�v';
		return;
	end;

	--30���ȏ��Rate�v�Z��Job������s�i�ꕪ�����j�ōs��


	/*** �v�Z�Ώۂ��`�F�b�N ***/

	DECLARE @�v�Z�Ώ� tinyint
	EXECUTE [oder].[spChk�v�Z�Ώ�] @�ʉ݃y�ANo ,@�v�Z�Ώ� OUTPUT;
	if @�v�Z�Ώ� = 0
	begin
		EXECUTE [oder].[spUpdateOrderStatus_�����] @�ʉ݃y�ANo, '�v�Z�ΏۊO';
		return;
	end;

	EXECUTE [oder].[spUpdateOrderStatus_�����] @�ʉ݃y�ANo, '�v�Z�Ώ�';

	SET @�������� = 0;


	/*** �v�Z ***/

	-- spUpdateWMAs2�́AWMA�A�p�x�A�V�O�}�܂Ōv�Z����B
	EXECUTE [rate].[spUpdateWMAs2_Min1] @�ʉ݃y�ANo, @Start1m;
	EXECUTE [rate].[spUpdateWMAs2_Min5] @�ʉ݃y�ANo, @Start5m;
	EXECUTE [rate].[spUpdateWMAs2_Min15] @�ʉ݃y�ANo, @Start15m;
	--�����ʂ͓y���Ɍv�Z


	/*** �������� START ***/

	DECLARE @�����Ώ� tinyint
	EXECUTE [oder].[spChk�����Ώ�] @�ʉ݃y�ANo ,@�����Ώ� OUTPUT;
	if @�����Ώ� = 0
	begin
		EXECUTE [oder].[spUpdateOrderStatus_�����] @�ʉ݃y�ANo, '�����ΏۊO';
		return;
	end;

	EXECUTE [oder].[spUpdateOrderStatus_�����] @�ʉ݃y�ANo, '�����Ώ�';

	if @����Rate = 0 or @����Rate = 0
	begin
		EXECUTE [oder].[spUpdateOrderStatus_�����] @�ʉ݃y�ANo, '�����ΏۊO�iRate0�j';
		return;
	end;

	DECLARE @15���ȓ���Close�|�W�V������ int = 0;
	select @15���ȓ���Close�|�W�V������ = count(*)
	from [oder].[tOrderHistory]
	where �ʉ݃y�ANo = @�ʉ݃y�ANo and [OrderDate] > DateAdd(MINUTE, -15, @Start15m);

	if @15���ȓ���Close�|�W�V������ > 0
	begin
		EXECUTE [oder].[spUpdateOrderStatus_�����] @�ʉ݃y�ANo, '�����ΏۊO�i15���ȓ��Ƀ|�W�V�����L��j';
		return;
	end;

	-- Min15����ɁA����̃V�O�}�l���B
	-- Min15�e�[�u����[����WMAs2�p�x��������]�Ɣ�r���āA15���ȏ㎝������Ɣ��f���ꂽ�ꍇ�A�����ΏۂƔ��f����B
	-- Min15�e�[�u����[����WMAs2�p�x��������]�Ɣ�r���āA15���ȏ㎝������Ɣ��f����Ȃ������ꍇ�ł��A
	-- Min1�e�[�u��orMin5�e�[�u����[����WMAs2�p�x��������]����A1���ȏ�A5���ȏ㎝������Ɣ��f�����ꍇ�́A�����ΏۂƔ��f����B
	-- �������邱�Ƃ��\�z����Ă��ARate�����萔����������Ă���ꍇ�́A�����ΏۊO�Ɣ��f����B
	-- Min15���������Ă��Ȃ��Ă��AMin5�AMin1�������炩�������邱�Ƃ�����̂ŁAMin5�AMin1�̎������Ԃ��AMin15�̎������Ԃɑ����B
	-- �ߋ��̒����f�[�^���V�O�}�P�ʂɏW�v���āA���v�̂łȂ��V�O�}�l�͒����ΏۊO�ɂ���B

	DECLARE @����WMAs2�p�x			float;
	DECLARE @����WMAs2�p�x�V�O�}	float;
	DECLARE @����WMAs2�p�x			float;
	DECLARE @����WMAs2�p�x�V�O�}	float;
	DECLARE @WMAs2�p�x��������_�ߋ�	int;
	DECLARE @WMAs2�p�x����Rate_�ߋ�	float;

	SELECT TOP 1 @����WMAs2�p�x = [����WMAs2�p�x], @����WMAs2�p�x�V�O�} = [����WMAs2�p�x�V�O�}],
		@����WMAs2�p�x = [����WMAs2�p�x], @����WMAs2�p�x�V�O�} = [����WMAs2�p�x�V�O�}]
	FROM [rate].[tRateHistory_Min15]
	WHERE [�ʉ݃y�ANo] = @�ʉ݃y�ANo
	ORDER BY [StartDate] DESC;

	SET @�������� = 0;
	DECLARE @�p�x�V�O�}	float;

	if @����WMAs2�p�x > 0
	begin
		if @����WMAs2�p�x�V�O�} > 2
		begin
			SET @�������� = 1;
			SET @�p�x�V�O�}	= @����WMAs2�p�x�V�O�};

			--SELECT TOP 1 @WMAs2�p�x��������_�ߋ� = [����WMAs2�p�x��������], @WMAs2�p�x����Rate_�ߋ� = [����WMAs2�p�x����Rate]
			--FROM [indi].[tIndicatorHistory_Min15]
			--WHERE [�ʉ݃y�ANo] = @�ʉ݃y�ANo AND [����WMAs2�p�x�V�O�}] <= @����WMAs2�p�x�V�O�}
			--ORDER BY [StartDate] DESC;
			--���ʂ͌Œ�
			SET @WMAs2�p�x��������_�ߋ� = 15;
			SET @WMAs2�p�x����Rate_�ߋ� = 0;
		end
		ELSE
		begin
			EXECUTE [oder].[spUpdateOrderStatus_�����] @�ʉ݃y�ANo, '�����ΏۊO�i�����V�O�}0.1�ȉ��j';
			return;
		end;
	end
	ELSE if @����WMAs2�p�x < 0
	begin
		if @����WMAs2�p�x�V�O�} > 2
		begin
			SET @�������� = 2;
			SET @�p�x�V�O�}	= @����WMAs2�p�x�V�O�};

			--SELECT TOP 1 @WMAs2�p�x��������_�ߋ� = [����WMAs2�p�x��������], @WMAs2�p�x����Rate_�ߋ� = [����WMAs2�p�x����Rate]
			--FROM [indi].[tIndicatorHistory_Min15]
			--WHERE [�ʉ݃y�ANo] = @�ʉ݃y�ANo AND [����WMAs2�p�x�V�O�}] <= @����WMAs2�p�x�V�O�}
			--ORDER BY [StartDate] DESC;
			--���ʂ͌Œ�
			SET @WMAs2�p�x��������_�ߋ� = 15
			SET @WMAs2�p�x����Rate_�ߋ� = 0;
		end
		ELSE
		begin
			EXECUTE [oder].[spUpdateOrderStatus_�����] @�ʉ݃y�ANo, '�����ΏۊO�i����V�O�}0.1�ȉ��j';
			return;
		end;
	end
	ELSE
	begin
		EXECUTE [oder].[spUpdateOrderStatus_�����] @�ʉ݃y�ANo, '�����ΏۊO�i�p�x����j';
		return;
	end;

	if @�������� = 0
	begin
		EXECUTE [oder].[spUpdateOrderStatus_�����] @�ʉ݃y�ANo, '�����ΏۊO�i��������j';
		return;
	end;

	if @WMAs2�p�x����Rate_�ߋ� < @�萔��
	begin
		EXECUTE [oder].[spUpdateOrderStatus_�����] @�ʉ݃y�ANo, '�����ΏۊO�i�萔���𒴂��闘�v�������߂Ȃ��j';
		return;
	end;

	-- ��������
	SET @�������� = 1;
	SET @Close�\��Date = DATEADD(minute, @WMAs2�p�x��������_�ߋ�, @Start15m);

	EXECUTE [cmn].[spGet������] @�p�x�V�O�}, @������ OUTPUT;
	EXECUTE [cmn].[spGetFXCM�萔��] @������, @�萔�� OUTPUT;

END
GO
/*
*/

