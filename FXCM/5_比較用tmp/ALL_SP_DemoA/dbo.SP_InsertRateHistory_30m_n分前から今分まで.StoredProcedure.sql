USE [RealA_FX]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[SP_InsertRateHistory_30m_n分前から今分まで]
	@back_30m int = -2
AS
BEGIN

	DECLARE @now		Datetime = GETDATE();

	while @back_30m < 1
	begin

		DECLARE @通貨ペアNo tinyint = 0
		while @通貨ペアNo < 44
		begin

			EXECUTE [dbo].[SP_InsertRateHistory_30m] @通貨ペアNo, @now, @back_30m

			Set @通貨ペアNo = @通貨ペアNo + 1;
		end;

		Set @back_30m = @back_30m + 1;
	end;

END


GO
