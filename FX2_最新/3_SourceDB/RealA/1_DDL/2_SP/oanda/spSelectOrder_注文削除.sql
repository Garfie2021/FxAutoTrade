USE OANDA_DemoB
GO

DROP PROCEDURE [oanda].[spSelectOrder_注文削除]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [oanda].[spSelectOrder_注文削除]
    @口座No	Int,
	@from	DateTime,
	@to		DateTime
AS
BEGIN

	SET NOCOUNT ON;

	SELECT
		 [日時]
		,[注文削除対象id]
		,[id]
		,[instrument]
		,[units]
		,[side]
		,[type]
		,[time]
		,[price]
		,[takeProfit]
		,[stopLoss]
		,[expiry]
		,[upperBound]
		,[lowerBound]
		,[trailingStop]
	FROM [oanda].[tOrder_注文削除]
	where 口座No = @口座No AND @from <= [日時] and [日時] < @to
	order by [日時];

END
GO
