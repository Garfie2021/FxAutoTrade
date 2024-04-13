USE OANDA_DemoB
GO

DROP PROCEDURE [recu].[spUpdateWMA再計算ALL_Week1]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [recu].[spUpdateWMA再計算ALL_Week1]
AS
BEGIN

	DECLARE @StartDateBegin	datetime;
	SELECT @StartDateBegin = MIN([StartDate]) FROM [hstr].[tWeek1];

	DECLARE @back_Week1 int = DATEDIFF(WEEK, GETDATE(), @StartDateBegin);

	EXECUTE [recu].[spUpdateWMA再計算_n前から_Week1] @back_Week1, -1;

END
GO
