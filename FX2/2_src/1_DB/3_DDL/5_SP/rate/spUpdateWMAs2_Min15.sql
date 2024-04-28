USE [FX2_Demo]
GO

DROP PROCEDURE [rate].[spUpdateWMAs2_Min15]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [rate].[spUpdateWMAs2_Min15]
	@�ʉ݃y�ANo		tinyint = 12,
	@StartDate		datetime
AS
BEGIN

	/*
	DECLARE  @�ʉ݃y�ANo		tinyint = 19;
	DECLARE  @StartDate		datetime = '2014-06-23 15:00:00.000';
	--print '�ʉ݃y�ANo:' + convert(varchar, @�ʉ݃y�ANo) + '  StartDate:' + convert(varchar, @StartDate)
	*/

	-- �f�[�^�L���`�F�b�N
	DECLARE  @Cnt int;
	SELECT @Cnt = count(*)
	FROM [rate].[tRateHistory_Min15]
	where �ʉ݃y�ANo = @�ʉ݃y�ANo and [StartDate] <= @StartDate;

	if @Cnt < 2
	begin
		return;
	end;


	-- �����WMA�v�Z
	DECLARE  @����WMAs2 float;
	DECLARE  @����WMAs2 float;
	EXECUTE [rate].[spCulcWMAs2_Min15] @�ʉ݃y�ANo, @StartDate, @����WMAs2 OUTPUT, @����WMAs2 OUTPUT;
	--select @����WMA, @����WMA, @����WMAs2, @����WMAs2


	-- �O���WMA�擾
	DECLARE  @����WMAs2_1�O float = 0;
	DECLARE  @����WMAs2_1�O float = 0;

	select top 1 @����WMAs2_1�O = ����WMAs2, @����WMAs2_1�O = ����WMAs2
	from [rate].[tRateHistory_Min15]
	where �ʉ݃y�ANo = @�ʉ݃y�ANo and [StartDate] < @StartDate
	order by [StartDate] desc;


	-- �����WMA�p�x���v�Z
	DECLARE  @����WMAs2�p�x float = 0;
	DECLARE  @����WMAs2�p�x float = 0;
	EXECUTE [cmn].[spGetWMA�p�x] @����WMAs2, @����WMAs2_1�O, @����WMAs2�p�x output, @����WMAs2, @����WMAs2_1�O, @����WMAs2�p�x output;


	-- �����WMA�p�x�̃V�O�}���v�Z
	DECLARE  @����WMAs2�p�x�V�O�} float;
	DECLARE  @����WMAs2�p�x�V�O�} float;
	EXECUTE [rate].[spCulcWMAs2�p�x�V�O�}_Min15] @�ʉ݃y�ANo, @StartDate, @����WMAs2�p�x, @����WMAs2�p�x�V�O�} output, @����WMAs2�p�x, @����WMAs2�p�x�V�O�} output;


	-- ���ʂ�o�^
	UPDATE [rate].[tRateHistory_Min15]
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
