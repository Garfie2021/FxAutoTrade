USE [DemoA_FX]
GO
/*
*/
DROP PROCEDURE [cmn].[spGetThisHour6]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [cmn].[spGetThisHour6]
	@now		Datetime,
	@back_Hour6	int = 0,		-- マイナス値にしか対応していない
	@StartHour6	Datetime	output,
	@EndHour6	Datetime	output
AS
BEGIN
	/*
	DECLARE @now datetime = '2014/5/6 5:59:00'
	DECLARE @back_Day smallint = -1
	DECLARE @ThisDay date
	DECLARE @StartDate datetime
	DECLARE @EndDate datetime
	*/

	Set @now = DATEADD(HOUR, @back_Hour6 * 6, @now);

	Declare @hour tinyint = DATEPART(hour , @now);

	if @hour < 6
	begin
		Set @StartHour6 = convert(varchar, YEAR(@now)) + '/' + convert(varchar, MONTH(@now)) + '/' + convert(varchar, DAY(@now)) + ' 00:00:00';
	end
	else if @hour < 12
	begin
		Set @StartHour6 = convert(varchar, YEAR(@now)) + '/' + convert(varchar, MONTH(@now)) + '/' + convert(varchar, DAY(@now)) + ' 06:00:00';
	end
	else if @hour < 18
	begin
		Set @StartHour6 = convert(varchar, YEAR(@now)) + '/' + convert(varchar, MONTH(@now)) + '/' + convert(varchar, DAY(@now)) + ' 12:00:00';
	end
	else
	begin
		Set @StartHour6 = convert(varchar, YEAR(@now)) + '/' + convert(varchar, MONTH(@now)) + '/' + convert(varchar, DAY(@now)) + ' 18:00:00';
	end;

	Set @EndHour6 = DATEADD(HOUR, 6, @StartHour6);

	--select @Start30m, @End30m

END
GO
/*
*/

