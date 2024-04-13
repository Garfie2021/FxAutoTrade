USE OANDA_DemoB
GO

DROP PROCEDURE [oanda].[spCntAccount_口座No_日時]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [oanda].[spCntAccount_口座No_日時]
	@口座No		int,
    @StartDate	DateTime,
    @EndDate	DateTime,
    @cnt		int			OUTPUT
AS
BEGIN

	SET NOCOUNT ON;

	SELECT @cnt = COUNT(*) 
	FROM [oanda].[tAccount]
	WHERE [口座No] = @口座No AND 
		@StartDate < [日時] AND [日時] < @EndDate;

END
GO
