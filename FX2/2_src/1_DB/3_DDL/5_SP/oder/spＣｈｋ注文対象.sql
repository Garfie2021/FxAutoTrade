USE [FX2_DemoA]
GO

DROP PROCEDURE [oder].[spChk�����Ώ�]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [oder].[spChk�����Ώ�]
	@�ʉ݃y�ANo	tinyint,
	@�����Ώ�	tinyint OUTPUT
AS
BEGIN

	SELECT @�����Ώ� = [�����Ώ�]
	FROM [oder].[tOrderSettings]
	WHERE [�ʉ݃y�ANo] = @�ʉ݃y�ANo;

END
GO
/*
*/

