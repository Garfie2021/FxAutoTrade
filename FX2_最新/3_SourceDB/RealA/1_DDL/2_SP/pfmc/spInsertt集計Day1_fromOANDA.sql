USE OANDA_DemoB
GO

DROP PROCEDURE [pfmc].[spInsertt集計Day1_fromOANDA]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [pfmc].[spInsertt集計Day1_fromOANDA]
	@StartDate	datetime,
	@EndDate	datetime
AS
BEGIN

	declare	@口座NoMax int = (select MAX([口座No]) from [cmn].[t口座マスタ]);

	declare	@口座No int = 1;	-- 「口座No=0」は除外
	declare	@注文数	int = null;
	declare	@リミット変更数	int = null;
	declare	@約定数	int = null;
	declare	@約定金額 float = null;
	declare	@取引証拠金	float = null;
	declare	@有効証拠金	float = null;
	declare	@維持証拠金	float = null;
	declare	@ロスカット余剰金 float = null;
	declare	@ポジション数 int = null;
	
	while @口座No < @口座NoMax
	begin

		SELECT
			@注文数 = COUNT(*)
		FROM [oanda].[tTransaction]
		WHERE [口座No] = @口座No AND @StartDate <= time AND time < @EndDate AND [type]='MARKET_ORDER_CREATE';

		SELECT
			@リミット変更数 = COUNT(*)
		FROM [oanda].[tTransaction]
		WHERE [口座No] = @口座No AND @StartDate <= time AND time < @EndDate AND [type]='TRADE_UPDATE';

		SELECT
			@約定数 = COUNT(*),
			@約定金額 = SUM([pl])
		FROM [oanda].[tTransaction]
		WHERE [口座No] = @口座No AND @StartDate <= time AND time < @EndDate AND [type]='TRADE_CLOSE';

		SELECT TOP 1
			@取引証拠金 = [balance],
			@維持証拠金 = [marginUsed],
			@ロスカット余剰金 = [marginAvail],
			@ポジション数 = [openTrades]
		FROM [oanda].[tAccount]
		WHERE [口座No] = @口座No AND [日時] <= @EndDate
		ORDER BY [日時] DESC;

		INSERT INTO [pfmc].[t集計Day1] (
			 [口座No]
			,[StartDate]
			,[注文数]
			,[リミット変更数]
			,[約定数]
			,[約定金額]
			,[取引証拠金]
			,[有効証拠金]
			,[維持証拠金]
			,[ロスカット余剰金]
			,[ポジション数]
	     ) VALUES (
			 @口座No
			,@StartDate
			,@注文数
			,@リミット変更数
			,@約定数
			,@約定金額
			,@取引証拠金
			,@有効証拠金
			,@維持証拠金
			,@ロスカット余剰金
			,@ポジション数
		);

		Set @口座No = @口座No + 1;
	end;


END
GO

