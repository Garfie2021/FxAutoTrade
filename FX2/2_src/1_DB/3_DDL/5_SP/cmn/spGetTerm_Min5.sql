USE [FX2_Demo]
GO

DROP PROCEDURE [cmn].[spGetTerm_Min5]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [cmn].[spGetTerm_Min5]
	@now			Datetime,
	@back_5m		int,		-- マイナス値にしか対応していない
	@Start5m		Datetime	output,
	@End5m			Datetime	output
AS
BEGIN
	/*
	DECLARE @now datetime = '2014/5/6 5:59:00'
	DECLARE @back_Day smallint = -1
	DECLARE @ThisDay date
	DECLARE @StartDate datetime
	DECLARE @EndDate datetime
	*/

	Set @now = DATEADD(MINUTE, @back_5m * 5, @now);


	if DATEPART(minute , @now) < 5
	begin
		Set @Start5m = convert(varchar, YEAR(@now)) + '/' + convert(varchar, MONTH(@now)) + '/' + convert(varchar, DAY(@now)) + ' ' + convert(varchar, DATEPART(HOUR, @now)) + ':00:00';
	end
	else if DATEPART(minute , @now) < 10
	begin
		Set @Start5m = convert(varchar, YEAR(@now)) + '/' + convert(varchar, MONTH(@now)) + '/' + convert(varchar, DAY(@now)) + ' ' + convert(varchar, DATEPART(HOUR, @now)) + ':05:00';
	end
	else if DATEPART(minute , @now) < 15
	begin
		Set @Start5m = convert(varchar, YEAR(@now)) + '/' + convert(varchar, MONTH(@now)) + '/' + convert(varchar, DAY(@now)) + ' ' + convert(varchar, DATEPART(HOUR, @now)) + ':10:00';
	end
	else if DATEPART(minute , @now) < 20
	begin
		Set @Start5m = convert(varchar, YEAR(@now)) + '/' + convert(varchar, MONTH(@now)) + '/' + convert(varchar, DAY(@now)) + ' ' + convert(varchar, DATEPART(HOUR, @now)) + ':15:00';
	end
	else if DATEPART(minute , @now) < 25
	begin
		Set @Start5m = convert(varchar, YEAR(@now)) + '/' + convert(varchar, MONTH(@now)) + '/' + convert(varchar, DAY(@now)) + ' ' + convert(varchar, DATEPART(HOUR, @now)) + ':20:00';
	end
	else if DATEPART(minute , @now) < 30
	begin
		Set @Start5m = convert(varchar, YEAR(@now)) + '/' + convert(varchar, MONTH(@now)) + '/' + convert(varchar, DAY(@now)) + ' ' + convert(varchar, DATEPART(HOUR, @now)) + ':25:00';
	end
	else if DATEPART(minute , @now) < 35
	begin
		Set @Start5m = convert(varchar, YEAR(@now)) + '/' + convert(varchar, MONTH(@now)) + '/' + convert(varchar, DAY(@now)) + ' ' + convert(varchar, DATEPART(HOUR, @now)) + ':30:00';
	end
	else if DATEPART(minute , @now) < 40
	begin
		Set @Start5m = convert(varchar, YEAR(@now)) + '/' + convert(varchar, MONTH(@now)) + '/' + convert(varchar, DAY(@now)) + ' ' + convert(varchar, DATEPART(HOUR, @now)) + ':35:00';
	end
	else if DATEPART(minute , @now) < 45
	begin
		Set @Start5m = convert(varchar, YEAR(@now)) + '/' + convert(varchar, MONTH(@now)) + '/' + convert(varchar, DAY(@now)) + ' ' + convert(varchar, DATEPART(HOUR, @now)) + ':40:00';
	end
	else if DATEPART(minute , @now) < 50
	begin
		Set @Start5m = convert(varchar, YEAR(@now)) + '/' + convert(varchar, MONTH(@now)) + '/' + convert(varchar, DAY(@now)) + ' ' + convert(varchar, DATEPART(HOUR, @now)) + ':45:00';
	end
	else if DATEPART(minute , @now) < 55
	begin
		Set @Start5m = convert(varchar, YEAR(@now)) + '/' + convert(varchar, MONTH(@now)) + '/' + convert(varchar, DAY(@now)) + ' ' + convert(varchar, DATEPART(HOUR, @now)) + ':50:00';
	end
	else
	begin
		Set @Start5m = convert(varchar, YEAR(@now)) + '/' + convert(varchar, MONTH(@now)) + '/' + convert(varchar, DAY(@now)) + ' ' + convert(varchar, DATEPART(HOUR, @now)) + ':55:00';
	end;

	Set @End5m = DATEADD(minute, 5, @Start5m);

	--select @Start30m, @End30m

END
GO
/*
*/

