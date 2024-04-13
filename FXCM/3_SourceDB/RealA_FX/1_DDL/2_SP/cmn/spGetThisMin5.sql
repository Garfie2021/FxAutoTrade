USE [DemoA_FX]
GO
/*
*/
DROP PROCEDURE [cmn].[spGetThisMin5]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [cmn].[spGetThisMin5]
	@now			Datetime,
	@back_Min5		int,		-- マイナス値にしか対応していない
	@StartMin5		Datetime	output,
	@EndMin5		Datetime	output
AS
BEGIN
	/*
	DECLARE @now		datetime = '2016-01-11 23:36:00.970';
	DECLARE @back_Min5	smallint = -1;
	DECLARE @StartMin5	datetime;
	DECLARE @EndMin5	datetime;
	*/

	Set @now = DATEADD(MINUTE, @back_Min5 * 5, @now);


	if DATEPART(minute , @now) < 5
	begin
		Set @StartMin5 = convert(varchar, YEAR(@now)) + '/' + convert(varchar, MONTH(@now)) + '/' + convert(varchar, DAY(@now)) + ' ' + convert(varchar, DATEPART(HOUR, @now)) + ':00:00';
	end
	else if DATEPART(minute , @now) < 10
	begin
		Set @StartMin5 = convert(varchar, YEAR(@now)) + '/' + convert(varchar, MONTH(@now)) + '/' + convert(varchar, DAY(@now)) + ' ' + convert(varchar, DATEPART(HOUR, @now)) + ':05:00';
	end
	else if DATEPART(minute , @now) < 15
	begin
		Set @StartMin5 = convert(varchar, YEAR(@now)) + '/' + convert(varchar, MONTH(@now)) + '/' + convert(varchar, DAY(@now)) + ' ' + convert(varchar, DATEPART(HOUR, @now)) + ':10:00';
	end
	else if DATEPART(minute , @now) < 20
	begin
		Set @StartMin5 = convert(varchar, YEAR(@now)) + '/' + convert(varchar, MONTH(@now)) + '/' + convert(varchar, DAY(@now)) + ' ' + convert(varchar, DATEPART(HOUR, @now)) + ':15:00';
	end
	else if DATEPART(minute , @now) < 25
	begin
		Set @StartMin5 = convert(varchar, YEAR(@now)) + '/' + convert(varchar, MONTH(@now)) + '/' + convert(varchar, DAY(@now)) + ' ' + convert(varchar, DATEPART(HOUR, @now)) + ':20:00';
	end
	else if DATEPART(minute , @now) < 30
	begin
		Set @StartMin5 = convert(varchar, YEAR(@now)) + '/' + convert(varchar, MONTH(@now)) + '/' + convert(varchar, DAY(@now)) + ' ' + convert(varchar, DATEPART(HOUR, @now)) + ':25:00';
	end
	else if DATEPART(minute , @now) < 35
	begin
		Set @StartMin5 = convert(varchar, YEAR(@now)) + '/' + convert(varchar, MONTH(@now)) + '/' + convert(varchar, DAY(@now)) + ' ' + convert(varchar, DATEPART(HOUR, @now)) + ':30:00';
	end
	else if DATEPART(minute , @now) < 40
	begin
		Set @StartMin5 = convert(varchar, YEAR(@now)) + '/' + convert(varchar, MONTH(@now)) + '/' + convert(varchar, DAY(@now)) + ' ' + convert(varchar, DATEPART(HOUR, @now)) + ':35:00';
	end
	else if DATEPART(minute , @now) < 45
	begin
		Set @StartMin5 = convert(varchar, YEAR(@now)) + '/' + convert(varchar, MONTH(@now)) + '/' + convert(varchar, DAY(@now)) + ' ' + convert(varchar, DATEPART(HOUR, @now)) + ':40:00';
	end
	else if DATEPART(minute , @now) < 50
	begin
		Set @StartMin5 = convert(varchar, YEAR(@now)) + '/' + convert(varchar, MONTH(@now)) + '/' + convert(varchar, DAY(@now)) + ' ' + convert(varchar, DATEPART(HOUR, @now)) + ':45:00';
	end
	else if DATEPART(minute , @now) < 55
	begin
		Set @StartMin5 = convert(varchar, YEAR(@now)) + '/' + convert(varchar, MONTH(@now)) + '/' + convert(varchar, DAY(@now)) + ' ' + convert(varchar, DATEPART(HOUR, @now)) + ':50:00';
	end
	else
	begin
		Set @StartMin5 = convert(varchar, YEAR(@now)) + '/' + convert(varchar, MONTH(@now)) + '/' + convert(varchar, DAY(@now)) + ' ' + convert(varchar, DATEPART(HOUR, @now)) + ':55:00';
	end;

	Set @EndMin5 = DATEADD(minute, 5, @StartMin5);


	--select @now, @back_Min5, @StartMin5, @EndMin5;

END
GO
/*
*/

