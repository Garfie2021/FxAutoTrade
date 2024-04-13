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
    @å˚ç¿No		Int,
	@Time		datetime,
	@sTradeID	varchar(50),
	@ç∑âv		float,
	@iAmount	int,
	@dRate		float,
	@sQuoteID	varchar(100)
AS
BEGIN

	INSERT INTO [temp].[tSortCloseTradeTmp] (
		å˚ç¿No,
		[Time], 
		[sTradeID], 
		[ç∑âv], 
		[iAmount], 
		[dRate], 
		[sQuoteID]
	) VALUES (
		@å˚ç¿No,
		@Time, 
		@sTradeID, 
		@ç∑âv, 
		@iAmount, 
		@dRate, 
		@sQuoteID
	);

END
GO
/*
*/