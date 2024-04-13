USE OANDA_DemoB
GO

DROP PROCEDURE [fxcm].[spDeleteClosedTrades]
GO
DROP PROCEDURE [acvdel].[spDelete_fxcm_tClosedTrades]
GO


SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [acvdel].[spDelete_fxcm_tClosedTrades]
AS
BEGIN

	SET NOCOUNT ON;

	DECLARE @StartDate datetime = DATEADD(month, -3, getdate());
	
	delete
	FROM [fxcm].tClosedTrades
	where [CloseTime] < @StartDate

END

GO
