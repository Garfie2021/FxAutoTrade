USE OANDA_DemoB
GO

DROP PROCEDURE [oanda].[spGetBSポジションCnt]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [oanda].[spGetBSポジションCnt]
    @口座No			Int,
	@通貨ペアNo		TinyInt,
	@id				bigint,
	@Cnt			int		output
AS
BEGIN

	SELECT @Cnt = COUNT(*)
	FROM [oanda].[tOrderResponse]
	where 口座No = @口座No AND [通貨ペアNo] = @通貨ペアNo AND [BS開始] = 1 AND [Order_id] >= @id;

END
GO

