USE OANDA_DemoB
GO

DROP PROCEDURE [oder].[spChkNearestOrder]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [oder].[spChkNearestOrder]
    @口座No			Int,
	@通貨ペアNo		tinyint,
	@NearestTime	datetime,	-- 通常は現在日時の15分前
	@Order数		int		OUTPUT
AS
BEGIN
	SET NOCOUNT ON;

	/*
	declare @通貨ペアNo		tinyint=37
	declare @NearestTime	datetime='2016/12/29 19:37:41'
	declare @Order数		int
	*/

	SELECT @Order数 = COUNT(*)
	FROM [oder].[tOrderHistory2]
	WHERE 口座No = @口座No AND [通貨ペアNo] = @通貨ペアNo AND [日時] > @NearestTime

	--select @Order数

END
GO
/*
*/
