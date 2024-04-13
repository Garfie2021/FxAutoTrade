USE OANDA_DemoB
GO

DROP PROCEDURE [oanda].[spInsertAccount]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [oanda].[spInsertAccount]
    @口座No				Int,
	@日時				datetime,
	@accountId			int,
	@accountName		varchar(50),
	@accountCurrency	varchar(5),
	@marginRate			float,
	@balance			float,
	@unrealizedPl		float,
	@realizedPl			float,
	@marginUsed			float,
	@marginAvail		float,
	@openTrades			int,
	@openOrders			int
AS
BEGIN

	SET NOCOUNT ON;

	INSERT INTO [oanda].[tAccount](
		 口座No,
         [日時]
        ,[accountId]
        ,[accountName]
        ,[accountCurrency]
        ,[marginRate]
        ,[balance]
        ,[unrealizedPl]
        ,[realizedPl]
        ,[marginUsed]
        ,[marginAvail]
        ,[openTrades]
        ,[openOrders]
        ,[登録日時]
    ) VALUES (
		@口座No,
		@日時,
		@accountId,
		@accountName,
		@accountCurrency,
		@marginRate,
		@balance,
		@unrealizedPl,
		@realizedPl,
		@marginUsed,
		@marginAvail,
		@openTrades,
		@openOrders,
		GETDATE()
	);

END
GO
