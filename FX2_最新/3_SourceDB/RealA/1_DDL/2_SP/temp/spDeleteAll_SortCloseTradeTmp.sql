USE OANDA_DemoB
GO
/*
*/
DROP PROCEDURE [temp].[spDeleteAll_SortCloseTradeTmp]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [temp].[spDeleteAll_SortCloseTradeTmp]
    @口座No		Int
AS
BEGIN

	DELETE FROM temp.tSortCloseTradeTmp
	WHERE 口座No = @口座No;

END
GO
/*
*/