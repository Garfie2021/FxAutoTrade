USE OANDA_DemoB
GO
/*
*/
DROP PROCEDURE [hstr].[spGet�ŐVRate]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [hstr].[spGet�ŐVRate]
	@�ʉ݃y�ANo	tinyint,
	@����Rate	float	output,
	@����Rate	float	output
AS
BEGIN

	SELECT TOP 1
		@����Rate = [����Rate],
		@����Rate = [����Rate]
	FROM [hstr].[tSec]
	where [�ʉ݃y�ANo] = @�ʉ݃y�ANo
	order by [StartDate] desc;

END
GO
/*
*/

