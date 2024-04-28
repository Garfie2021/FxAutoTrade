USE [FX2_Demo]
GO
/*
*/
DROP PROCEDURE [rate].[spUpdateWMAs2_Min1]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [rate].[spUpdateWMAs2_Min1]
	@�ʉ݃y�ANo		tinyint = 12,
	@StartDate		datetime
AS
BEGIN
	/*
	DECLARE @�ʉ݃y�ANo tinyint = 0;
	DECLARE @StartDate datetime = '2015/10/20 2:35:18';
	--print '�ʉ݃y�ANo:' + convert(varchar, @�ʉ݃y�ANo) + '  StartDate:' + convert(varchar, @StartDate)
	*/

	--SELECT *
	--FROM [rate].[tRateHistory_Min1]
	--where �ʉ݃y�ANo = @�ʉ݃y�ANo and [StartDate] <= @StartDate;

	-- �f�[�^�L���`�F�b�N
	declare @Cnt int;
	SELECT @Cnt = count(*)
	FROM [rate].[tRateHistory_Min1]
	where �ʉ݃y�ANo = @�ʉ݃y�ANo and [StartDate] <= @StartDate;

	if @Cnt < 2
	begin
		print '�f�[�^����'
		return;
	end;


	-- �����WMA�v�Z
	declare @����WMAs2 float;
	declare @����WMAs2 float;
	EXECUTE [rate].[spCulcWMAs2_Min1] @�ʉ݃y�ANo, @StartDate, @����WMAs2 OUTPUT, @����WMAs2 OUTPUT;
	--select @����WMA, @����WMA, @����WMAs2, @����WMAs2


	-- �O���WMA�擾
	Declare @����WMAs2_1�O float = 0;
	Declare @����WMAs2_1�O float = 0;

	--select top 1 ����WMAs2, ����WMAs2
	--from [rate].[tRateHistory_Min1]
	--where �ʉ݃y�ANo = @�ʉ݃y�ANo and [StartDate] < @StartDate	
	--order by [StartDate] desc;
	select top 1 @����WMAs2_1�O = ����WMAs2, @����WMAs2_1�O = ����WMAs2
	from [rate].[tRateHistory_Min1]
	where �ʉ݃y�ANo = @�ʉ݃y�ANo and [StartDate] < @StartDate	
	order by [StartDate] desc;


	-- �����WMA�p�x���v�Z
	Declare @����WMAs2�p�x float = 0;
	Declare @����WMAs2�p�x float = 0;
	EXECUTE [cmn].[spGetWMA�p�x] @����WMAs2, @����WMAs2_1�O, @����WMAs2�p�x output, @����WMAs2, @����WMAs2_1�O, @����WMAs2�p�x output;


	-- �����WMA�p�x�̃V�O�}���v�Z
	Declare @����WMAs2�p�x�V�O�} float;
	Declare @����WMAs2�p�x�V�O�} float;
	EXECUTE [rate].[spCulcWMAs2�p�x�V�O�}_Min1] @�ʉ݃y�ANo, @StartDate, @����WMAs2�p�x, @����WMAs2�p�x�V�O�} output, @����WMAs2�p�x, @����WMAs2�p�x�V�O�} output;

	--select @����WMAs2 as ����WMAs2, @����WMAs2�p�x as ����WMAs2�p�x, @����WMAs2�p�x�V�O�} as ����WMAs2�p�x�V�O�}, @����WMAs2 as ����WMAs2, @����WMAs2�p�x as ����WMAs2�p�x, @����WMAs2�p�x�V�O�} as ����WMAs2�p�x�V�O�};

	-- ���ʂ�o�^
	UPDATE [rate].[tRateHistory_Min1]
	SET
		����WMAs2 = @����WMAs2,
		����WMAs2�p�x = @����WMAs2�p�x,
		����WMAs2�p�x�V�O�} = @����WMAs2�p�x�V�O�},
		����WMAs2 = @����WMAs2,
		����WMAs2�p�x = @����WMAs2�p�x,
		����WMAs2�p�x�V�O�} = @����WMAs2�p�x�V�O�},
		[�X�V����] = GETDATE()
	where �ʉ݃y�ANo = @�ʉ݃y�ANo and [StartDate] = @StartDate	

END
GO
/*
*/
