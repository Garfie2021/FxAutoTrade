USE OANDA_DemoB
GO

DROP PROCEDURE [oder].[spSelectOrderHistory2_注文単位]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [oder].[spSelectOrderHistory2_注文単位]
    @口座No	Int,
	@from	DateTime,
	@to		DateTime
AS
BEGIN
	/*
    declare @口座No	Int = 1;
	declare @from	DateTime = '1900/01/01';
	declare @to		DateTime = '2100/01/01';
	*/

	SELECT
		 a.[通貨ペアNo]
		,b.[ペア名] as 通貨ペア名
		,a.[日時]
		,a.[注文単位]
		,a.[注文単位を割る値]
		,a.[ロスカット余剰金]
		,a.[ロスカット余剰金調整値]
		,a.[買いRate]
		,a.[売りRate]
	FROM [oder].[tOrderHistory2] as a LEFT JOIN [cmn].[t通貨ペアMst] as b ON a.[通貨ペアNo] = b.[No]
	where a.口座No = @口座No AND @from <= a.[日時] and a.[日時] < @to
	order by a.[通貨ペアNo], a.[日時] desc;

END
GO
/*
*/