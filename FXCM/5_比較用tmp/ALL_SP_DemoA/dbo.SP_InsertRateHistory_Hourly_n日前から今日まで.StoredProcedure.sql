USE [RealA_FX]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[SP_InsertRateHistory_Hourly_n日前から今日まで]
	@back_1h int = -2
AS
BEGIN

	DECLARE @now		Datetime = GETDATE();

	while @back_1h < 1
	begin

		DECLARE @通貨ペアNo tinyint = 0
		while @通貨ペアNo < 44
		begin

			EXECUTE [dbo].[SP_InsertRateHistory_Hourly] @通貨ペアNo, @now, @back_1h

			Set @通貨ペアNo = @通貨ペアNo + 1;
		end;

		Set @back_1h = @back_1h + 1;
	end;

END


GO
