USE OANDA_DemoB
GO

DROP PROCEDURE [acvdel].[spDelete_oanda_tTrade]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [acvdel].[spDelete_oanda_tTrade]
	@back int = -1	-- DemoAÇÕ-1ÅBRealAÇÕ-1ÅBRealBÇÕ-1ÅB
AS
BEGIN

	SET NOCOUNT ON;

	DECLARE @StartDate datetime = DATEADD(day, @back, getdate());
	
	DELETE FROM oanda.tTrade
	where [time] < @StartDate;

END

GO
