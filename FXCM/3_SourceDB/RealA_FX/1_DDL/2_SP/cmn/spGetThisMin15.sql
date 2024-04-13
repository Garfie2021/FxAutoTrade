USE [DemoA_FX]
GO
/*
*/
DROP PROCEDURE [cmn].[spGetThisMin15]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [cmn].[spGetThisMin15]
	@now			Datetime,
	@back_Min15		int,		-- マイナス値にしか対応していない
	@StartMin15		Datetime	output,
	@EndMin15			Datetime	output
AS
BEGIN
	/*
	DECLARE @now datetime = '2014/5/6 5:59:00'
	DECLARE @back_Day smallint = -1
	DECLARE @ThisDay date
	DECLARE @StartDate datetime
	DECLARE @EndDate datetime
	*/

	Set @now = DATEADD(MINUTE, @back_Min15 * 15, @now);

	if DATEPART(minute , @now) < 15
	begin
		Set @StartMin15 = convert(varchar, YEAR(@now)) + '/' + convert(varchar, MONTH(@now)) + '/' + convert(varchar, DAY(@now)) + ' ' + convert(varchar, DATEPART(HOUR, @now)) + ':00:00';
	end
	else if DATEPART(minute , @now) < 30
	begin
		Set @StartMin15 = convert(varchar, YEAR(@now)) + '/' + convert(varchar, MONTH(@now)) + '/' + convert(varchar, DAY(@now)) + ' ' + convert(varchar, DATEPART(HOUR, @now)) + ':15:00';
	end
	else if DATEPART(minute , @now) < 45
	begin
		Set @StartMin15 = convert(varchar, YEAR(@now)) + '/' + convert(varchar, MONTH(@now)) + '/' + convert(varchar, DAY(@now)) + ' ' + convert(varchar, DATEPART(HOUR, @now)) + ':30:00';
	end
	else
	begin
		Set @StartMin15 = convert(varchar, YEAR(@now)) + '/' + convert(varchar, MONTH(@now)) + '/' + convert(varchar, DAY(@now)) + ' ' + convert(varchar, DATEPART(HOUR, @now)) + ':45:00';
	end;

	Set @EndMin15 = DATEADD(minute, 15, @StartMin15);

	--select @StartMin15, @EndMin15

END
GO
/*
*/

