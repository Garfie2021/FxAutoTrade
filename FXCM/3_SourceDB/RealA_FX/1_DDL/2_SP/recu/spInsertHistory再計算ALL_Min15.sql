USE [DemoA_FX]
GO

DROP PROCEDURE [recu].[spInsertHistory�Čv�ZALL_Min15]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [recu].[spInsertHistory�Čv�ZALL_Min15]
AS
BEGIN

	DECLARE @StartDateBegin	datetime;
	SELECT @StartDateBegin = MIN([StartDate]) FROM [hstr].[tMin5];

	DECLARE @back_Min15 int = DATEDIFF(MINUTE, GETDATE(), @StartDateBegin) / 4;	-- 15�� * 4 = 60��

	EXECUTE [recu].[spInsertHistory�Čv�Z_n�O����_Min5] @back_Min15;

END
GO
