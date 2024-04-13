USE OANDA_DemoB
GO

DROP PROCEDURE [recu].[spUpdateWMA再計算ALL_Min1]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [recu].[spUpdateWMA再計算ALL_Min1]
AS
BEGIN

	DECLARE @StartDateBegin	datetime;
	SELECT @StartDateBegin = MIN([StartDate]) FROM [hstr].[tMin1];

	DECLARE @back_Min1 int = DATEDIFF(MINUTE, GETDATE(), @StartDateBegin);

	EXECUTE [recu].[spUpdateWMA再計算_n前から_Min1] @back_Min1, -1;

END
GO