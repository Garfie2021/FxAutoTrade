USE [FX2_DemoA]
GO

DROP PROCEDURE [oder].[spChk�v�Z�Ώ�]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [oder].[spChk�v�Z�Ώ�]
	@�ʉ݃y�ANo	tinyint,
	@�v�Z�Ώ�	tinyint OUTPUT
AS
BEGIN

	SELECT @�v�Z�Ώ� = [�v�Z�Ώ�]
	FROM [oder].[tOrderSettings]
	WHERE [�ʉ݃y�ANo] = @�ʉ݃y�ANo;

END
GO
/*
*/

