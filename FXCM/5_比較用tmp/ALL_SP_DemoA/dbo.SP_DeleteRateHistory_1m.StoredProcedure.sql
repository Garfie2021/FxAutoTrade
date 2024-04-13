USE [RealA_FX]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[SP_DeleteRateHistory_1m]
AS
BEGIN

	SET NOCOUNT ON;

	DECLARE @StartDate datetime = DATEADD(day, -3, getdate());

	declare @通貨ペアNo tinyint = 0;

	while @通貨ペアNo < 44
	begin
	
		delete
		FROM [dbo].[T_RateHistory_1m]
		where [通貨ペアNo] = @通貨ペアNo and [日時] < @StartDate

		Set @通貨ペアNo = @通貨ペアNo + 1;
	end;

END


GO
