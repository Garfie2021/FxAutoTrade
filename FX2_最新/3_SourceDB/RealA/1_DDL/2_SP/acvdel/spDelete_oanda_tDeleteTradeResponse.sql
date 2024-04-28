USE OANDA_DemoB
GO

DROP PROCEDURE [acvdel].[spDelete_oanda_tDeleteTradeResponse]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [acvdel].[spDelete_oanda_tDeleteTradeResponse]
	@back int = -1	-- DemoA��-1�BRealA��-1�BRealB��-1�B
AS
BEGIN

	SET NOCOUNT ON;

	DECLARE @StartDate datetime = DATEADD(day, @back, getdate());
	
	DELETE FROM oanda.tDeleteTradeResponse
	where [time] < @StartDate;

END

GO
