USE RealB_2370741683_FX
GO
/*
*/
DROP PROCEDURE [temp].[spFillBy���v_SortCloseTradeTmp]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [temp].[spFillBy���v_SortCloseTradeTmp]
AS
BEGIN

	SELECT TOP (1) 
       [sTradeID]
      ,[iAmount]
      ,[dRate]
      ,[sQuoteID]
	FROM [temp].tSortCloseTradeTmp
	ORDER BY ���v

END
GO
/*
*/