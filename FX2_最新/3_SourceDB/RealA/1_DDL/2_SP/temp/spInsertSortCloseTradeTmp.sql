USE OANDA_DemoB
GO
/*
*/
DROP PROCEDURE [temp].[spInsertSortCloseTradeTmp]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [temp].[spInsertSortCloseTradeTmp]
    @����No		Int,
	@Time		datetime,
	@sTradeID	varchar(50),
	@���v		float,
	@iAmount	int,
	@dRate		float,
	@sQuoteID	varchar(100)
AS
BEGIN

	INSERT INTO [temp].[tSortCloseTradeTmp] (
		����No,
		[Time], 
		[sTradeID], 
		[���v], 
		[iAmount], 
		[dRate], 
		[sQuoteID]
	) VALUES (
		@����No,
		@Time, 
		@sTradeID, 
		@���v, 
		@iAmount, 
		@dRate, 
		@sQuoteID
	);

END
GO
/*
*/