USE OANDA_DemoB
GO

DROP PROCEDURE [recu].[spUpdateWMA再計算ALL_Month1]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [recu].[spUpdateWMA再計算ALL_Month1]
AS
BEGIN

	DECLARE @StartDateBegin	datetime;
	SELECT @StartDateBegin = MIN([StartDate]) FROM [hstr].[tMonth1];

	DECLARE @back_Month1 int = DATEDIFF(month, GETDATE(), @StartDateBegin);

	EXECUTE [recu].[spUpdateWMA再計算_n前から_Month1] @back_Month1, -1;

END
GO
