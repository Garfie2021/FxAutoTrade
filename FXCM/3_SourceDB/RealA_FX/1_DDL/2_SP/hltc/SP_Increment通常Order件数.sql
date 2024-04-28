USE [FX_DemoA]
GO

DROP PROCEDURE [hltc].[SP_Increment�ʏ�Order����]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [hltc].[SP_Increment�ʏ�Order����]
AS
BEGIN

	declare @today date = getdate();

	declare @Cnt tinyint = 0;
	select @Cnt = count(*) from [hltc].[T_�V�X�e���ُ픭������_Daily] where [�N����] = @today;

	if @Cnt < 1
	begin
		INSERT INTO [hltc].[T_�V�X�e���ُ픭������_Daily] ([�N����]) VALUES (@today);
	end;

	UPDATE
		[hltc].[T_�V�X�e���ُ픭������_Daily]
	SET
		[�ʏ�Order����] = [�ʏ�Order����] + 1
	WHERE
		[�N����] = @today

END

GO
