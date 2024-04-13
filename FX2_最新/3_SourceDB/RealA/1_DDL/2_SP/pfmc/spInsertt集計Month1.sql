USE OANDA_DemoB
GO

DROP PROCEDURE [pfmc].[spInsertt集計Month1]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [pfmc].[spInsertt集計Month1]
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

		SELECT TOP 1
			@取引証拠金 = [取引証拠金],
			@維持証拠金 = [維持証拠金],
			@ロスカット余剰金 = [ロスカット余剰金],
			@ポジション数 = [ポジション数]
		FROM [pfmc].[t集計Week1]
		WHERE [口座No] = @口座No AND [StartDate] <= @EndDate
		ORDER BY [StartDate] DESC;

		INSERT INTO [pfmc].[t集計Month1] (
			 [口座No]
			,[StartDate]
			,[注文数]
			,[約定数]
			,[約定金額]
			,[取引証拠金]
			,[有効証拠金]
			,[維持証拠金]
			,[ロスカット余剰金]
			,[ポジション数]
	     )
		 SELECT
		 	 @口座No
			,@StartDate
			,SUM([注文数])
			,SUM([約定数])
			,SUM([約定金額])
			,@取引証拠金
			,@有効証拠金
			,@維持証拠金
			,@ロスカット余剰金
			,@ポジション数
		FROM [pfmc].[t集計Week1]
		WHERE [口座No] = @口座No AND @StartDate <= [StartDate] AND [StartDate] < @EndDate;
		 
		Set @口座No = @口座No + 1;
	end;


END
GO

