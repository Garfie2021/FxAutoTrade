USE OANDA_DemoB
GO
/*
*/
DROP PROCEDURE [oanda].[spGetTransaction最終日時]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [oanda].[spGetTransaction最終日時]
    @口座No						Int,
	@OandaTransaction最終日時	datetime	output,
	@OandaTransactionLastId		bigint		output
AS
BEGIN

	SET NOCOUNT ON;

	SELECT 
		@OandaTransaction最終日時 = [time],
		@OandaTransactionLastId = [id]
	FROM [oanda].[tTransaction]
	where 口座No = @口座No
	order by [time] desc;

END
GO
/*
*/
