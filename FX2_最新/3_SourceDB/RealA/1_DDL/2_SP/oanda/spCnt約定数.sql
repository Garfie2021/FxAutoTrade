USE OANDA_DemoB
GO

DROP PROCEDURE [oanda].[spCnt��萔]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [oanda].[spCnt��萔]
    @����No	Int,
	@from	DateTime,
	@Cnt	int			output
AS
BEGIN

	SELECT @Cnt = COUNT(*)
	FROM [oanda].[tTransaction]
	where ����No = @����No AND [type] = 'CloseOrder' AND [Time] >= @from;

END
GO

