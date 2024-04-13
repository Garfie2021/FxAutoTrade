USE [RealA_FX]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [indi].[SP_DeleteIndicator_Daily]
AS
BEGIN

	SET NOCOUNT ON;

	DECLARE @StartDate datetime = DATEADD(month, -1, getdate());

	declare @通貨ペアNo tinyint = 0;

	while @通貨ペアNo < 44
	begin
	
		DELETE FROM [indi].T_Indicator_Daily
		where [通貨ペアNo] = @通貨ペアNo and [日時] < @StartDate

		Set @通貨ペアNo = @通貨ペアNo + 1;
	end;

END


GO
