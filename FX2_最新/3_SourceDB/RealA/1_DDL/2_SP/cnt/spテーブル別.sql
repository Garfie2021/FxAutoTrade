USE OANDA_DemoB
GO
/*
*/
DROP PROCEDURE [cnt].[sp�e�[�u����]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [cnt].[sp�e�[�u����]
AS
BEGIN

	SELECT 'anls.t�z�蔄���^�C�~���O' as tablename, count(*) as cnt, MIN([StartDateMin1]) as ����_Min, MAX([StartDateMin1]) as ����_Max
	FROM anls.t�z�蔄���^�C�~���O
	UNION
	SELECT 'anls.t�z�蔄���^�C�~���O_Swap���薳��' as tablename, count(*) as cnt, MIN([StartDateMin1]) as ����_Min, MAX([StartDateMin1]) as ����_Max
	FROM anls.t�z�蔄���^�C�~���O_Swap���薳��
	UNION

	SELECT 'cmn.t�ʉ݃y�AMst' as tablename, count(*) as cnt, '' as ����_Min, '' as ����_Max
	FROM cmn.t�ʉ݃y�AMst
	UNION

	--SELECT 'fxcm.tAccounts' as tablename, count(*) as cnt, MIN([����]) as ����_Min, MAX([����]) as ����_Max
	--FROM fxcm.tAccounts
	--UNION
	--SELECT 'fxcm.tClosedTrades' as tablename, count(*) as cnt, MIN([CloseTime]) as ����_Min, MAX([CloseTime]) as ����_Max
	--FROM fxcm.tClosedTrades
	--UNION
	--SELECT 'fxcm.tTrades' as tablename, count(*) as cnt, MIN([Time]) as ����_Min, MAX([Time]) as ����_Max
	--FROM fxcm.tTrades
	--UNION

	--SELECT 'hltc.T_�V�X�e���ُ픭������_Daily' as tablename, count(*) as cnt, MIN([�N����]) as ����_Min, MAX([�N����]) as ����_Max
	--FROM hltc.T_�V�X�e���ُ픭������_Daily
	--UNION
	--SELECT 'hltc.T_�f�[�^Cnt_Daily' as tablename, count(*) as cnt, MIN([����]) as ����_Min, MAX([����]) as ����_Max
	--FROM hltc.T_�f�[�^Cnt_Daily
	--UNION
	--SELECT 'hltc.T_����Cnt_Hourly' as tablename, count(*) as cnt, MIN([����]) as ����_Min, MAX([����]) as ����_Max
	--FROM hltc.T_����Cnt_Hourly
	--UNION
	--SELECT 'hltc.t��������' as tablename, count(*) as cnt, MIN([�����J�n]) as ����_Min, MAX([�����J�n]) as ����_Max
	--FROM hltc.t��������
	--UNION

	SELECT 'hstr.tBonusStage' as tablename, count(*) as cnt, MIN([����]) as ����_Min, MAX([����]) as ����_Max
	FROM hstr.tBonusStage
	UNION
	SELECT 'hstr.tDay1' as tablename, count(*) as cnt, MIN([StartDate]) as ����_Min, MAX([StartDate]) as ����_Max
	FROM hstr.tDay1
	UNION
	SELECT 'hstr.tHour1' as tablename, count(*) as cnt, MIN([StartDate]) as ����_Min, MAX([StartDate]) as ����_Max
	FROM hstr.tHour1
	UNION
	SELECT 'hstr.tMin1' as tablename, count(*) as cnt, MIN([StartDate]) as ����_Min, MAX([StartDate]) as ����_Max
	FROM hstr.tMin1
	UNION
	SELECT 'hstr.tMin15' as tablename, count(*) as cnt, MIN([StartDate]) as ����_Min, MAX([StartDate]) as ����_Max
	FROM hstr.tMin15
	UNION
	SELECT 'hstr.tMin5' as tablename, count(*) as cnt, MIN([StartDate]) as ����_Min, MAX([StartDate]) as ����_Max
	FROM hstr.tMin5
	UNION
	SELECT 'hstr.tMonth1' as tablename, count(*) as cnt, MIN([StartDate]) as ����_Min, MAX([StartDate]) as ����_Max
	FROM hstr.tMonth1
	UNION
	SELECT 'hstr.tSec' as tablename, count(*) as cnt, MIN([StartDate]) as ����_Min, MAX([StartDate]) as ����_Max
	FROM hstr.tSec
	UNION
	SELECT 'hstr.tWeek1' as tablename, count(*) as cnt, MIN([StartDate]) as ����_Min, MAX([StartDate]) as ����_Max
	FROM hstr.tWeek1
	UNION

	SELECT 'oanda.tAccount' as tablename, count(*) as cnt, MIN([����]) as ����_Min, MAX([����]) as ����_Max
	FROM [oanda].[tAccount]
	UNION
	SELECT 'oanda.tDeleteTradeResponse' as tablename, count(*) as cnt, MIN([time]) as ����_Min, MAX([time]) as ����_Max
	FROM [oanda].[tDeleteTradeResponse]
	UNION
	SELECT 'oanda.tOrder_�����폜' as tablename, count(*) as cnt, MIN([����]) as ����_Min, MAX([����]) as ����_Max
	FROM [oanda].[tOrder_�����폜]
	UNION
	SELECT 'oanda.tOrderResponse' as tablename, count(*) as cnt, MIN([time]) as ����_Min, MAX([time]) as ����_Max
	FROM [oanda].[tOrderResponse]
	UNION
	SELECT 'oanda.tTrade' as tablename, count(*) as cnt, MIN([time]) as ����_Min, MAX([time]) as ����_Max
	FROM [oanda].[tTrade]
	UNION
	SELECT 'oanda.tTrade_���~�b�g�ύX' as tablename, count(*) as cnt, MIN([����]) as ����_Min, MAX([����]) as ����_Max
	FROM [oanda].[tTrade_���~�b�g�ύX]
	UNION
	SELECT 'oanda.tTransaction' as tablename, count(*) as cnt, MIN([time]) as ����_Min, MAX([time]) as ����_Max
	FROM [oanda].tTransaction
	UNION

	SELECT 'oder.tOrderHistory2' as tablename, count(*) as cnt, MIN([����]) as ����_Min, MAX([����]) as ����_Max
	FROM [oder].[tOrderHistory2]
	UNION
	SELECT 'oder.t���~�b�g�ύXHistory' as tablename, count(*) as cnt, MIN([����]) as ����_Min, MAX([����]) as ����_Max
	FROM [oder].[t���~�b�g�ύXHistory]
	UNION

	SELECT 'pfmc.tExecLog' as tablename, count(*) as cnt, MIN([ExecDate]) as ����_Min, MAX([ExecDate]) as ����_Max
	FROM [pfmc].[tExecLog]
	UNION
	SELECT 'pfmc.t�|�W�V����Daily' as tablename, count(*) as cnt, MIN([StartDate]) as ����_Min, MAX([StartDate]) as ����_Max
	FROM [pfmc].t�|�W�V����Daily
	UNION
	SELECT 'pfmc.t�|�W�V����Hourly' as tablename, count(*) as cnt, MIN([StartDate]) as ����_Min, MAX([StartDate]) as ����_Max
	FROM [pfmc].t�|�W�V����Hourly
	UNION
	--SELECT 'pfmc.t�|�W�V����Hourly_bk' as tablename, count(*) as cnt, MIN([StartDate]) as ����_Min, MAX([StartDate]) as ����_Max
	--FROM [pfmc].t�|�W�V����Hourly_bk
	--UNION
	SELECT 'pfmc.t�|�W�V����Min3' as tablename, count(*) as cnt, MIN([StartDate]) as ����_Min, MAX([StartDate]) as ����_Max
	FROM [pfmc].t�|�W�V����Min3
	UNION
	SELECT 'pfmc.t���vMonthly' as tablename, count(*) as cnt, MIN([�N��]) as ����_Min, MAX([�N��]) as ����_Max
	FROM [pfmc].t���vMonthly
	UNION

	SELECT 'swap.tSwap�蓮�o�^_Day1' as tablename, count(*) as cnt, MIN([StartDate]) as ����_Min, MAX([StartDate]) as ����_Max
	FROM [swap].[tSwap�蓮�o�^_Day1]
	UNION
	SELECT 'swap.tSwap�D�ʎ���CntMonthly' as tablename, count(*) as cnt, MIN([StartDate]) as ����_Min, MAX([StartDate]) as ����_Max
	FROM [swap].tSwap�D�ʎ���CntMonthly
	UNION

	SELECT 'temp.tSortCloseTradeTmp' as tablename, count(*) as cnt, MIN([Time]) as ����_Min, MAX([Time]) as ����_Max
	FROM temp.tSortCloseTradeTmp
	UNION
	SELECT 'temp.tSortTmp' as tablename, count(*) as cnt, '' as ����_Min, '' as ����_Max
	FROM temp.tSortTmp

END
GO
/*
*/