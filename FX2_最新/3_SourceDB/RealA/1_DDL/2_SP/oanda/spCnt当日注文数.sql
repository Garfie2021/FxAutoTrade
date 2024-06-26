USE OANDA_DemoB
GO

DROP PROCEDURE [oanda].[spCnt当日注文数]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [oanda].[spCnt当日注文数]
    @口座No	Int,
	@from	DateTime,
	@Cnt	int			output
AS
BEGIN

	SELECT @Cnt = COUNT(*)
	FROM [oanda].[tOrderResponse]
	WHERE 口座No = @口座No AND Time >= @from;

END
GO

