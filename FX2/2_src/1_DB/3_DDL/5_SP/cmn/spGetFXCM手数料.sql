USE [FX2_Demo]
GO

DROP PROCEDURE [cmn].[spGetFXCM�萔��]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [cmn].[spGetFXCM�萔��]
	@������	smallint,
	@�萔��	int	output
AS
BEGIN

	-- 2015/10/03���_�ł́A1����10�~�Œ�B
	Set @�萔�� = 10;

	Set @�萔�� = @�萔�� * @������;
END
GO

