USE OANDA_RealA
GO

DROP PROCEDURE [swap].[spGet�蓮�o�^�ςݍŐVSwap]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [swap].[spGet�蓮�o�^�ςݍŐVSwap]
	@�ʉ݃y�ANo		tinyint,
	@Swap_����		float	output,
	@Swap_����		float	output
AS
BEGIN

	/*
	DECLARE @�ʉ݃y�ANo		tinyint = 22
	DECLARE @Swap_����		float
	DECLARE @Swap_����		float
	*/
	
	SELECT TOP 1 @Swap_���� = [����Swap], @Swap_���� = [����Swap]
	FROM [OANDA_RealA].[swap].[tSwap�蓮�o�^_Day1]
	where [�ʉ݃y�ANo] = @�ʉ݃y�ANo
	ORDER BY [StartDate] DESC;

	--select @Swap_����, @Swap_����

END
GO

