USE [RealA_FX]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[SP_InsertRateHistory_5m_n分前から今分まで]
	@back_5m int = -2
AS
BEGIN

	DECLARE @now		Datetime = GETDATE();

	while @back_5m < 1
	begin

		DECLARE @通貨ペアNo tinyint = 0
		while @通貨ペアNo < 44
		begin

			EXECUTE [dbo].[SP_InsertRateHistory_5m] @通貨ペアNo, @now, @back_5m

			Set @通貨ペアNo = @通貨ペアNo + 1;
		end;

		Set @back_5m = @back_5m + 1;
	end;

END


GO
