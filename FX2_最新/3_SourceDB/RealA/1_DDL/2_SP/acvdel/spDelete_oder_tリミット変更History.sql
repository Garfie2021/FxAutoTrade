USE OANDA_DemoB
GO

DROP PROCEDURE [acvdel].[spDelete_oder_tリミット変更History]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [acvdel].[spDelete_oder_tリミット変更History]
	@back int = -1	-- DemoAは-1。RealAは-1。RealBは-1。
AS
BEGIN

	SET NOCOUNT ON;

	DECLARE @StartDate datetime = DATEADD(day, @back, getdate());
	
	DELETE FROM oder.tリミット変更History
	where [日時] < @StartDate;

END
GO
