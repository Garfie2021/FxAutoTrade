USE [RealB_2370741683_FX]
GO
/*
*/
DROP PROCEDURE [hltc].[SP_Getレコードの状況]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [hltc].[SP_Getレコードの状況]
	@back_Day	int = -1,
	@状況		varchar(5000)	output
AS
BEGIN
	/*
	declare @back_Day	int = -1
	DECLARE @状況		varchar(5000) = '';
	*/


	DECLARE @now datetime = getdate();
	DECLARE @ThisDay date;
	DECLARE @StartDate datetime;
	DECLARE @EndDate datetime;
	EXECUTE [cmn].[spGetThisDay1] @now, @back_Day, @ThisDay OUTPUT, @StartDate OUTPUT, @EndDate OUTPUT;

	DECLARE @日時					date
	DECLARE @件数_RateHistory		int
	DECLARE @件数_RateHistory_1m	int
	DECLARE @件数_RateHistory_5m	int
	DECLARE @件数_RateHistory_15m	int
	DECLARE @件数_RateHistory_30m	int
	DECLARE @件数_RateHistory_1h	int
	DECLARE @件数_RateHistory_6h	int
	DECLARE @件数_RateHistory_Day	int
	DECLARE @件数_Indicator_1m		int
	DECLARE @件数_Indicator_5m		int
	DECLARE @件数_Indicator_15m		int
	DECLARE @件数_Indicator_30m		int
	DECLARE @件数_Indicator_1h		int
	DECLARE @件数_Indicator_6h		int
	DECLARE @件数_Indicator_Day		int
	DECLARE @件数_AccountsHistory		int
	DECLARE @件数_BonusStageHistory		int
	DECLARE @件数_ClosedTrades			int
	DECLARE @件数_OrderHistory			int
	DECLARE @件数_SwapHistory_Hourly	int
	DECLARE @件数_Trades				int
	DECLARE @件数_差損益History			int

	SELECT 
		 @件数_RateHistory =		[件数_RateHistory]
		,@件数_RateHistory_1m =		[件数_RateHistory_1m]
		,@件数_RateHistory_5m =		[件数_RateHistory_5m]
		,@件数_RateHistory_15m =	[件数_RateHistory_15m]
		,@件数_RateHistory_30m =	[件数_RateHistory_30m]
		,@件数_RateHistory_1h =		[件数_RateHistory_1h]
		,@件数_RateHistory_6h =		[件数_RateHistory_6h]
		,@件数_RateHistory_Day =	[件数_RateHistory_Day]
		,@件数_Indicator_1m =		[件数_Indicator_1m]
		,@件数_Indicator_5m =		[件数_Indicator_5m]
		,@件数_Indicator_15m =		[件数_Indicator_15m]
		,@件数_Indicator_30m =		[件数_Indicator_30m]
		,@件数_Indicator_1h =		[件数_Indicator_1h]
		,@件数_Indicator_6h =		[件数_Indicator_6h]
		,@件数_Indicator_Day =		[件数_Indicator_Day]
		,@件数_AccountsHistory =	[件数_AccountsHistory]
		,@件数_BonusStageHistory =	[件数_BonusStageHistory]
		,@件数_ClosedTrades =		[件数_ClosedTrades]
		,@件数_OrderHistory =		[件数_OrderHistory]
		,@件数_SwapHistory_Hourly =	[件数_SwapHistory_Hourly]
		,@件数_Trades =				[件数_Trades]
		,@件数_差損益History =		[件数_差損益History]
	FROM [hltc].[T_データCnt_Daily]
	WHERE [日時] = @ThisDay;

	Set @状況 = '';
	Set @状況 += 'dbo.T_RateHistory      ' + convert(varchar, @件数_RateHistory) + CHAR(13) + CHAR(10);
	Set @状況 += 'dbo.T_RateHistory_1m   ' + convert(varchar, @件数_RateHistory_1m) + CHAR(13) + CHAR(10);
	Set @状況 += 'dbo.T_RateHistory_5m   ' + convert(varchar, @件数_RateHistory_5m) + CHAR(13) + CHAR(10);
	Set @状況 += 'dbo.T_RateHistory_15m  ' + convert(varchar, @件数_RateHistory_15m) + CHAR(13) + CHAR(10);
	Set @状況 += 'dbo.T_RateHistory_30m  ' + convert(varchar, @件数_RateHistory_30m) + CHAR(13) + CHAR(10);
	Set @状況 += 'dbo.T_RateHistory_1h   ' + convert(varchar, @件数_RateHistory_1h) + CHAR(13) + CHAR(10);
	Set @状況 += 'dbo.T_RateHistory_6h   ' + convert(varchar, @件数_RateHistory_6h) + CHAR(13) + CHAR(10);
	Set @状況 += 'dbo.T_RateHistory_Day  ' + convert(varchar, @件数_RateHistory_Day) + CHAR(13) + CHAR(10);
	Set @状況 += 'dbo.T_Indicator_1m     ' + convert(varchar, @件数_Indicator_1m) + CHAR(13) + CHAR(10);
	Set @状況 += 'dbo.T_Indicator_5m     ' + convert(varchar, @件数_Indicator_5m) + CHAR(13) + CHAR(10);
	Set @状況 += 'dbo.T_Indicator_15m    ' + convert(varchar, @件数_Indicator_15m) + CHAR(13) + CHAR(10);
	Set @状況 += 'dbo.T_Indicator_30m    ' + convert(varchar, @件数_Indicator_30m) + CHAR(13) + CHAR(10);
	Set @状況 += 'dbo.T_Indicator_1h     ' + convert(varchar, @件数_Indicator_1h) + CHAR(13) + CHAR(10);
	Set @状況 += 'dbo.T_Indicator_6h     ' + convert(varchar, @件数_Indicator_6h) + CHAR(13) + CHAR(10);
	Set @状況 += 'dbo.T_Indicator_Day    ' + convert(varchar, @件数_Indicator_Day) + CHAR(13) + CHAR(10);

	Set @状況 += 'dbo.T_AccountsHistory    ' + convert(varchar, @件数_AccountsHistory) + CHAR(13) + CHAR(10);
	Set @状況 += 'dbo.T_BonusStageHistory  ' + convert(varchar, @件数_BonusStageHistory) + CHAR(13) + CHAR(10);
	Set @状況 += 'dbo.T_ClosedTrades       ' + convert(varchar, @件数_ClosedTrades) + CHAR(13) + CHAR(10);
	Set @状況 += 'dbo.T_OrderHistory       ' + convert(varchar, @件数_OrderHistory) + CHAR(13) + CHAR(10);
	Set @状況 += 'dbo.T_SwapHistory_Hourly ' + convert(varchar, @件数_SwapHistory_Hourly) + CHAR(13) + CHAR(10);
	Set @状況 += 'dbo.T_Trades             ' + convert(varchar, @件数_Trades) + CHAR(13) + CHAR(10);
	Set @状況 += 'dbo.T_差損益History      ' + convert(varchar, @件数_差損益History) + CHAR(13) + CHAR(10);

	--print @状況;

END
GO
/*
*/
