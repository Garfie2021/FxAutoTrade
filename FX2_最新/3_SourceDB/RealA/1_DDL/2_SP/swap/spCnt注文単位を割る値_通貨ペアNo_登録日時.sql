USE OANDA_DemoB
GO

DROP PROCEDURE [swap].[spCntSwap手動登録_Day1_StartDate]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [swap].[spCntSwap手動登録_Day1_StartDate]
    @StartDate	DateTime,
    @EndDate	DateTime,
    @cnt		int			OUTPUT
AS
BEGIN

	SET NOCOUNT ON;

	SELECT @cnt = COUNT(*) 
	FROM [swap].[tSwap手動登録_Day1]
	WHERE @StartDate < [StartDate] AND [StartDate] < @EndDate;

END
GO
