USE OANDA_DemoB
GO

DROP PROCEDURE [cmn].[spGet�p�x]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [cmn].[spGet�p�x]
	@����y	float,
	@�p�x	float	output
AS
BEGIN

	-- 	SELECT (ATAN((@����WMA - @����WMA_1�O) / 1) * 180 / PI()) as �㏸�p�x;

	-- ���x�́u1�v�Œ�B
	-- ���x�ɑ΂��č���y�̏㏸�p�x(+-)�����߂�B
	Set @�p�x = (ATAN(@����y / 1) * 180 / PI());

END

GO

