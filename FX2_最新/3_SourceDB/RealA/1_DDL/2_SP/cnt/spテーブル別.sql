USE OANDA_DemoB
GO
/*
*/
DROP PROCEDURE [cnt].[spテーブル別]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [cnt].[spテーブル別]
AS
BEGIN

	SELECT 'anls.t想定売買タイミング' as tablename, count(*) as cnt, MIN([StartDateMin1]) as 日時_Min, MAX([StartDateMin1]) as 日時_Max
	FROM anls.t想定売買タイミング
	UNION
	SELECT 'anls.t想定売買タイミング_Swap判定無し' as tablename, count(*) as cnt, MIN([StartDateMin1]) as 日時_Min, MAX([StartDateMin1]) as 日時_Max
	FROM anls.t想定売買タイミング_Swap判定無し
	UNION

	SELECT 'cmn.t通貨ペアMst' as tablename, count(*) as cnt, '' as 日時_Min, '' as 日時_Max
	FROM cmn.t通貨ペアMst
	UNION

	--SELECT 'fxcm.tAccounts' as tablename, count(*) as cnt, MIN([日時]) as 日時_Min, MAX([日時]) as 日時_Max
	--FROM fxcm.tAccounts
	--UNION
	--SELECT 'fxcm.tClosedTrades' as tablename, count(*) as cnt, MIN([CloseTime]) as 日時_Min, MAX([CloseTime]) as 日時_Max
	--FROM fxcm.tClosedTrades
	--UNION
	--SELECT 'fxcm.tTrades' as tablename, count(*) as cnt, MIN([Time]) as 日時_Min, MAX([Time]) as 日時_Max
	--FROM fxcm.tTrades
	--UNION

	--SELECT 'hltc.T_システム異常発生件数_Daily' as tablename, count(*) as cnt, MIN([年月日]) as 日時_Min, MAX([年月日]) as 日時_Max
	--FROM hltc.T_システム異常発生件数_Daily
	--UNION
	--SELECT 'hltc.T_データCnt_Daily' as tablename, count(*) as cnt, MIN([日時]) as 日時_Min, MAX([日時]) as 日時_Max
	--FROM hltc.T_データCnt_Daily
	--UNION
	--SELECT 'hltc.T_処理Cnt_Hourly' as tablename, count(*) as cnt, MIN([日時]) as 日時_Min, MAX([日時]) as 日時_Max
	--FROM hltc.T_処理Cnt_Hourly
	--UNION
	--SELECT 'hltc.t処理時間' as tablename, count(*) as cnt, MIN([処理開始]) as 日時_Min, MAX([処理開始]) as 日時_Max
	--FROM hltc.t処理時間
	--UNION

	SELECT 'hstr.tBonusStage' as tablename, count(*) as cnt, MIN([日時]) as 日時_Min, MAX([日時]) as 日時_Max
	FROM hstr.tBonusStage
	UNION
	SELECT 'hstr.tDay1' as tablename, count(*) as cnt, MIN([StartDate]) as 日時_Min, MAX([StartDate]) as 日時_Max
	FROM hstr.tDay1
	UNION
	SELECT 'hstr.tHour1' as tablename, count(*) as cnt, MIN([StartDate]) as 日時_Min, MAX([StartDate]) as 日時_Max
	FROM hstr.tHour1
	UNION
	SELECT 'hstr.tMin1' as tablename, count(*) as cnt, MIN([StartDate]) as 日時_Min, MAX([StartDate]) as 日時_Max
	FROM hstr.tMin1
	UNION
	SELECT 'hstr.tMin15' as tablename, count(*) as cnt, MIN([StartDate]) as 日時_Min, MAX([StartDate]) as 日時_Max
	FROM hstr.tMin15
	UNION
	SELECT 'hstr.tMin5' as tablename, count(*) as cnt, MIN([StartDate]) as 日時_Min, MAX([StartDate]) as 日時_Max
	FROM hstr.tMin5
	UNION
	SELECT 'hstr.tMonth1' as tablename, count(*) as cnt, MIN([StartDate]) as 日時_Min, MAX([StartDate]) as 日時_Max
	FROM hstr.tMonth1
	UNION
	SELECT 'hstr.tSec' as tablename, count(*) as cnt, MIN([StartDate]) as 日時_Min, MAX([StartDate]) as 日時_Max
	FROM hstr.tSec
	UNION
	SELECT 'hstr.tWeek1' as tablename, count(*) as cnt, MIN([StartDate]) as 日時_Min, MAX([StartDate]) as 日時_Max
	FROM hstr.tWeek1
	UNION

	SELECT 'oanda.tAccount' as tablename, count(*) as cnt, MIN([日時]) as 日時_Min, MAX([日時]) as 日時_Max
	FROM [oanda].[tAccount]
	UNION
	SELECT 'oanda.tDeleteTradeResponse' as tablename, count(*) as cnt, MIN([time]) as 日時_Min, MAX([time]) as 日時_Max
	FROM [oanda].[tDeleteTradeResponse]
	UNION
	SELECT 'oanda.tOrder_注文削除' as tablename, count(*) as cnt, MIN([日時]) as 日時_Min, MAX([日時]) as 日時_Max
	FROM [oanda].[tOrder_注文削除]
	UNION
	SELECT 'oanda.tOrderResponse' as tablename, count(*) as cnt, MIN([time]) as 日時_Min, MAX([time]) as 日時_Max
	FROM [oanda].[tOrderResponse]
	UNION
	SELECT 'oanda.tTrade' as tablename, count(*) as cnt, MIN([time]) as 日時_Min, MAX([time]) as 日時_Max
	FROM [oanda].[tTrade]
	UNION
	SELECT 'oanda.tTrade_リミット変更' as tablename, count(*) as cnt, MIN([日時]) as 日時_Min, MAX([日時]) as 日時_Max
	FROM [oanda].[tTrade_リミット変更]
	UNION
	SELECT 'oanda.tTransaction' as tablename, count(*) as cnt, MIN([time]) as 日時_Min, MAX([time]) as 日時_Max
	FROM [oanda].tTransaction
	UNION

	SELECT 'oder.tOrderHistory2' as tablename, count(*) as cnt, MIN([日時]) as 日時_Min, MAX([日時]) as 日時_Max
	FROM [oder].[tOrderHistory2]
	UNION
	SELECT 'oder.tリミット変更History' as tablename, count(*) as cnt, MIN([日時]) as 日時_Min, MAX([日時]) as 日時_Max
	FROM [oder].[tリミット変更History]
	UNION

	SELECT 'pfmc.tExecLog' as tablename, count(*) as cnt, MIN([ExecDate]) as 日時_Min, MAX([ExecDate]) as 日時_Max
	FROM [pfmc].[tExecLog]
	UNION
	SELECT 'pfmc.tポジションDaily' as tablename, count(*) as cnt, MIN([StartDate]) as 日時_Min, MAX([StartDate]) as 日時_Max
	FROM [pfmc].tポジションDaily
	UNION
	SELECT 'pfmc.tポジションHourly' as tablename, count(*) as cnt, MIN([StartDate]) as 日時_Min, MAX([StartDate]) as 日時_Max
	FROM [pfmc].tポジションHourly
	UNION
	--SELECT 'pfmc.tポジションHourly_bk' as tablename, count(*) as cnt, MIN([StartDate]) as 日時_Min, MAX([StartDate]) as 日時_Max
	--FROM [pfmc].tポジションHourly_bk
	--UNION
	SELECT 'pfmc.tポジションMin3' as tablename, count(*) as cnt, MIN([StartDate]) as 日時_Min, MAX([StartDate]) as 日時_Max
	FROM [pfmc].tポジションMin3
	UNION
	SELECT 'pfmc.t利益Monthly' as tablename, count(*) as cnt, MIN([年月]) as 日時_Min, MAX([年月]) as 日時_Max
	FROM [pfmc].t利益Monthly
	UNION

	SELECT 'swap.tSwap手動登録_Day1' as tablename, count(*) as cnt, MIN([StartDate]) as 日時_Min, MAX([StartDate]) as 日時_Max
	FROM [swap].[tSwap手動登録_Day1]
	UNION
	SELECT 'swap.tSwap優位時間CntMonthly' as tablename, count(*) as cnt, MIN([StartDate]) as 日時_Min, MAX([StartDate]) as 日時_Max
	FROM [swap].tSwap優位時間CntMonthly
	UNION

	SELECT 'temp.tSortCloseTradeTmp' as tablename, count(*) as cnt, MIN([Time]) as 日時_Min, MAX([Time]) as 日時_Max
	FROM temp.tSortCloseTradeTmp
	UNION
	SELECT 'temp.tSortTmp' as tablename, count(*) as cnt, '' as 日時_Min, '' as 日時_Max
	FROM temp.tSortTmp

END
GO
/*
*/