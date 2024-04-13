USE DemoA_FX
GO

DROP PROCEDURE [fxcm].[spDeleteClosedTrades]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [fxcm].[spDeleteClosedTrades]
AS
BEGIN

	SET NOCOUNT ON;

	DECLARE @StartDate datetime = DATEADD(month, -3, getdate());
	
	delete
	FROM [fxcm].tClosedTrades
	where [CloseTime] < @StartDate

END

GO
