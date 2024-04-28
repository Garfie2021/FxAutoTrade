USE OANDA_DemoB
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
    @����No			Int
AS
BEGIN

	SELECT TOP (1) 
       [sTradeID]
      ,[iAmount]
      ,[dRate]
      ,[sQuoteID]
	FROM [temp].tSortCloseTradeTmp
	WHERE ����No = @����No
	ORDER BY ���v;

END
GO
/*
*/