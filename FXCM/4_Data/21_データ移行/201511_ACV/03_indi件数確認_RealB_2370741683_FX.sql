USE [RealB_2370741683_FX_ACV]
GO


SELECT (SELECT COUNT(*) FROM [RealB_2370741683_FX].[acv].[T_Indicator_Monthly_past]) as RealB_2370741683_FX, (SELECT COUNT(*) FROM [RealB_2370741683_FX_ACV].[indi].[T_Indicator_Monthly]) as RealB_2370741683_FX_ACV;

SELECT (SELECT COUNT(*) FROM [RealB_2370741683_FX].[acv].[T_Indicator_Weekly_past]) as RealB_2370741683_FX, (SELECT COUNT(*) FROM [RealB_2370741683_FX_ACV].[indi].[T_Indicator_Weekly]) as RealB_2370741683_FX_ACV;
SELECT top 1000 * FROM [RealB_2370741683_FX].[acv].[T_Indicator_Weekly_past] order by ���� desc;
SELECT top 1000 * FROM [RealB_2370741683_FX_ACV].[indi].[T_Indicator_Weekly] order by ���� desc;
SELECT ����, count(����) FROM [RealB_2370741683_FX].[acv].[T_Indicator_Weekly_past] group by ���� order by ���� desc;
SELECT ����, count(����) FROM [RealB_2370741683_FX_ACV].[indi].[T_Indicator_Weekly] group by ���� order by ���� desc;

SELECT ����, count(����) FROM [RealB_2370741683_FX].[acv].[T_Indicator_Daily_past] group by ���� order by ���� desc;
SELECT ����, count(����) FROM [RealB_2370741683_FX_ACV].[indi].[T_Indicator_Daily] group by ���� order by ���� desc;
	
SELECT (SELECT COUNT(*) FROM [RealB_2370741683_FX].[acv].[T_Indicator_6h_past]) as RealB_2370741683_FX, (SELECT COUNT(*) FROM [RealB_2370741683_FX_ACV].[indi].[T_Indicator_6h]) as RealB_2370741683_FX_ACV;

SELECT (SELECT COUNT(*) FROM [RealB_2370741683_FX].[acv].[T_Indicator_15m_past]) as RealB_2370741683_FX, (SELECT COUNT(*) FROM [RealB_2370741683_FX_ACV].[indi].[T_Indicator_15m]) as RealB_2370741683_FX_ACV;

SELECT �ʉ݃y�ANo, count(�ʉ݃y�ANo) FROM [RealB_2370741683_FX].[acv].[T_Indicator_Monthly_past] group by �ʉ݃y�ANo order by �ʉ݃y�ANo;
SELECT �ʉ݃y�ANo, count(�ʉ݃y�ANo) FROM [RealB_2370741683_FX_ACV].[indi].[T_Indicator_Monthly] group by �ʉ݃y�ANo order by �ʉ݃y�ANo;

SELECT �ʉ݃y�ANo, count(�ʉ݃y�ANo) FROM [RealB_2370741683_FX].[acv].[T_Indicator_Weekly_past] group by �ʉ݃y�ANo order by �ʉ݃y�ANo;
SELECT �ʉ݃y�ANo, count(�ʉ݃y�ANo) FROM [RealB_2370741683_FX_ACV].[indi].[T_Indicator_Weekly] group by �ʉ݃y�ANo order by �ʉ݃y�ANo;

SELECT �ʉ݃y�ANo, count(�ʉ݃y�ANo) FROM [RealB_2370741683_FX].[acv].[T_Indicator_Daily_past] group by �ʉ݃y�ANo order by �ʉ݃y�ANo;
SELECT �ʉ݃y�ANo, count(�ʉ݃y�ANo) FROM [RealB_2370741683_FX_ACV].[indi].[T_Indicator_Daily] group by �ʉ݃y�ANo order by �ʉ݃y�ANo;

SELECT �ʉ݃y�ANo, count(�ʉ݃y�ANo) FROM [RealB_2370741683_FX].[acv].[T_Indicator_6h_past] group by �ʉ݃y�ANo order by �ʉ݃y�ANo;
SELECT �ʉ݃y�ANo, count(�ʉ݃y�ANo) FROM [RealB_2370741683_FX_ACV].[indi].[T_Indicator_6h] group by �ʉ݃y�ANo order by �ʉ݃y�ANo;

SELECT �ʉ݃y�ANo, count(�ʉ݃y�ANo) FROM [RealB_2370741683_FX].[acv].[T_Indicator_1h_past] group by �ʉ݃y�ANo order by �ʉ݃y�ANo;
SELECT �ʉ݃y�ANo, count(�ʉ݃y�ANo) FROM [RealB_2370741683_FX_ACV].[indi].[T_Indicator_1h] group by �ʉ݃y�ANo order by �ʉ݃y�ANo;

SELECT �ʉ݃y�ANo, count(�ʉ݃y�ANo) FROM [RealB_2370741683_FX].[acv].[T_Indicator_30m_past] group by �ʉ݃y�ANo order by �ʉ݃y�ANo;
SELECT �ʉ݃y�ANo, count(�ʉ݃y�ANo) FROM [RealB_2370741683_FX_ACV].[indi].[T_Indicator_30m] group by �ʉ݃y�ANo order by �ʉ݃y�ANo;

SELECT �ʉ݃y�ANo, count(�ʉ݃y�ANo) FROM [RealB_2370741683_FX].[acv].[T_Indicator_15m_past] group by �ʉ݃y�ANo order by �ʉ݃y�ANo;
SELECT �ʉ݃y�ANo, count(�ʉ݃y�ANo) FROM [RealB_2370741683_FX_ACV].[indi].[T_Indicator_15m] group by �ʉ݃y�ANo order by �ʉ݃y�ANo;

SELECT �ʉ݃y�ANo, count(�ʉ݃y�ANo) FROM [RealB_2370741683_FX].[acv].[T_Indicator_5m_past] group by �ʉ݃y�ANo order by �ʉ݃y�ANo;
SELECT �ʉ݃y�ANo, count(�ʉ݃y�ANo) FROM [RealB_2370741683_FX_ACV].[indi].[T_Indicator_5m] group by �ʉ݃y�ANo order by �ʉ݃y�ANo;

SELECT �ʉ݃y�ANo, count(�ʉ݃y�ANo) FROM [RealB_2370741683_FX].[acv].[T_Indicator_1m_past] group by �ʉ݃y�ANo order by �ʉ݃y�ANo;
SELECT �ʉ݃y�ANo, count(�ʉ݃y�ANo) FROM [RealB_2370741683_FX_ACV].[indi].[T_Indicator_1m] group by �ʉ݃y�ANo order by �ʉ݃y�ANo;
