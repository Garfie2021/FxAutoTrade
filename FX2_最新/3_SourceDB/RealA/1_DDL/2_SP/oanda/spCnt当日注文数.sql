USE OANDA_DemoB
GO

DROP PROCEDURE [oanda].[spCnt����������]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [oanda].[spCnt����������]
    @����No	Int,
	@from	DateTime,
	@Cnt	int			output
AS
BEGIN

	SELECT @Cnt = COUNT(*)
	FROM [oanda].[tOrderResponse]
	WHERE ����No = @����No AND Time >= @from;

END
GO

