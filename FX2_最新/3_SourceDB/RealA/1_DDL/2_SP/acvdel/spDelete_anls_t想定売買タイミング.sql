USE OANDA_DemoB
GO

DROP PROCEDURE [acvdel].[spDelete_anls_t想定売買タイミング]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [acvdel].[spDelete_anls_t想定売買タイミング]
	@back int = -1	-- DemoAは-1。RealAは-1。RealBは-1。
AS
BEGIN

	SET NOCOUNT ON;

	DECLARE @StartDate datetime = DATEADD(day, @back, getdate());

	declare @通貨ペアNo tinyint = 0;
	DECLARE @通貨ペアNoMax tinyint = (SELECT MAX(No) from [cmn].[t通貨ペアMst]);

	WHILE @通貨ペアNo <= @通貨ペアNoMax
	begin
	
		DELETE FROM anls.t想定売買タイミング
		where [通貨ペアNo] = @通貨ペアNo and [StartDateDay1] < @StartDate

		Set @通貨ペアNo = @通貨ペアNo + 1;
	end;

END

GO
