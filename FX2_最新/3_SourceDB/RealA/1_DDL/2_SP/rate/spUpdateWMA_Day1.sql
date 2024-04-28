USE OANDA_DemoB
GO
/*
*/
DROP PROCEDURE [rate].[spUpdateWMA_Day1]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [rate].[spUpdateWMA_Day1]
	@�ʉ݃y�ANo		tinyint = 34,
	@StartDate		datetime
AS
BEGIN
	/*
	DECLARE  @�ʉ݃y�ANo	tinyint = 34;
	DECLARE  @StartDate		datetime = '2015-11-26 22:00:00.000';
	*/

	-- �f�[�^�L���`�F�b�N
	DECLARE  @Cnt int;
	SELECT @Cnt = count(*)
	FROM [hstr].[tDay1]
	where �ʉ݃y�ANo = @�ʉ݃y�ANo and [StartDate] <= @StartDate;

	if @Cnt < 2
	begin
		return;
	end;

	-- �O���WMA�擾
	DECLARE  @����WMAs2_1�O float = 0;
	DECLARE  @����WMAs2_1�O float = 0;
	select top 1 @����WMAs2_1�O = ����WMAs2, @����WMAs2_1�O = ����WMAs2
	from [hstr].[tDay1]
	where �ʉ݃y�ANo = @�ʉ݃y�ANo and [StartDate] < @StartDate
	order by [StartDate] desc;

	-- �����WMAs2�v�Z
	DECLARE  @����WMAs2 float;
	DECLARE  @����WMAs2 float;
	EXECUTE [rate].[spCulcWMAs2_Day1] @�ʉ݃y�ANo, @StartDate, @����WMAs2 OUTPUT, @����WMAs2 OUTPUT;

	-- �����WMAs2�p�x���v�Z
	DECLARE  @����WMAs2�p�x float = 0;
	DECLARE  @����WMAs2�p�x float = 0;
	EXECUTE [cmn].[spGetWMA�p�x] @����WMAs2, @����WMAs2_1�O, @����WMAs2�p�x output, @����WMAs2, @����WMAs2_1�O, @����WMAs2�p�x output;

	-- �f�[�^�L���`�F�b�N
	if @Cnt < 14
	begin
		-- ���ʂ�o�^
		UPDATE [hstr].[tDay1]
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
	EXECUTE [rate].[spCulcWMAs14_Day1] @�ʉ݃y�ANo, @StartDate, @����WMAs14 OUTPUT, @����WMAs14 OUTPUT;

	-- ���ʂ�o�^
	UPDATE [hstr].[tDay1]
	SET
		����WMAs2 = @����WMAs2,
		����WMAs2�p�x = @����WMAs2�p�x,
		����WMAs14 = @����WMAs14,
		����WMAs2 = @����WMAs2,
		����WMAs2�p�x = @����WMAs2�p�x,
		����WMAs14 = @����WMAs14,
		[�X�V����] = GETDATE()
	where �ʉ݃y�ANo = @�ʉ݃y�ANo and [StartDate] = @StartDate	

END
GO
/*
*/
