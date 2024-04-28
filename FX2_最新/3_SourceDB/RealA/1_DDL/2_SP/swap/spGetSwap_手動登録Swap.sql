USE OANDA_DemoB
GO

DROP PROCEDURE [swap].[spGetSwap_�蓮�o�^Swap]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [swap].[spGetSwap_�蓮�o�^Swap]
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

	declare @Cnt int = 0;
	SELECT @Cnt = count(*)
	FROM [swap].[tSwap�蓮�o�^_Day1]
	where [�ʉ݃y�ANo] = @�ʉ݃y�ANo and ([����Swap] <> 0 or [����Swap] <> 0)

	if @Cnt > 0
	begin
		SELECT TOP 1 @Swap_���� = [����Swap], @Swap_���� = [����Swap]
		FROM [swap].[tSwap�蓮�o�^_Day1]
		where [�ʉ݃y�ANo] = @�ʉ݃y�ANo and ([����Swap] <> 0 or [����Swap] <> 0)
		order by [StartDate] desc;
	end
	else
	begin
		Set @Swap_���� = 0;
		Set @Swap_���� = 0;
	end

	--select @Swap_����, @Swap_����

END
GO

