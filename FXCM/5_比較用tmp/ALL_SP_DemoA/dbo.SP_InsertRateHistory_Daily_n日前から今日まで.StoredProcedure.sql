USE [RealA_FX]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[SP_InsertRateHistory_Daily_n日前から今日まで]
	@back_Daily int = -2
AS
BEGIN

	DECLARE @now		Datetime = GETDATE();

	while @back_Daily < 1
	begin

		DECLARE @通貨ペアNo tinyint = 0
		while @通貨ペアNo < 44
		begin

			EXECUTE [dbo].[SP_InsertRateHistory_Daily] @通貨ペアNo, @now, @back_Daily

			Set @通貨ペアNo = @通貨ペアNo + 1;
		end;

		Set @back_Daily = @back_Daily + 1;
	end;

END


GO
