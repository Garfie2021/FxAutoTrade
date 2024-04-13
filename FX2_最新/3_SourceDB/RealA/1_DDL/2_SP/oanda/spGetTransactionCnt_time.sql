USE OANDA_DemoB
GO

DROP PROCEDURE [oanda].[spGetTransactionCnt_time]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [oanda].[spGetTransactionCnt_time]
    @口座No		Int,
    @StartDate	DateTime,
    @EndDate	DateTime,
    @cnt		int			OUTPUT
AS
BEGIN

	SET NOCOUNT ON;

	SELECT @cnt = COUNT(*) 
	FROM [oanda].[tTransaction] 
	WHERE 口座No = @口座No AND @StartDate < [time] AND [time] < @EndDate;

END
GO
