USE [DemoA_FX]
GO

DROP PROCEDURE [hltc].[SP_Select’¼‹ß‚Ìó‹µ]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [hltc].[SP_Select’¼‹ß‚Ìó‹µ]
AS
BEGIN

	SELECT 'T_RateHistory', MIN([Date]) as [MIN], MAX([Date]) as [MAX]  FROM [dbo].[T_RateHistory]
	union
	SELECT 'T_RateHistory_1m', MIN(“ú), MAX(“ú)  FROM [dbo].[T_RateHistory_1m]
	union
	SELECT 'T_RateHistory_5m', MIN(“ú), MAX(“ú)  FROM [dbo].[T_RateHistory_5m]
	union
	SELECT 'T_RateHistory_15m', MIN(“ú), MAX(“ú)  FROM [dbo].[T_RateHistory_15m]
	union
	SELECT 'T_RateHistory_30m', MIN(“ú), MAX(“ú)  FROM [dbo].[T_RateHistory_30m]
	union
	SELECT 'T_RateHistory_Hourly', MIN(“ú), MAX(“ú)  FROM [dbo].[T_RateHistory_Hourly]
	union
	SELECT 'T_RateHistory_Daily', MIN(“ú), MAX(“ú)  FROM [dbo].[T_RateHistory_Daily]
	union
	SELECT 'T_RateHistory_Weekly', MIN(“ú), MAX(“ú)  FROM [dbo].[T_RateHistory_Weekly]
	union
	SELECT 'T_RateHistory_Monthly', MIN(“ú), MAX(“ú)  FROM [dbo].[T_RateHistory_Monthly]
	union

	SELECT 'T_Indicator_1m', MIN(“ú), MAX(“ú)  FROM [indi].[T_Indicator_1m]
	union
	SELECT 'T_Indicator_5m', MIN(“ú), MAX(“ú)  FROM [indi].[T_Indicator_5m]
	union
	SELECT 'T_Indicator_15m', MIN(“ú), MAX(“ú)  FROM [indi].[T_Indicator_15m]
	union
	SELECT 'T_Indicator_30m', MIN(“ú), MAX(“ú)  FROM [indi].[T_Indicator_30m]
	union
	SELECT 'T_Indicator_1H', MIN(“ú), MAX(“ú)  FROM [indi].[T_Indicator_1H]
	union
	SELECT 'T_Indicator_Daily', MIN(“ú), MAX(“ú)  FROM [indi].[T_Indicator_Daily]
	union
	SELECT 'T_Indicator_Weekly', MIN(“ú), MAX(“ú)  FROM [indi].[T_Indicator_Weekly]
	union
	SELECT 'T_Indicator_Monthly', MIN(“ú), MAX(“ú)  FROM [indi].[T_Indicator_Monthly]

END
GO
