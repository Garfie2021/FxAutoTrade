USE [DemoA_FX]
GO

DROP PROCEDURE [recu].[spInsertHistory再計算ALL_Day1]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [recu].[spInsertHistory再計算ALL_Day1]
AS
BEGIN

	DECLARE @StartDateBegin	datetime;
	SELECT @StartDateBegin = MIN([StartDate]) FROM [hstr].[tHour1];

	DECLARE @back_Day1 int = DATEDIFF(day, GETDATE(), @StartDateBegin);

	EXECUTE [recu].[spInsertHistory再計算_n前から_Day1] @back_Day1;

END
GO
