USE [RealA_FX]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[SP_UpdateRateHistory_6h_n6h前から今まで]
	@back_6h int = -2
AS
BEGIN

	--DECLARE @back_6h int = -120;

	DECLARE @now		Datetime = GETDATE();

	while @back_6h < 1
	begin

		DECLARE @通貨ペアNo tinyint = 0
		while @通貨ペアNo < 44
		begin

			--print @通貨ペアNo
			--print @now
			--print @back_6h

			EXECUTE [dbo].[SP_UpdateRateHistory_6h] @通貨ペアNo, @now, @back_6h

			Set @通貨ペアNo = @通貨ペアNo + 1;
		end;

		Set @back_6h = @back_6h + 1;
	end;

END

GO
