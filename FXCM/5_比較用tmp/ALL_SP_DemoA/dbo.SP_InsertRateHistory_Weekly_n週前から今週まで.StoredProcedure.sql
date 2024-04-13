USE [RealA_FX]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[SP_InsertRateHistory_Weekly_n週前から今週まで]
	@back_Weekly int = -2
AS
BEGIN

	DECLARE @now		Datetime = GETDATE();

	while @back_Weekly < 1
	begin

		DECLARE @通貨ペアNo tinyint = 0
		while @通貨ペアNo < 44
		begin

			EXECUTE [dbo].[SP_InsertRateHistory_Weekly] @通貨ペアNo, @now, @back_Weekly

			Set @通貨ペアNo = @通貨ペアNo + 1;
		end;

		Set @back_Weekly = @back_Weekly + 1;
	end;

END


GO
