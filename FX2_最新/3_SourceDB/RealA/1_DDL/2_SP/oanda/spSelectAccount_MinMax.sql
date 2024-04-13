USE OANDA_DemoB
GO

DROP PROCEDURE [oanda].[spSelectAccount_MinMax]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [oanda].[spSelectAccount_MinMax]
    @口座No	Int,
	@from	DateTime,
	@to		DateTime
AS
BEGIN

	SET NOCOUNT ON;

	SELECT *
	from (
		SELECT TOP 1
			 [日時]
			,[accountId]
			,[accountName]
			,[accountCurrency]
			,[marginRate]
			,[balance] as 取引証拠金
			,[unrealizedPl] as 評価損益
			,[realizedPl] as 実現損益
			,[marginUsed] as 必要証拠金
			,[marginAvail] as 余剰証拠金
			,[openTrades]
			,[openOrders]
		FROM [oanda].[tAccount]
		where 口座No = @口座No AND @from > [日時]
		order by [日時] desc
	) as t1 
	UNION
	SELECT *
	from (
		SELECT TOP 1
			 [日時]
			,[accountId]
			,[accountName]
			,[accountCurrency]
			,[marginRate]
			,[balance] as 取引証拠金
			,[unrealizedPl] as 評価損益
			,[realizedPl] as 実現損益
			,[marginUsed] as 必要証拠金
			,[marginAvail] as 余剰証拠金
			,[openTrades]
			,[openOrders]
		FROM [oanda].[tAccount]
		where 口座No = @口座No AND @to > [日時]
		order by [日時] desc
	) as t2 ;

END
GO
