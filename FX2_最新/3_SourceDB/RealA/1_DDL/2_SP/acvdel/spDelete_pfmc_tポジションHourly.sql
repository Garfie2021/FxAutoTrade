USE OANDA_DemoB
GO

DROP PROCEDURE [acvdel].[spDelete_pfmc_tポジションHourly]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [acvdel].[spDelete_pfmc_tポジションHourly]
	@back int = -1	-- DemoAは-1。RealAは-1。RealBは-1。
AS
BEGIN

	SET NOCOUNT ON;

	DECLARE @StartDate datetime = DATEADD(day, @back, getdate());
	
	DELETE FROM pfmc.tポジションHourly
	where [StartDate] < @StartDate;

END
GO
