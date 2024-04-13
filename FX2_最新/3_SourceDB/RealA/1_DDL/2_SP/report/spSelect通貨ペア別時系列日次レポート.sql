USE OANDA_DemoB
GO

DROP PROCEDURE [report].[spSelect通貨ペア別時系列日次レポート]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [report].[spSelect通貨ペア別時系列日次レポート]
AS
BEGIN

	SELECT 'oanda.tTrade', [time] 
	FROM [OANDA_DemoB].[oanda].[tTrade]
	union
	SELECT 'oder.tOrderHistory2', [日時] 
	FROM [OANDA_DemoB].[oder].[tOrderHistory2]

END
GO

