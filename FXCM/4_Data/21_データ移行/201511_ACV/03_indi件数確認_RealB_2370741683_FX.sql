USE [RealB_2370741683_FX_ACV]
GO


SELECT (SELECT COUNT(*) FROM [RealB_2370741683_FX].[acv].[T_Indicator_Monthly_past]) as RealB_2370741683_FX, (SELECT COUNT(*) FROM [RealB_2370741683_FX_ACV].[indi].[T_Indicator_Monthly]) as RealB_2370741683_FX_ACV;

SELECT (SELECT COUNT(*) FROM [RealB_2370741683_FX].[acv].[T_Indicator_Weekly_past]) as RealB_2370741683_FX, (SELECT COUNT(*) FROM [RealB_2370741683_FX_ACV].[indi].[T_Indicator_Weekly]) as RealB_2370741683_FX_ACV;
SELECT top 1000 * FROM [RealB_2370741683_FX].[acv].[T_Indicator_Weekly_past] order by 日時 desc;
SELECT top 1000 * FROM [RealB_2370741683_FX_ACV].[indi].[T_Indicator_Weekly] order by 日時 desc;
SELECT 日時, count(日時) FROM [RealB_2370741683_FX].[acv].[T_Indicator_Weekly_past] group by 日時 order by 日時 desc;
SELECT 日時, count(日時) FROM [RealB_2370741683_FX_ACV].[indi].[T_Indicator_Weekly] group by 日時 order by 日時 desc;

SELECT 日時, count(日時) FROM [RealB_2370741683_FX].[acv].[T_Indicator_Daily_past] group by 日時 order by 日時 desc;
SELECT 日時, count(日時) FROM [RealB_2370741683_FX_ACV].[indi].[T_Indicator_Daily] group by 日時 order by 日時 desc;
	
SELECT (SELECT COUNT(*) FROM [RealB_2370741683_FX].[acv].[T_Indicator_6h_past]) as RealB_2370741683_FX, (SELECT COUNT(*) FROM [RealB_2370741683_FX_ACV].[indi].[T_Indicator_6h]) as RealB_2370741683_FX_ACV;

SELECT (SELECT COUNT(*) FROM [RealB_2370741683_FX].[acv].[T_Indicator_15m_past]) as RealB_2370741683_FX, (SELECT COUNT(*) FROM [RealB_2370741683_FX_ACV].[indi].[T_Indicator_15m]) as RealB_2370741683_FX_ACV;

SELECT 通貨ペアNo, count(通貨ペアNo) FROM [RealB_2370741683_FX].[acv].[T_Indicator_Monthly_past] group by 通貨ペアNo order by 通貨ペアNo;
SELECT 通貨ペアNo, count(通貨ペアNo) FROM [RealB_2370741683_FX_ACV].[indi].[T_Indicator_Monthly] group by 通貨ペアNo order by 通貨ペアNo;

SELECT 通貨ペアNo, count(通貨ペアNo) FROM [RealB_2370741683_FX].[acv].[T_Indicator_Weekly_past] group by 通貨ペアNo order by 通貨ペアNo;
SELECT 通貨ペアNo, count(通貨ペアNo) FROM [RealB_2370741683_FX_ACV].[indi].[T_Indicator_Weekly] group by 通貨ペアNo order by 通貨ペアNo;

SELECT 通貨ペアNo, count(通貨ペアNo) FROM [RealB_2370741683_FX].[acv].[T_Indicator_Daily_past] group by 通貨ペアNo order by 通貨ペアNo;
SELECT 通貨ペアNo, count(通貨ペアNo) FROM [RealB_2370741683_FX_ACV].[indi].[T_Indicator_Daily] group by 通貨ペアNo order by 通貨ペアNo;

SELECT 通貨ペアNo, count(通貨ペアNo) FROM [RealB_2370741683_FX].[acv].[T_Indicator_6h_past] group by 通貨ペアNo order by 通貨ペアNo;
SELECT 通貨ペアNo, count(通貨ペアNo) FROM [RealB_2370741683_FX_ACV].[indi].[T_Indicator_6h] group by 通貨ペアNo order by 通貨ペアNo;

SELECT 通貨ペアNo, count(通貨ペアNo) FROM [RealB_2370741683_FX].[acv].[T_Indicator_1h_past] group by 通貨ペアNo order by 通貨ペアNo;
SELECT 通貨ペアNo, count(通貨ペアNo) FROM [RealB_2370741683_FX_ACV].[indi].[T_Indicator_1h] group by 通貨ペアNo order by 通貨ペアNo;

SELECT 通貨ペアNo, count(通貨ペアNo) FROM [RealB_2370741683_FX].[acv].[T_Indicator_30m_past] group by 通貨ペアNo order by 通貨ペアNo;
SELECT 通貨ペアNo, count(通貨ペアNo) FROM [RealB_2370741683_FX_ACV].[indi].[T_Indicator_30m] group by 通貨ペアNo order by 通貨ペアNo;

SELECT 通貨ペアNo, count(通貨ペアNo) FROM [RealB_2370741683_FX].[acv].[T_Indicator_15m_past] group by 通貨ペアNo order by 通貨ペアNo;
SELECT 通貨ペアNo, count(通貨ペアNo) FROM [RealB_2370741683_FX_ACV].[indi].[T_Indicator_15m] group by 通貨ペアNo order by 通貨ペアNo;

SELECT 通貨ペアNo, count(通貨ペアNo) FROM [RealB_2370741683_FX].[acv].[T_Indicator_5m_past] group by 通貨ペアNo order by 通貨ペアNo;
SELECT 通貨ペアNo, count(通貨ペアNo) FROM [RealB_2370741683_FX_ACV].[indi].[T_Indicator_5m] group by 通貨ペアNo order by 通貨ペアNo;

SELECT 通貨ペアNo, count(通貨ペアNo) FROM [RealB_2370741683_FX].[acv].[T_Indicator_1m_past] group by 通貨ペアNo order by 通貨ペアNo;
SELECT 通貨ペアNo, count(通貨ペアNo) FROM [RealB_2370741683_FX_ACV].[indi].[T_Indicator_1m] group by 通貨ペアNo order by 通貨ペアNo;
