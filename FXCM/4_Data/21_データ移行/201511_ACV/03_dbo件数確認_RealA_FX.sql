
SELECT (SELECT COUNT(*) FROM [RealA_FX].acv.T_RateHistory_Monthly_Past) as RealA_FX, (SELECT COUNT(*) FROM [RealA_FX_ACV].dbo.T_RateHistory_Monthly) as RealA_FX_ACV;

SELECT (SELECT COUNT(*) FROM [RealA_FX].[acv].T_RateHistory_Weekly_Past) as RealA_FX, (SELECT COUNT(*) FROM [RealA_FX_ACV].dbo.T_RateHistory_Weekly) as RealA_FX_ACV;

	SELECT * FROM [RealA_FX].[acv].T_RateHistory_Weekly_Past) as RealA_FX, (SELECT COUNT(*) FROM [RealA_FX_ACV].dbo.T_RateHistory_Weekly) as RealA_FX_ACV;
	SELECT �ʉ݃y�ANo, count(�ʉ݃y�ANo) FROM [RealA_FX].[acv].T_RateHistory_Weekly_Past group by �ʉ݃y�ANo order by �ʉ݃y�ANo;
	SELECT �ʉ݃y�ANo, count(�ʉ݃y�ANo) FROM [RealA_FX_ACV].dbo.T_RateHistory_Weekly group by �ʉ݃y�ANo order by �ʉ݃y�ANo;
	SELECT ����, count(����) FROM [RealA_FX].[acv].T_RateHistory_Weekly_Past group by ���� order by ���� desc;
	SELECT ����, count(����) FROM [RealA_FX_ACV].dbo.T_RateHistory_Weekly group by ���� order by ���� desc;
	SELECT top 1000 * FROM [RealA_FX].[acv].T_RateHistory_Weekly_Past order by ����;
	SELECT top 1000 * FROM [RealA_FX_ACV].dbo.T_RateHistory_Weekly order by ����;

SELECT (SELECT COUNT(*) FROM [RealA_FX].[acv].T_RateHistory_Daily_Past) as RealA_FX, (SELECT COUNT(*) FROM [RealA_FX_ACV].dbo.T_RateHistory_Daily) as RealA_FX_ACV;

	SELECT �ʉ݃y�ANo, count(�ʉ݃y�ANo) FROM [RealA_FX].[acv].T_RateHistory_Daily_Past group by �ʉ݃y�ANo order by �ʉ݃y�ANo;
	SELECT �ʉ݃y�ANo, count(�ʉ݃y�ANo) FROM [RealA_FX_ACV].dbo.T_RateHistory_Daily group by �ʉ݃y�ANo order by �ʉ݃y�ANo;

SELECT (SELECT COUNT(*) FROM [RealA_FX].[acv].T_RateHistory_6h_Past) as RealA_FX, (SELECT COUNT(*) FROM [RealA_FX_ACV].dbo.T_RateHistory_6h) as RealA_FX_ACV;

	SELECT �ʉ݃y�ANo, count(�ʉ݃y�ANo) FROM [RealA_FX].[acv].T_RateHistory_6h_Past group by �ʉ݃y�ANo order by �ʉ݃y�ANo;
	SELECT �ʉ݃y�ANo, count(�ʉ݃y�ANo) FROM [RealA_FX_ACV].dbo.T_RateHistory_6h group by �ʉ݃y�ANo order by �ʉ݃y�ANo;

SELECT (SELECT COUNT(*) FROM [RealA_FX].[acv].T_RateHistory_Hourly_Past) as RealA_FX, (SELECT COUNT(*) FROM [RealA_FX_ACV].dbo.T_RateHistory_Hourly) as RealA_FX_ACV;

	SELECT �ʉ݃y�ANo, count(�ʉ݃y�ANo) FROM [RealA_FX].[acv].T_RateHistory_Hourly_Past group by �ʉ݃y�ANo order by �ʉ݃y�ANo;
	SELECT �ʉ݃y�ANo, count(�ʉ݃y�ANo) FROM [RealA_FX_ACV].dbo.T_RateHistory_Hourly group by �ʉ݃y�ANo order by �ʉ݃y�ANo;

SELECT (SELECT COUNT(*) FROM [RealA_FX].[acv].T_RateHistory_30m_Past) as RealA_FX, (SELECT COUNT(*) FROM [RealA_FX_ACV].dbo.T_RateHistory_15m) as RealA_FX_ACV;

	SELECT �ʉ݃y�ANo, count(�ʉ݃y�ANo) FROM [RealA_FX].[acv].T_RateHistory_30m_Past group by �ʉ݃y�ANo order by �ʉ݃y�ANo;
	SELECT �ʉ݃y�ANo, count(�ʉ݃y�ANo) FROM [RealA_FX_ACV].dbo.T_RateHistory_30m group by �ʉ݃y�ANo order by �ʉ݃y�ANo;

SELECT (SELECT COUNT(*) FROM [RealA_FX].[acv].T_RateHistory_15m_Past) as RealA_FX, (SELECT COUNT(*) FROM [RealA_FX_ACV].dbo.T_RateHistory_15m) as RealA_FX_ACV;

	SELECT �ʉ݃y�ANo, count(�ʉ݃y�ANo) FROM [RealA_FX].[acv].T_RateHistory_15m_Past group by �ʉ݃y�ANo order by �ʉ݃y�ANo;
	SELECT �ʉ݃y�ANo, count(�ʉ݃y�ANo) FROM [RealA_FX_ACV].dbo.T_RateHistory_15m group by �ʉ݃y�ANo order by �ʉ݃y�ANo;

SELECT (SELECT COUNT(*) FROM [RealA_FX].[acv].T_RateHistory_5m_Past) as RealA_FX, (SELECT COUNT(*) FROM [RealA_FX_ACV].dbo.T_RateHistory_15m) as RealA_FX_ACV;

	SELECT �ʉ݃y�ANo, count(�ʉ݃y�ANo) FROM [RealA_FX].[acv].T_RateHistory_5m_Past group by �ʉ݃y�ANo order by �ʉ݃y�ANo;
	SELECT �ʉ݃y�ANo, count(�ʉ݃y�ANo) FROM [RealA_FX_ACV].dbo.T_RateHistory_5m group by �ʉ݃y�ANo order by �ʉ݃y�ANo;

SELECT (SELECT COUNT(*) FROM [RealA_FX].[acv].T_RateHistory_1m_Past) as RealA_FX, (SELECT COUNT(*) FROM [RealA_FX_ACV].dbo.T_RateHistory_15m) as RealA_FX_ACV;

	SELECT �ʉ݃y�ANo, count(�ʉ݃y�ANo) FROM [RealA_FX].[acv].T_RateHistory_1m_Past group by �ʉ݃y�ANo order by �ʉ݃y�ANo;
	SELECT �ʉ݃y�ANo, count(�ʉ݃y�ANo) FROM [RealA_FX_ACV].dbo.T_RateHistory_1m group by �ʉ݃y�ANo order by �ʉ݃y�ANo;

SELECT (SELECT COUNT(*) FROM [RealA_FX].[acv].T_RateHistory_Past) as RealA_FX, (SELECT COUNT(*) FROM [RealA_FX_ACV].dbo.T_RateHistory) as RealA_FX_ACV;

	SELECT �ʉ݃y�ANo, count(�ʉ݃y�ANo) FROM [RealA_FX].[acv].T_RateHistory_Past group by �ʉ݃y�ANo order by �ʉ݃y�ANo;
	SELECT �ʉ݃y�A, count(�ʉ݃y�A) FROM [RealA_FX_ACV].dbo.T_RateHistory group by �ʉ݃y�A order by �ʉ݃y�A;
