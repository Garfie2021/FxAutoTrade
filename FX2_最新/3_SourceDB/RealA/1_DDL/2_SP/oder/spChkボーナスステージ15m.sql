USE OANDA_RealA
GO
/*
*/
DROP PROCEDURE [oder].[spChk�{�[�i�X�X�e�[�W15m]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [oder].[spChk�{�[�i�X�X�e�[�W15m]
	@�ʉ݃y�ANo					tinyint,
	@StartDate					datetime,
	@�V�O�}臒l					float = 2.5,			-- ��{�l��2.5�@���}�C�i�X�l�ɂ͑Ή����Ă��Ȃ�
	@����WMAs14					float		output,
	@����WMAs14�㏸�p�x�V�O�}	float		output,
	@����WMAs14					float		output,
	@����WMAs14�㏸�p�x�V�O�}	float		output,
	@WMA����					varchar(1)	output,		-- B(����) or S(����)
	@BS����						varchar(1)	output		-- B(BonusStage��) or �u�����N(�ʏ�)
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

	-- ���߂�Rate���擾

	DECLARE @��_����WMAs14 float;
	DECLARE @��_����WMAs14�㏸�p�x�V�O�} float;
	DECLARE @��_����WMAs14 float;
	DECLARE @��_����WMAs14�㏸�p�x�V�O�} float;

	DECLARE @1�O_����WMAs14 float;
	DECLARE @1�O_����WMAs14�㏸�p�x�V�O�} float;
	DECLARE @1�O_����WMAs14 float;
	DECLARE @1�O_����WMAs14�㏸�p�x�V�O�} float;


	DECLARE cursor_T_RateHistory_15m CURSOR FOR
	SELECT TOP 2 [����WMAs14], [����WMAs14�p�x�V�O�}], [����WMAs14], [����WMAs14�p�x�V�O�}]
	FROM [hstr].[tMin15]
	where �ʉ݃y�ANo = @�ʉ݃y�ANo and [StartDate] <= @StartDate
	order by [StartDate] desc

	open cursor_T_RateHistory_15m;
	
	FETCH NEXT FROM cursor_T_RateHistory_15m INTO @��_����WMAs14, @��_����WMAs14�㏸�p�x�V�O�}, @��_����WMAs14, @��_����WMAs14�㏸�p�x�V�O�};
	FETCH NEXT FROM cursor_T_RateHistory_15m INTO @1�O_����WMAs14, @1�O_����WMAs14�㏸�p�x�V�O�}, @1�O_����WMAs14, @1�O_����WMAs14�㏸�p�x�V�O�};

	CLOSE cursor_T_RateHistory_15m;
	DEALLOCATE cursor_T_RateHistory_15m;

	--select @�ʉ݃y�ANo as �ʉ݃y�ANo, @StartDate as StartDate


	-- Bonus Stage ����

	SET @����WMAs14 = @��_����WMAs14;
	SET @����WMAs14�㏸�p�x�V�O�} = @��_����WMAs14�㏸�p�x�V�O�};
	SET @����WMAs14 = @��_����WMAs14;
	SET @����WMAs14�㏸�p�x�V�O�} = @��_����WMAs14�㏸�p�x�V�O�};

	if @1�O_����WMAs14 < @��_����WMAs14
	begin
		Set @WMA���� = 'B'

		if @��_����WMAs14�㏸�p�x�V�O�} < @�V�O�}臒l
		begin
			Set @BS���� = '';	
			return;
		end
	end
	else if @1�O_����WMAs14 > @��_����WMAs14
	begin
		Set @WMA���� = 'S'

		if @��_����WMAs14�㏸�p�x�V�O�} < @�V�O�}臒l
		begin
			Set @BS���� = '';	
			return;
		end
	end
	else
	begin
		Set @WMA���� = ''
		Set @BS���� = '';	
		return;
	end

	Set @BS���� = 'B';	-- Bonus Stage �J�n

	--select @�ʉ݃y�ANo as �ʉ݃y�ANo, @StartDate as StartDate, @WMA���� as WMA����, @BonusStage���� as BonusStage����

END
GO
/*
*/

