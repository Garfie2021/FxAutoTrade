USE OANDA_DemoB
GO

DROP PROCEDURE [cmn].[spSelect�����ꗗ]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [cmn].[spSelect�����ꗗ]
	--@DemoReal	tinyint,
	--@�L������	tinyint
AS
BEGIN

	SELECT
		[����No],
		[OandaAccountId],
		[OandaAccessToken],
		[FX���],
		[FxServerContry],
		[�l�@�l],
		[DemoReal],
		[�L������],
		[����؋������],
		[�����̎��������J�n���s��]
	FROM [cmn].[t�����}�X�^]
	ORDER BY [����No];

END
GO

