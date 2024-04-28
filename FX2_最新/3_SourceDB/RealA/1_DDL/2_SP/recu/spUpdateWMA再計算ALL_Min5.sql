USE OANDA_DemoB
GO

DROP PROCEDURE [recu].[spUpdateWMA�Čv�ZALL_Min5]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [recu].[spUpdateWMA�Čv�ZALL_Min5]
AS
BEGIN

	DECLARE @StartDateBegin	datetime;
	SELECT @StartDateBegin = MIN([StartDate]) FROM [hstr].[tMin5];

	DECLARE @back_Min5 int = DATEDIFF(MINUTE, GETDATE(), @StartDateBegin) / 12;	-- 5�� * 12 = 60��

	EXECUTE [recu].[spUpdateWMA�Čv�Z_n�O����_Min5] @back_Min5, -1;

END
GO


