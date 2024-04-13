
SELECT (SELECT COUNT(*) FROM [RealA_FX].acv.T_RateHistory_Monthly_Past) as RealA_FX, (SELECT COUNT(*) FROM [RealA_FX_ACV].dbo.T_RateHistory_Monthly) as RealA_FX_ACV;

SELECT (SELECT COUNT(*) FROM [RealA_FX].[acv].T_RateHistory_Weekly_Past) as RealA_FX, (SELECT COUNT(*) FROM [RealA_FX_ACV].dbo.T_RateHistory_Weekly) as RealA_FX_ACV;

	SELECT * FROM [RealA_FX].[acv].T_RateHistory_Weekly_Past) as RealA_FX, (SELECT COUNT(*) FROM [RealA_FX_ACV].dbo.T_RateHistory_Weekly) as RealA_FX_ACV;
	SELECT 通貨ペアNo, count(通貨ペアNo) FROM [RealA_FX].[acv].T_RateHistory_Weekly_Past group by 通貨ペアNo order by 通貨ペアNo;
	SELECT 通貨ペアNo, count(通貨ペアNo) FROM [RealA_FX_ACV].dbo.T_RateHistory_Weekly group by 通貨ペアNo order by 通貨ペアNo;
	SELECT 日時, count(日時) FROM [RealA_FX].[acv].T_RateHistory_Weekly_Past group by 日時 order by 日時 desc;
	SELECT 日時, count(日時) FROM [RealA_FX_ACV].dbo.T_RateHistory_Weekly group by 日時 order by 日時 desc;
	SELECT top 1000 * FROM [RealA_FX].[acv].T_RateHistory_Weekly_Past order by 日時;
	SELECT top 1000 * FROM [RealA_FX_ACV].dbo.T_RateHistory_Weekly order by 日時;

SELECT (SELECT COUNT(*) FROM [RealA_FX].[acv].T_RateHistory_Daily_Past) as RealA_FX, (SELECT COUNT(*) FROM [RealA_FX_ACV].dbo.T_RateHistory_Daily) as RealA_FX_ACV;

	SELECT 通貨ペアNo, count(通貨ペアNo) FROM [RealA_FX].[acv].T_RateHistory_Daily_Past group by 通貨ペアNo order by 通貨ペアNo;
	SELECT 通貨ペアNo, count(通貨ペアNo) FROM [RealA_FX_ACV].dbo.T_RateHistory_Daily group by 通貨ペアNo order by 通貨ペアNo;

SELECT (SELECT COUNT(*) FROM [RealA_FX].[acv].T_RateHistory_6h_Past) as RealA_FX, (SELECT COUNT(*) FROM [RealA_FX_ACV].dbo.T_RateHistory_6h) as RealA_FX_ACV;

	SELECT 通貨ペアNo, count(通貨ペアNo) FROM [RealA_FX].[acv].T_RateHistory_6h_Past group by 通貨ペアNo order by 通貨ペアNo;
	SELECT 通貨ペアNo, count(通貨ペアNo) FROM [RealA_FX_ACV].dbo.T_RateHistory_6h group by 通貨ペアNo order by 通貨ペアNo;

SELECT (SELECT COUNT(*) FROM [RealA_FX].[acv].T_RateHistory_Hourly_Past) as RealA_FX, (SELECT COUNT(*) FROM [RealA_FX_ACV].dbo.T_RateHistory_Hourly) as RealA_FX_ACV;

	SELECT 通貨ペアNo, count(通貨ペアNo) FROM [RealA_FX].[acv].T_RateHistory_Hourly_Past group by 通貨ペアNo order by 通貨ペアNo;
	SELECT 通貨ペアNo, count(通貨ペアNo) FROM [RealA_FX_ACV].dbo.T_RateHistory_Hourly group by 通貨ペアNo order by 通貨ペアNo;

SELECT (SELECT COUNT(*) FROM [RealA_FX].[acv].T_RateHistory_30m_Past) as RealA_FX, (SELECT COUNT(*) FROM [RealA_FX_ACV].dbo.T_RateHistory_15m) as RealA_FX_ACV;

	SELECT 通貨ペアNo, count(通貨ペアNo) FROM [RealA_FX].[acv].T_RateHistory_30m_Past group by 通貨ペアNo order by 通貨ペアNo;
	SELECT 通貨ペアNo, count(通貨ペアNo) FROM [RealA_FX_ACV].dbo.T_RateHistory_30m group by 通貨ペアNo order by 通貨ペアNo;

SELECT (SELECT COUNT(*) FROM [RealA_FX].[acv].T_RateHistory_15m_Past) as RealA_FX, (SELECT COUNT(*) FROM [RealA_FX_ACV].dbo.T_RateHistory_15m) as RealA_FX_ACV;

	SELECT 通貨ペアNo, count(通貨ペアNo) FROM [RealA_FX].[acv].T_RateHistory_15m_Past group by 通貨ペアNo order by 通貨ペアNo;
	SELECT 通貨ペアNo, count(通貨ペアNo) FROM [RealA_FX_ACV].dbo.T_RateHistory_15m group by 通貨ペアNo order by 通貨ペアNo;

SELECT (SELECT COUNT(*) FROM [RealA_FX].[acv].T_RateHistory_5m_Past) as RealA_FX, (SELECT COUNT(*) FROM [RealA_FX_ACV].dbo.T_RateHistory_15m) as RealA_FX_ACV;

	SELECT 通貨ペアNo, count(通貨ペアNo) FROM [RealA_FX].[acv].T_RateHistory_5m_Past group by 通貨ペアNo order by 通貨ペアNo;
	SELECT 通貨ペアNo, count(通貨ペアNo) FROM [RealA_FX_ACV].dbo.T_RateHistory_5m group by 通貨ペアNo order by 通貨ペアNo;

SELECT (SELECT COUNT(*) FROM [RealA_FX].[acv].T_RateHistory_1m_Past) as RealA_FX, (SELECT COUNT(*) FROM [RealA_FX_ACV].dbo.T_RateHistory_15m) as RealA_FX_ACV;

	SELECT 通貨ペアNo, count(通貨ペアNo) FROM [RealA_FX].[acv].T_RateHistory_1m_Past group by 通貨ペアNo order by 通貨ペアNo;
	SELECT 通貨ペアNo, count(通貨ペアNo) FROM [RealA_FX_ACV].dbo.T_RateHistory_1m group by 通貨ペアNo order by 通貨ペアNo;

SELECT (SELECT COUNT(*) FROM [RealA_FX].[acv].T_RateHistory_Past) as RealA_FX, (SELECT COUNT(*) FROM [RealA_FX_ACV].dbo.T_RateHistory) as RealA_FX_ACV;

	SELECT 通貨ペアNo, count(通貨ペアNo) FROM [RealA_FX].[acv].T_RateHistory_Past group by 通貨ペアNo order by 通貨ペアNo;
	SELECT 通貨ペア, count(通貨ペア) FROM [RealA_FX_ACV].dbo.T_RateHistory group by 通貨ペア order by 通貨ペア;
