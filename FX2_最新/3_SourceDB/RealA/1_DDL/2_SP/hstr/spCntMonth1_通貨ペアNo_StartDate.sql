USE OANDA_DemoB
GO

DROP PROCEDURE [hstr].[spCntMonth1_通貨ペアNo_StartDate]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [hstr].[spCntMonth1_通貨ペアNo_StartDate]
	@通貨ペアNo	Tinyint,
    @StartDate	DateTime,
    @EndDate	DateTime,
    @cnt		int			OUTPUT
AS
BEGIN

	SET NOCOUNT ON;

	SELECT @cnt = COUNT(*) 
	FROM [hstr].[tMonth1]
	WHERE [通貨ペアNo] = @通貨ペアNo AND 
		@StartDate < [StartDate] AND [StartDate] < @EndDate;

END
GO
