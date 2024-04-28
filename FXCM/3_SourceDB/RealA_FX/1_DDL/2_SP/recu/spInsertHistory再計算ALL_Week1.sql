USE [DemoA_FX]
GO

DROP PROCEDURE [recu].[spInsertHistory�Čv�ZALL_Week1]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [recu].[spInsertHistory�Čv�ZALL_Week1]
AS
BEGIN

	DECLARE @StartDateBegin	datetime;
	SELECT @StartDateBegin = MIN([StartDate]) FROM [hstr].[tDay1];

	DECLARE @back_Week1 int = DATEDIFF(WEEK, GETDATE(), @StartDateBegin);

	EXECUTE [recu].[spInsertHistory�Čv�Z_n�O����_Week1] @back_Week1;

END
GO
