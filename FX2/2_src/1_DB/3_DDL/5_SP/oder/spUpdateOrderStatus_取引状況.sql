USE [FX2_DemoA]
GO

DROP PROCEDURE [oder].[spUpdateOrderStatus_�����]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [oder].[spUpdateOrderStatus_�����]
	@�ʉ݃y�ANo	tinyint,
	@�����Ώ�	varchar(100)
AS
BEGIN

	UPDATE [oder].[tOrderStatus]
	SET [�����] = @�����Ώ�
	WHERE [�ʉ݃y�ANo] = @�ʉ݃y�ANo;

END
GO
/*
*/

