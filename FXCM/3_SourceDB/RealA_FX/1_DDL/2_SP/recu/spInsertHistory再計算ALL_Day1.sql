USE [DemoA_FX]
GO

DROP PROCEDURE [recu].[spInsertHistory�Čv�ZALL_Day1]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [recu].[spInsertHistory�Čv�ZALL_Day1]
AS
BEGIN

	DECLARE @StartDateBegin	datetime;
	SELECT @StartDateBegin = MIN([StartDate]) FROM [hstr].[tHour1];

	DECLARE @back_Day1 int = DATEDIFF(day, GETDATE(), @StartDateBegin);

	EXECUTE [recu].[spInsertHistory�Čv�Z_n�O����_Day1] @back_Day1;

END
GO
