USE [RealB_2370741683_FX]
GO
/*
*/
DROP PROCEDURE [rate].[spUpdateWMA_Min15]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [rate].[spUpdateWMA_Min15]
	@�ʉ݃y�ANo		tinyint = 34,
	@StartDate		datetime
AS
BEGIN
	/*
	DECLARE  @�ʉ݃y�ANo	tinyint = 34;
	DECLARE  @StartDate		datetime = '2016-02-24 23:15:00.000';
	*/

	-- �f�[�^�L���`�F�b�N
	DECLARE  @Cnt int;
	SELECT @Cnt = count(*)
	FROM [hstr].[tMin15]
	where �ʉ݃y�ANo = @�ʉ݃y�ANo and [StartDate] <= @StartDate;

	if @Cnt < 2
	begin
		return;
	end;

	-- �O���WMA�擾
	DECLARE  @����WMAs2_1�O float = 0;
	DECLARE  @����WMAs14_1�O float = 0;
	DECLARE  @����WMAs2_1�O float = 0;
	DECLARE  @����WMAs14_1�O float = 0;
	select top 1 @����WMAs2_1�O = ����WMAs2, @����WMAs14_1�O = ����WMAs14, @����WMAs2_1�O = ����WMAs2, @����WMAs14_1�O = ����WMAs14
	from [hstr].[tMin15]
	where �ʉ݃y�ANo = @�ʉ݃y�ANo and [StartDate] < @StartDate
	order by [StartDate] desc;

	-- �����WMAs2�v�Z
	DECLARE  @����WMAs2 float;
	DECLARE  @����WMAs2 float;
	EXECUTE [rate].[spCulcWMAs2_Min15] @�ʉ݃y�ANo, @StartDate, @����WMAs2 OUTPUT, @����WMAs2 OUTPUT;
	--select @����WMA, @����WMA, @����WMAs2, @����WMAs2

	-- �����WMAs2�p�x���v�Z
	DECLARE  @����WMAs2�p�x float = 0;
	DECLARE  @����WMAs2�p�x float = 0;
	EXECUTE [cmn].[spGetWMA�p�x] @����WMAs2, @����WMAs2_1�O, @����WMAs2�p�x output, @����WMAs2, @����WMAs2_1�O, @����WMAs2�p�x output;

	-- �f�[�^�L���`�F�b�N
	if @Cnt < 14
	begin
		-- s2�̂݌��ʂ�o�^���ďI���
		UPDATE [hstr].[tMin15]
		SET
			����WMAs2 = @����WMAs2,
			����WMAs2�p�x = @����WMAs2�p�x,
			����WMAs2 = @����WMAs2,
			����WMAs2�p�x = @����WMAs2�p�x,
			[�X�V����] = GETDATE()
		where �ʉ݃y�ANo = @�ʉ݃y�ANo and [StartDate] = @StartDate;

		return;
	end;

	DECLARE  @����WMAs14 float;
	DECLARE  @����WMAs14 float;
	EXECUTE [rate].[spCulcWMAs14_Min15] @�ʉ݃y�ANo, @StartDate, @����WMAs14 OUTPUT, @����WMAs14 OUTPUT;

	-- �����WMA�p�x���v�Z
	DECLARE  @����WMAs14�p�x float = 0;
	DECLARE  @����WMAs14�p�x float = 0;
	EXECUTE [cmn].[spGetWMA�p�x] @����WMAs14, @����WMAs14_1�O, @����WMAs14�p�x output, @����WMAs14, @����WMAs14_1�O, @����WMAs14�p�x output;

	-- �����WMA�p�x�̃V�O�}���v�Z
	DECLARE  @����WMAs14�p�x�V�O�} float;
	DECLARE  @����WMAs14�p�x�V�O�} float;
	EXECUTE [rate].[spCulcWMAs14�p�x�V�O�}_Min15] @�ʉ݃y�ANo, @StartDate, @����WMAs14�p�x, @����WMAs14�p�x�V�O�} output, @����WMAs14�p�x, @����WMAs14�p�x�V�O�} output;

	--select @����WMAs14�p�x, @����WMAs14�p�x�V�O�}, @����WMAs14�p�x, @����WMAs14�p�x�V�O�}

	-- ���ʂ�o�^
	UPDATE [hstr].[tMin15]
	SET
		����WMAs2 = @����WMAs2,
		����WMAs2�p�x = @����WMAs2�p�x,
		����WMAs14 = @����WMAs14,
		����WMAs14�p�x = @����WMAs14�p�x,
		����WMAs14�p�x�V�O�} = @����WMAs14�p�x�V�O�},
		����WMAs2 = @����WMAs2,
		����WMAs2�p�x = @����WMAs2�p�x,
		����WMAs14 = @����WMAs14,
		����WMAs14�p�x = @����WMAs14�p�x,
		����WMAs14�p�x�V�O�} = @����WMAs14�p�x�V�O�},
		[�X�V����] = GETDATE()
	where �ʉ݃y�ANo = @�ʉ݃y�ANo and [StartDate] = @StartDate	

END
GO
/*
*/
