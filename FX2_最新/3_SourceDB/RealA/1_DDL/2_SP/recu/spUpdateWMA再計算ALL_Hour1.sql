USE OANDA_DemoB
GO

DROP PROCEDURE [recu].[spUpdateWMA再計算ALL_Hour1]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [recu].[spUpdateWMA再計算ALL_Hour1]
AS
BEGIN

	DECLARE @StartDateBegin	datetime;
	SELECT @StartDateBegin = MIN([StartDate]) FROM [hstr].[tHour1];

	DECLARE @back_Hour1 int = DATEDIFF(HOUR, GETDATE(), @StartDateBegin);

	EXECUTE [recu].[spUpdateWMA再計算_n前から_Hour1] @back_Hour1, -1;

END
GO