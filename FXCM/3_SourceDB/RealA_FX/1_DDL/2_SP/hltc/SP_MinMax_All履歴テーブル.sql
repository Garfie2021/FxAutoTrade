USE [DemoA_FX]
GO

DROP PROCEDURE [hltc].[SP_Select���߂̏�]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [hltc].[SP_Select���߂̏�]
AS
BEGIN

	SELECT 'T_RateHistory', MIN([Date]) as [MIN], MAX([Date]) as [MAX]  FROM [dbo].[T_RateHistory]
	union
	SELECT 'T_RateHistory_1m', MIN(����), MAX(����)  FROM [dbo].[T_RateHistory_1m]
	union
	SELECT 'T_RateHistory_5m', MIN(����), MAX(����)  FROM [dbo].[T_RateHistory_5m]
	union
	SELECT 'T_RateHistory_15m', MIN(����), MAX(����)  FROM [dbo].[T_RateHistory_15m]
	union
	SELECT 'T_RateHistory_30m', MIN(����), MAX(����)  FROM [dbo].[T_RateHistory_30m]
	union
	SELECT 'T_RateHistory_Hourly', MIN(����), MAX(����)  FROM [dbo].[T_RateHistory_Hourly]
	union
	SELECT 'T_RateHistory_Daily', MIN(����), MAX(����)  FROM [dbo].[T_RateHistory_Daily]
	union
	SELECT 'T_RateHistory_Weekly', MIN(����), MAX(����)  FROM [dbo].[T_RateHistory_Weekly]
	union
	SELECT 'T_RateHistory_Monthly', MIN(����), MAX(����)  FROM [dbo].[T_RateHistory_Monthly]
	union

	SELECT 'T_Indicator_1m', MIN(����), MAX(����)  FROM [indi].[T_Indicator_1m]
	union
	SELECT 'T_Indicator_5m', MIN(����), MAX(����)  FROM [indi].[T_Indicator_5m]
	union
	SELECT 'T_Indicator_15m', MIN(����), MAX(����)  FROM [indi].[T_Indicator_15m]
	union
	SELECT 'T_Indicator_30m', MIN(����), MAX(����)  FROM [indi].[T_Indicator_30m]
	union
	SELECT 'T_Indicator_1H', MIN(����), MAX(����)  FROM [indi].[T_Indicator_1H]
	union
	SELECT 'T_Indicator_Daily', MIN(����), MAX(����)  FROM [indi].[T_Indicator_Daily]
	union
	SELECT 'T_Indicator_Weekly', MIN(����), MAX(����)  FROM [indi].[T_Indicator_Weekly]
	union
	SELECT 'T_Indicator_Monthly', MIN(����), MAX(����)  FROM [indi].[T_Indicator_Monthly]

END
GO
