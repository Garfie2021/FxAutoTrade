USE OANDA_DemoB
GO

DROP PROCEDURE [pfmc].[spInsertポジションHourly]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [pfmc].[spInsertポジションHourly]
	@口座No					int,
	@保有可能ポジション数	float
	,@決算待ちポジション数	float
	,@当日注文数			float
	,@当日約定数			float
	,@当日約定金額			float
	,@取引証拠金			float
	,@有効証拠金			float
	,@維持証拠金			float
	,@ロスカット余剰金		float
	,@余剰金の割合			float
AS
BEGIN

	SET NOCOUNT ON;

	INSERT INTO [pfmc].[tポジションHourly] (
		[口座No],
		[StartDate]
		,[保有可能ポジション数]
		,[決算待ちポジション数]
		,当日注文数
		,当日約定数
		,当日約定金額
		,[取引証拠金]
		,[有効証拠金]
		,[維持証拠金]
		,[ロスカット余剰金]
		,[余剰金の割合]
	) VALUES (
		@口座No,
		GETDATE()
		,@保有可能ポジション数
		,@決算待ちポジション数
		,@当日注文数
		,@当日約定数
		,@当日約定金額
		,@取引証拠金
		,@有効証拠金
		,@維持証拠金
		,@ロスカット余剰金
		,@余剰金の割合
	);


END
GO
