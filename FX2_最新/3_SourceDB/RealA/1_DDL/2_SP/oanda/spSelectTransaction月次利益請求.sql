USE OANDA_DemoB
GO

DROP PROCEDURE [oanda].[spSelectTransaction月次利益請求]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [oanda].[spSelectTransaction月次利益請求]
    @口座No	Int,
	@from	DateTime,
	@to		DateTime
AS
BEGIN

	SET NOCOUNT ON;

	SELECT
		 [id]
		,[accountId]
		,SUM([pl]) AS 利益
	FROM [oanda].[tTransaction]
	where 口座No = @口座No AND 
		@from <= [time] AND [time] < @to AND
		[type] = 'CLOSE？　だけではないはず'
	group by [id], [accountId], [pl]

END
GO
