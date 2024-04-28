USE [RealB_2370741683_FX]
GO
/*
*/
DROP PROCEDURE [hltc].[SP_Get���R�[�h�̏�]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [hltc].[SP_Get���R�[�h�̏�]
	@back_Day	int = -1,
	@��		varchar(5000)	output
AS
BEGIN
	/*
	declare @back_Day	int = -1
	DECLARE @��		varchar(5000) = '';
	*/


	DECLARE @now datetime = getdate();
	DECLARE @ThisDay date;
	DECLARE @StartDate datetime;
	DECLARE @EndDate datetime;
	EXECUTE [cmn].[spGetThisDay1] @now, @back_Day, @ThisDay OUTPUT, @StartDate OUTPUT, @EndDate OUTPUT;

	DECLARE @����					date
	DECLARE @����_RateHistory		int
	DECLARE @����_RateHistory_1m	int
	DECLARE @����_RateHistory_5m	int
	DECLARE @����_RateHistory_15m	int
	DECLARE @����_RateHistory_30m	int
	DECLARE @����_RateHistory_1h	int
	DECLARE @����_RateHistory_6h	int
	DECLARE @����_RateHistory_Day	int
	DECLARE @����_Indicator_1m		int
	DECLARE @����_Indicator_5m		int
	DECLARE @����_Indicator_15m		int
	DECLARE @����_Indicator_30m		int
	DECLARE @����_Indicator_1h		int
	DECLARE @����_Indicator_6h		int
	DECLARE @����_Indicator_Day		int
	DECLARE @����_AccountsHistory		int
	DECLARE @����_BonusStageHistory		int
	DECLARE @����_ClosedTrades			int
	DECLARE @����_OrderHistory			int
	DECLARE @����_SwapHistory_Hourly	int
	DECLARE @����_Trades				int
	DECLARE @����_�����vHistory			int

	SELECT 
		 @����_RateHistory =		[����_RateHistory]
		,@����_RateHistory_1m =		[����_RateHistory_1m]
		,@����_RateHistory_5m =		[����_RateHistory_5m]
		,@����_RateHistory_15m =	[����_RateHistory_15m]
		,@����_RateHistory_30m =	[����_RateHistory_30m]
		,@����_RateHistory_1h =		[����_RateHistory_1h]
		,@����_RateHistory_6h =		[����_RateHistory_6h]
		,@����_RateHistory_Day =	[����_RateHistory_Day]
		,@����_Indicator_1m =		[����_Indicator_1m]
		,@����_Indicator_5m =		[����_Indicator_5m]
		,@����_Indicator_15m =		[����_Indicator_15m]
		,@����_Indicator_30m =		[����_Indicator_30m]
		,@����_Indicator_1h =		[����_Indicator_1h]
		,@����_Indicator_6h =		[����_Indicator_6h]
		,@����_Indicator_Day =		[����_Indicator_Day]
		,@����_AccountsHistory =	[����_AccountsHistory]
		,@����_BonusStageHistory =	[����_BonusStageHistory]
		,@����_ClosedTrades =		[����_ClosedTrades]
		,@����_OrderHistory =		[����_OrderHistory]
		,@����_SwapHistory_Hourly =	[����_SwapHistory_Hourly]
		,@����_Trades =				[����_Trades]
		,@����_�����vHistory =		[����_�����vHistory]
	FROM [hltc].[T_�f�[�^Cnt_Daily]
	WHERE [����] = @ThisDay;

	Set @�� = '';
	Set @�� += 'dbo.T_RateHistory      ' + convert(varchar, @����_RateHistory) + CHAR(13) + CHAR(10);
	Set @�� += 'dbo.T_RateHistory_1m   ' + convert(varchar, @����_RateHistory_1m) + CHAR(13) + CHAR(10);
	Set @�� += 'dbo.T_RateHistory_5m   ' + convert(varchar, @����_RateHistory_5m) + CHAR(13) + CHAR(10);
	Set @�� += 'dbo.T_RateHistory_15m  ' + convert(varchar, @����_RateHistory_15m) + CHAR(13) + CHAR(10);
	Set @�� += 'dbo.T_RateHistory_30m  ' + convert(varchar, @����_RateHistory_30m) + CHAR(13) + CHAR(10);
	Set @�� += 'dbo.T_RateHistory_1h   ' + convert(varchar, @����_RateHistory_1h) + CHAR(13) + CHAR(10);
	Set @�� += 'dbo.T_RateHistory_6h   ' + convert(varchar, @����_RateHistory_6h) + CHAR(13) + CHAR(10);
	Set @�� += 'dbo.T_RateHistory_Day  ' + convert(varchar, @����_RateHistory_Day) + CHAR(13) + CHAR(10);
	Set @�� += 'dbo.T_Indicator_1m     ' + convert(varchar, @����_Indicator_1m) + CHAR(13) + CHAR(10);
	Set @�� += 'dbo.T_Indicator_5m     ' + convert(varchar, @����_Indicator_5m) + CHAR(13) + CHAR(10);
	Set @�� += 'dbo.T_Indicator_15m    ' + convert(varchar, @����_Indicator_15m) + CHAR(13) + CHAR(10);
	Set @�� += 'dbo.T_Indicator_30m    ' + convert(varchar, @����_Indicator_30m) + CHAR(13) + CHAR(10);
	Set @�� += 'dbo.T_Indicator_1h     ' + convert(varchar, @����_Indicator_1h) + CHAR(13) + CHAR(10);
	Set @�� += 'dbo.T_Indicator_6h     ' + convert(varchar, @����_Indicator_6h) + CHAR(13) + CHAR(10);
	Set @�� += 'dbo.T_Indicator_Day    ' + convert(varchar, @����_Indicator_Day) + CHAR(13) + CHAR(10);

	Set @�� += 'dbo.T_AccountsHistory    ' + convert(varchar, @����_AccountsHistory) + CHAR(13) + CHAR(10);
	Set @�� += 'dbo.T_BonusStageHistory  ' + convert(varchar, @����_BonusStageHistory) + CHAR(13) + CHAR(10);
	Set @�� += 'dbo.T_ClosedTrades       ' + convert(varchar, @����_ClosedTrades) + CHAR(13) + CHAR(10);
	Set @�� += 'dbo.T_OrderHistory       ' + convert(varchar, @����_OrderHistory) + CHAR(13) + CHAR(10);
	Set @�� += 'dbo.T_SwapHistory_Hourly ' + convert(varchar, @����_SwapHistory_Hourly) + CHAR(13) + CHAR(10);
	Set @�� += 'dbo.T_Trades             ' + convert(varchar, @����_Trades) + CHAR(13) + CHAR(10);
	Set @�� += 'dbo.T_�����vHistory      ' + convert(varchar, @����_�����vHistory) + CHAR(13) + CHAR(10);

	--print @��;

END
GO
/*
*/
