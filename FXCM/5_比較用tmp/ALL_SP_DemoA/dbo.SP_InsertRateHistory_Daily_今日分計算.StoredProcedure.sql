USE [RealA_FX]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[SP_InsertRateHistory_Daily_今日分計算]
AS
BEGIN

	DECLARE @通貨ペアNo tinyint = 0
	DECLARE @now		Datetime = GETDATE();

	while @通貨ペアNo < 44
	begin

		EXECUTE [dbo].[SP_InsertRateHistory_Daily] @通貨ペアNo, @now, 0

		Set @通貨ペアNo = @通貨ペアNo + 1;

	end;

END


GO
