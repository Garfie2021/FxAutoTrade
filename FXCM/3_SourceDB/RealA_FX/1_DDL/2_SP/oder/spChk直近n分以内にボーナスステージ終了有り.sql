USE DemoA_FX
GO

DROP PROCEDURE [oder].[spChk����n���ȓ��Ƀ{�[�i�X�X�e�[�W�I���L��]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [oder].[spChk����n���ȓ��Ƀ{�[�i�X�X�e�[�W�I���L��]
	@�ʉ݃y�ANo		tinyint,
	@n���O			datetime,
	@����			tinyint		output
AS
BEGIN

	DECLARE @iCnt int;

	SELECT @iCnt = Count(*)
	FROM [hstr].[tBonusStage]
	where [�ʉ݃y�ANo] = @�ʉ݃y�ANo AND 
		@n���O < [����] AND 
		[BS����_�O] = 'B' AND 
		[BS����_��] = ''

	if 0 < @iCnt
	begin
		Set @���� = 1;
	end
	else
	begin
		Set @���� = 0;
	end;

	--select @����

END

GO


