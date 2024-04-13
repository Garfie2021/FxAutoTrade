USE OANDA_DemoB
GO

DROP PROCEDURE [acvdel].[spDelete_oanda_tTrade_リミット変更]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [acvdel].[spDelete_oanda_tTrade_リミット変更]
	@back int = -1	-- DemoAは-1。RealAは-1。RealBは-1。
AS
BEGIN

	SET NOCOUNT ON;

	DECLARE @StartDate datetime = DATEADD(day, @back, getdate());
	
	DELETE FROM oanda.tTrade_リミット変更
	where [time] < @StartDate;

END
GO
