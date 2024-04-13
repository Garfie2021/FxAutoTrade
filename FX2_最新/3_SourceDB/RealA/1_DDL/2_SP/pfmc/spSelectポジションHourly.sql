USE OANDA_DemoB
GO
/*
*/
DROP PROCEDURE [pfmc].[spSelectポジションHourly]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [pfmc].[spSelectポジションHourly]
	@口座No int,
	@from	DateTime,
	@to		DateTime
AS
BEGIN

	SELECT *
	from (
		SELECT TOP 1
			[StartDate],
			[保有可能ポジション数],
			[決算待ちポジション数],
			[当日注文数],
			[当日約定数],
			[当日約定金額],
			[取引証拠金],
			[有効証拠金],
			[維持証拠金],
			[ロスカット余剰金],
			[余剰金の割合]
		FROM [pfmc].[tポジションHourly]
		where [口座No] = @口座No AND @from <= [StartDate] and [StartDate] < @to
		order by [StartDate]
	) as t1 
	UNION
	SELECT *
	from (
		SELECT TOP 1
			[StartDate],
			[保有可能ポジション数],
			[決算待ちポジション数],
			[当日注文数],
			[当日約定数],
			[当日約定金額],
			[取引証拠金],
			[有効証拠金],
			[維持証拠金],
			[ロスカット余剰金],
			[余剰金の割合]
		FROM [pfmc].[tポジションHourly]
		where [口座No] = @口座No AND @from <= [StartDate] and [StartDate] < @to
		order by [StartDate] desc
	) as t2 ;

END
GO
/*
*/