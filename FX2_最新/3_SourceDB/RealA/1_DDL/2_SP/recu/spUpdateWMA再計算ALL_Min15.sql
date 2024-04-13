USE OANDA_DemoB
GO

DROP PROCEDURE [recu].[spUpdateWMA再計算ALL_Min15]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [recu].[spUpdateWMA再計算ALL_Min15]
AS
BEGIN

	DECLARE @StartDateBegin	datetime;
	SELECT @StartDateBegin = MIN([StartDate]) FROM [hstr].[tMin15];

	DECLARE @back_Min15 int = DATEDIFF(MINUTE, GETDATE(), @StartDateBegin) / 4;	-- 15分 * 4 = 60分

	EXECUTE [recu].[spUpdateWMA再計算_n前から_Min15] @back_Min15, -1;

END
GO
