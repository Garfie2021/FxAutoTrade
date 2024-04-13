USE OANDA_DemoB
GO

DROP PROCEDURE [oanda].[spSelectTrade]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [oanda].[spSelectTrade]
    @口座No	Int,
	@from	DateTime,
	@to		DateTime
AS
BEGIN

	SET NOCOUNT ON;

	SELECT
		 [id]
		,[units]
		,[side]
		,[instrument]
		,[time]
		,[price]
		,[takeProfit]
		,[stopLoss]
		,[trailingStop]
		,[trailingAmount]
	FROM [oanda].[tTrade]
	where 口座No = @口座No AND @from <= [time] and [time] < @to
	order by [time];

END
GO
