USE RealB_2370741683_FX
GO

DROP PROCEDURE [swap].[spGet����Swap���ǂ����0�ɂȂ�O��Swap]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [swap].[spGet����Swap���ǂ����0�ɂȂ�O��Swap]
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
	FROM [hstr].[tHour1]
	where [�ʉ݃y�ANo] = @�ʉ݃y�ANo and ([����Swap] <> 0 or [����Swap] <> 0)

	if @Cnt > 0
	begin
		SELECT TOP 1 @Swap_���� = [����Swap], @Swap_���� = [����Swap]
		FROM [hstr].[tHour1]
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

