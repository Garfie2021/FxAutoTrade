USE [FX_DemoB]
GO

DROP PROCEDURE [mtnc].[SP_CleanRate以外のデータを全て削除]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [mtnc].[SP_CleanRate以外のデータを全て削除]
AS
BEGIN

	SET NOCOUNT ON;

	delete from [acv].[T_ClosedTrades_Past]
	delete from [dbo].[T_AccountsHistory]
	delete from [dbo].[T_ClosedTrades]
	delete from [dbo].[T_OrderHistory]
	delete from [dbo].[T_Order判定History]
	delete from [dbo].[T_Trades]
	delete from [dbo].[T_TradeSumury_買い]
	delete from [dbo].[T_システム状況]
	delete from [dbo].[T_危険度]
	delete from [dbo].[T_SortCloseTradeTmp]
	delete from [dbo].[T_SortTmp]
	delete from [dbo].[T_差損益History]
	delete from [dbo].[T_注文設定History]
	delete from [dbo].[T_注文設定History2]
	delete from [dbo].[T_分析SortTmp]
	delete from [dbo].[T_利益_Monthly]
	delete from [dbo].[T_利益History_Monthly]
	delete from [fxcm].[T_Rate_15m]
	delete from [fxcm].[T_Rate_1m]
	delete from [fxcm].[T_Rate_Daily]
	delete from [fxcm].[T_Rate_Monthly]
	delete from [fxcm].[T_Rate_Weekly]
	delete from [hltc].[T_システム異常発生件数_Daily]
	delete from [smlt].[T_Indicator_15m]
	delete from [smlt].[T_Order判定History]


END
GO
