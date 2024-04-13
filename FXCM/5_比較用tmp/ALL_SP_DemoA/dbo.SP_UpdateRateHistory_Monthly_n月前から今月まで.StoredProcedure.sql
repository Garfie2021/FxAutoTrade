USE [RealA_FX]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[SP_UpdateRateHistory_Monthly_n月前から今月まで]
	@back_Month int = -2
AS
BEGIN

	DECLARE @now		Datetime = GETDATE();

	while @back_Month < 1
	begin

		DECLARE @通貨ペアNo tinyint = 0
		while @通貨ペアNo < 44
		begin

			EXECUTE [dbo].[SP_UpdateRateHistory_Monthly] @通貨ペアNo, @now, @back_Month

			Set @通貨ペアNo = @通貨ペアNo + 1;
		end;

		Set @back_Month = @back_Month + 1;
	end;

END


GO
