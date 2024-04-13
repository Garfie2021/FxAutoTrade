USE OANDA_DemoB
GO
/*
*/
DROP PROCEDURE [cmn].[spGetThisHour1]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [cmn].[spGetThisHour1]
	@now		Datetime,
	@back_Hour1	int = 0,		-- マイナス値にしか対応していない
	@StartHour1	Datetime	output,
	@EndHour1		Datetime	output
AS
BEGIN
	/*
	DECLARE @now datetime = '2014/5/6 5:59:00'
	DECLARE @back_Day smallint = -1
	DECLARE @ThisDay date
	DECLARE @StartDate datetime
	DECLARE @EndDate datetime
	*/

	Set @now = DATEADD(HOUR, @back_Hour1, @now);

	Set @StartHour1 = convert(varchar, YEAR(@now)) + '/' + convert(varchar, MONTH(@now)) + '/' + convert(varchar, DAY(@now)) + ' ' + convert(varchar, DATEPART(HOUR, @now)) + ':00:00';
	Set @EndHour1 = DATEADD(HOUR, 1, @StartHour1);

	--select @Start30m, @End30m

END
GO
/*
*/

