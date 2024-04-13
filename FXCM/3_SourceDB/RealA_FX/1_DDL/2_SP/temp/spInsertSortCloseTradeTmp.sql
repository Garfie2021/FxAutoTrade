USE RealB_2370741683_FX
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
	@Time		datetime,
	@sTradeID	varchar(50),
	@ç∑âv		float,
	@iAmount	int,
	@dRate		float,
	@sQuoteID	varchar(100)
AS
BEGIN

	INSERT INTO [temp].[tSortCloseTradeTmp] (
		[Time], 
		[sTradeID], 
		[ç∑âv], 
		[iAmount], 
		[dRate], 
		[sQuoteID]
	) VALUES (
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