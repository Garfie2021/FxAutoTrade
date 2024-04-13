
SELECT (SELECT COUNT(*) FROM [RealB_2370741683_FX].acv.T_RateHistory_Monthly_Past) as RealB_2370741683_FX, (SELECT COUNT(*) FROM [RealB_2370741683_FX_ACV].dbo.T_RateHistory_Monthly) as RealB_2370741683_FX_ACV;

	SELECT 通貨ペアNo, count(通貨ペアNo) FROM [RealB_2370741683_FX].[acv].T_RateHistory_Monthly_Past group by 通貨ペアNo order by 通貨ペアNo;
	SELECT 通貨ペアNo, count(通貨ペアNo) FROM [RealB_2370741683_FX_ACV].dbo.T_RateHistory_Monthly group by 通貨ペアNo order by 通貨ペアNo;

SELECT (SELECT COUNT(*) FROM [RealB_2370741683_FX].[acv].T_RateHistory_Weekly_Past) as RealB_2370741683_FX, (SELECT COUNT(*) FROM [RealB_2370741683_FX_ACV].dbo.T_RateHistory_Weekly) as RealB_2370741683_FX_ACV;

	SELECT 通貨ペアNo, count(通貨ペアNo) FROM [RealB_2370741683_FX].[acv].T_RateHistory_Weekly_Past group by 通貨ペアNo order by 通貨ペアNo;
	SELECT 通貨ペアNo, count(通貨ペアNo) FROM [RealB_2370741683_FX_ACV].dbo.T_RateHistory_Weekly group by 通貨ペアNo order by 通貨ペアNo;

SELECT (SELECT COUNT(*) FROM [RealB_2370741683_FX].[acv].T_RateHistory_Daily_Past) as RealB_2370741683_FX, (SELECT COUNT(*) FROM [RealB_2370741683_FX_ACV].dbo.T_RateHistory_Daily) as RealB_2370741683_FX_ACV;

	SELECT 通貨ペアNo, count(通貨ペアNo) FROM [RealB_2370741683_FX].[acv].T_RateHistory_Daily_Past group by 通貨ペアNo order by 通貨ペアNo;
	SELECT 通貨ペアNo, count(通貨ペアNo) FROM [RealB_2370741683_FX_ACV].dbo.T_RateHistory_Daily group by 通貨ペアNo order by 通貨ペアNo;

SELECT (SELECT COUNT(*) FROM [RealB_2370741683_FX].[acv].T_RateHistory_6h_Past) as RealB_2370741683_FX, (SELECT COUNT(*) FROM [RealB_2370741683_FX_ACV].dbo.T_RateHistory_6h) as RealB_2370741683_FX_ACV;

	SELECT 通貨ペアNo, count(通貨ペアNo) FROM [RealB_2370741683_FX].[acv].T_RateHistory_6h_Past group by 通貨ペアNo order by 通貨ペアNo;
	SELECT 通貨ペアNo, count(通貨ペアNo) FROM [RealB_2370741683_FX_ACV].dbo.T_RateHistory_6h group by 通貨ペアNo order by 通貨ペアNo;

SELECT (SELECT COUNT(*) FROM [RealB_2370741683_FX].[acv].T_RateHistory_Hourly_Past) as RealB_2370741683_FX, (SELECT COUNT(*) FROM [RealB_2370741683_FX_ACV].dbo.T_RateHistory_Hourly) as RealB_2370741683_FX_ACV;

	SELECT 通貨ペアNo, count(通貨ペアNo) FROM [RealB_2370741683_FX].[acv].T_RateHistory_Hourly_Past group by 通貨ペアNo order by 通貨ペアNo;
	SELECT 通貨ペアNo, count(通貨ペアNo) FROM [RealB_2370741683_FX_ACV].dbo.T_RateHistory_Hourly group by 通貨ペアNo order by 通貨ペアNo;

SELECT (SELECT COUNT(*) FROM [RealB_2370741683_FX].[acv].T_RateHistory_30m_Past) as RealB_2370741683_FX, (SELECT COUNT(*) FROM [RealB_2370741683_FX_ACV].dbo.T_RateHistory_15m) as RealB_2370741683_FX_ACV;

	SELECT 通貨ペアNo, count(通貨ペアNo) FROM [RealB_2370741683_FX].[acv].T_RateHistory_30m_Past group by 通貨ペアNo order by 通貨ペアNo;
	SELECT 通貨ペアNo, count(通貨ペアNo) FROM [RealB_2370741683_FX_ACV].dbo.T_RateHistory_30m group by 通貨ペアNo order by 通貨ペアNo;

SELECT (SELECT COUNT(*) FROM [RealB_2370741683_FX].[acv].T_RateHistory_15m_Past) as RealB_2370741683_FX, (SELECT COUNT(*) FROM [RealB_2370741683_FX_ACV].dbo.T_RateHistory_15m) as RealB_2370741683_FX_ACV;

	SELECT 通貨ペアNo, count(通貨ペアNo) FROM [RealB_2370741683_FX].[acv].T_RateHistory_15m_Past group by 通貨ペアNo order by 通貨ペアNo;
	SELECT 通貨ペアNo, count(通貨ペアNo) FROM [RealB_2370741683_FX_ACV].dbo.T_RateHistory_15m group by 通貨ペアNo order by 通貨ペアNo;

SELECT (SELECT COUNT(*) FROM [RealB_2370741683_FX].[acv].T_RateHistory_5m_Past) as RealB_2370741683_FX, (SELECT COUNT(*) FROM [RealB_2370741683_FX_ACV].dbo.T_RateHistory_15m) as RealB_2370741683_FX_ACV;

	SELECT 通貨ペアNo, count(通貨ペアNo) FROM [RealB_2370741683_FX].[acv].T_RateHistory_5m_Past group by 通貨ペアNo order by 通貨ペアNo;
	SELECT 通貨ペアNo, count(通貨ペアNo) FROM [RealB_2370741683_FX_ACV].dbo.T_RateHistory_5m group by 通貨ペアNo order by 通貨ペアNo;

SELECT (SELECT COUNT(*) FROM [RealB_2370741683_FX].[acv].T_RateHistory_1m_Past) as RealB_2370741683_FX, (SELECT COUNT(*) FROM [RealB_2370741683_FX_ACV].dbo.T_RateHistory_15m) as RealB_2370741683_FX_ACV;

	SELECT 通貨ペアNo, count(通貨ペアNo) FROM [RealB_2370741683_FX].[acv].T_RateHistory_1m_Past group by 通貨ペアNo order by 通貨ペアNo;
	SELECT 通貨ペアNo, count(通貨ペアNo) FROM [RealB_2370741683_FX_ACV].dbo.T_RateHistory_1m group by 通貨ペアNo order by 通貨ペアNo;

SELECT (SELECT COUNT(*) FROM [RealB_2370741683_FX].[acv].T_RateHistory_Past) as RealB_2370741683_FX, (SELECT COUNT(*) FROM [RealB_2370741683_FX_ACV].dbo.T_RateHistory) as RealB_2370741683_FX_ACV;

	SELECT 通貨ペアNo, count(通貨ペアNo) FROM [RealB_2370741683_FX].[acv].T_RateHistory_Past group by 通貨ペアNo order by 通貨ペアNo;
	SELECT 通貨ペア, count(通貨ペア) FROM [RealB_2370741683_FX_ACV].dbo.T_RateHistory group by 通貨ペア order by 通貨ペア;
