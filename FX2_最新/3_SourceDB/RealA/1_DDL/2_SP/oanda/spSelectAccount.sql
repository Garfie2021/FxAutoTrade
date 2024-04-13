USE OANDA_DemoB
GO

DROP PROCEDURE [oanda].[spSelectAccount]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [oanda].[spSelectAccount]
    @口座No	Int,
	@from	DateTime,
	@to		DateTime
AS
BEGIN

	SET NOCOUNT ON;

	SELECT 
		 [日時]
		--,[accountId]
		--,[accountName]
		--,[accountCurrency]
		--,[marginRate]
		,[balance] as 取引証拠金
		,[unrealizedPl] as 評価損益
		,[realizedPl]
		,[marginUsed] as 維持証拠金
		,[marginAvail] as ロスカット余剰金
		,[openTrades]
		,[openOrders]
	FROM [oanda].[tAccount]
	where 口座No = @口座No AND @from <= [日時] and [日時] < @to
	order by [日時] desc;

END
GO
