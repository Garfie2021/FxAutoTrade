USE OANDA_DemoB
GO

DROP PROCEDURE [cmn].[spSelect����]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [cmn].[spSelect����]
	@����No	int
AS
BEGIN

	SELECT
		[OandaAccountId],
		[OandaAccessToken],
		[FX���],
		[FxServerContry],
		[�l�@�l],
		[DemoReal],
		[�L������],
		[����؋������],
		�����̎��������J�n���s��
	FROM [cmn].[t�����}�X�^]
	WHERE [����No] = @����No;

END
GO

