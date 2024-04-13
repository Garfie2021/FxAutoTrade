USE OANDA_DemoB
GO

DROP PROCEDURE [anls].[spCntデルタRate_通貨ペアNo_登録日時]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [anls].[spCntデルタRate_通貨ペアNo_登録日時]
	@通貨ペアNo	Tinyint,
    @StartDate	DateTime,
    @EndDate	DateTime,
    @cnt		int			OUTPUT
AS
BEGIN

	SET NOCOUNT ON;

	SELECT @cnt = COUNT(*) 
	FROM [anls].[tデルタRate]
	WHERE [通貨ペアNo] = @通貨ペアNo AND 
		@StartDate < [登録日時] AND [登録日時] < @EndDate;

END
GO
