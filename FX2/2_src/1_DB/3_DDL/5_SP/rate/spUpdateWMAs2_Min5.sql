USE [FX2_Demo]
GO

DROP PROCEDURE [rate].[spUpdateWMAs2_Min5]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [rate].[spUpdateWMAs2_Min5]
	@�ʉ݃y�ANo		tinyint = 12,
	@StartDate		datetime
AS
BEGIN
	/*
	declare @�ʉ݃y�ANo		tinyint = 34;
	declare @StartDate		datetime = '2014-06-28 05:30:00.000';
	*/
	--print '�ʉ݃y�ANo:' + convert(varchar, @�ʉ݃y�ANo) + '  StartDate:' + convert(varchar, @StartDate)


	-- �f�[�^�L���`�F�b�N
	declare @Cnt int;
	SELECT @Cnt = count(*)
	FROM [rate].[tRateHistory_Min5]
	where �ʉ݃y�ANo = @�ʉ݃y�ANo and [StartDate] <= @StartDate;

	if @Cnt < 2
	begin
		return;
	end;


	-- �����WMA�v�Z
	declare @����WMAs2 float;
	declare @����WMAs2 float;
	EXECUTE [rate].[spCulcWMAs2_Min5] @�ʉ݃y�ANo, @StartDate, @����WMAs2 OUTPUT, @����WMAs2 OUTPUT;
	--select @����WMA, @����WMA, @����WMAs2, @����WMAs2


	-- �O���WMA�擾
	Declare @����WMAs2_1�O float = 0;
	Declare @����WMAs2_1�O float = 0;

	select top 1 @����WMAs2_1�O = ����WMAs2, @����WMAs2_1�O = ����WMAs2
	from [rate].[tRateHistory_Min5]
	where �ʉ݃y�ANo = @�ʉ݃y�ANo and [StartDate] < @StartDate	
	order by [StartDate] desc;

	-- �����WMA�p�x���v�Z
	Declare @����WMAs2�p�x float = 0;
	Declare @����WMAs2�p�x float = 0;
	EXECUTE [cmn].[spGetWMA�p�x] @����WMAs2, @����WMAs2_1�O, @����WMAs2�p�x output, @����WMAs2, @����WMAs2_1�O, @����WMAs2�p�x output;


	-- �����WMA�p�x�̃V�O�}���v�Z
	Declare @����WMAs2�p�x�V�O�} float;
	Declare @����WMAs2�p�x�V�O�} float;
	EXECUTE [rate].[spCulcWMAs2�p�x�V�O�}_Min5] @�ʉ݃y�ANo, @StartDate, @����WMAs2�p�x, @����WMAs2�p�x�V�O�} output, @����WMAs2�p�x, @����WMAs2�p�x�V�O�} output;


	-- ���ʂ�o�^
	UPDATE [rate].[tRateHistory_Min5]
	SET
		����WMAs2 = @����WMAs2,
		����WMAs2�p�x = @����WMAs2�p�x,
		����WMAs2�p�x�V�O�} = @����WMAs2�p�x�V�O�},
		����WMAs2 = @����WMAs2,
		����WMAs2�p�x = @����WMAs2�p�x,
		����WMAs2�p�x�V�O�} = @����WMAs2�p�x�V�O�},
		[�X�V����] = GETDATE()
	where �ʉ݃y�ANo = @�ʉ݃y�ANo and [StartDate] = @StartDate;

END
GO
