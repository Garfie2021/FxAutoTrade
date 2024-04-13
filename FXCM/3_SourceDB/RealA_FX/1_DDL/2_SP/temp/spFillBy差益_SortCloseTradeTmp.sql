USE RealB_2370741683_FX
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
AS
BEGIN

	SELECT TOP (1) 
       [sTradeID]
      ,[iAmount]
      ,[dRate]
      ,[sQuoteID]
	FROM [temp].tSortCloseTradeTmp
	ORDER BY ç∑âv

END
GO
/*
*/