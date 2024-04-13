USE OANDA_DemoB
GO
/*
*/
DROP PROCEDURE [temp].[spFillByç∑âv_SortCloseTradeTmp]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [temp].[spFillByç∑âv_SortCloseTradeTmp]
    @å˚ç¿No			Int
AS
BEGIN

	SELECT TOP (1) 
       [sTradeID]
      ,[iAmount]
      ,[dRate]
      ,[sQuoteID]
	FROM [temp].tSortCloseTradeTmp
	WHERE å˚ç¿No = @å˚ç¿No
	ORDER BY ç∑âv;

END
GO
/*
*/