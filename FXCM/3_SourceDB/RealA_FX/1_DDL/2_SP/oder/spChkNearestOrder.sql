USE DemoA_FX
GO

DROP PROCEDURE [oder].[spChkNearestOrder]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [oder].[spChkNearestOrder]
	 @通貨ペアNo	tinyint
	,@NearestTime	datetime	-- 通常は現在日時の15分前
	,@Order数		tinyint	OUTPUT
AS
BEGIN

	SET NOCOUNT ON;

	SELECT @Order数 = COUNT(*)
	FROM [oder].[tOrderHistory]
	WHERE [通貨ペアNo] = @通貨ペアNo AND [日時] > @NearestTime

END
GO
