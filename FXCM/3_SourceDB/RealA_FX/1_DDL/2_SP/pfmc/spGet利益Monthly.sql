USE RealB_2370741683_FX
GO
/*
*/
DROP PROCEDURE [pfmc].[spGet���vMonthly]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [pfmc].[spGet���vMonthly]
	@�N��					date,
	@���v�m��J�n�ȍ~�̗��v	int		output,
	@�o���\�z				int		output
AS
BEGIN

	--declare @�N��					date = '2016/03/01 00:00:00'
	--declare @���v�m��J�n�ȍ~�̗��v	int
	--declare @�o���\�z				int

	SELECT
		@���v�m��J�n�ȍ~�̗��v = ���v�m��J�n�ȍ~�̗��v, 
		@�o���\�z = �o���\�z
	FROM [pfmc].[t���vMonthly]
	WHERE �N�� = @�N��;

	--select @���v�m��J�n�ȍ~�̗��v, @�o���\�z

END
GO
/*
*/