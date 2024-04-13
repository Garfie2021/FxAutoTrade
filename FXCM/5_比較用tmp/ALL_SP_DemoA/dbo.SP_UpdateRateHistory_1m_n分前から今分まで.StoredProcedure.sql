USE [RealA_FX]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[SP_UpdateRateHistory_1m_n分前から今分まで]
	@back_1m int = -2
AS
BEGIN

	DECLARE @now		Datetime = GETDATE();

	while @back_1m < 1
	begin

		DECLARE @通貨ペアNo tinyint = 0
		while @通貨ペアNo < 44
		begin

			EXECUTE [dbo].[SP_UpdateRateHistory_1m] @通貨ペアNo, @now, @back_1m

			Set @通貨ペアNo = @通貨ペアNo + 1;
		end;

		Set @back_1m = @back_1m + 1;
	end;

END


GO
