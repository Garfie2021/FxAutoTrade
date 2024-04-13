USE [FX2_Demo]
GO

DROP PROCEDURE [cmn].[spGetTerm_Min30]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [cmn].[spGetTerm_Min30]
	@now			Datetime,
	@back_30m		int,		-- マイナス値にしか対応していない
	@Start30m		Datetime	output,
	@End30m			Datetime	output
AS
BEGIN
	/*
	DECLARE @now datetime = '2014/5/6 5:59:00'
	DECLARE @back_Day smallint = -1
	DECLARE @ThisDay date
	DECLARE @StartDate datetime
	DECLARE @EndDate datetime
	*/

	Set @now = DATEADD(MINUTE, @back_30m * 30, @now);


	if DATEPART(minute , @now) < 30
	begin
		Set @Start30m = convert(varchar, YEAR(@now)) + '/' + convert(varchar, MONTH(@now)) + '/' + convert(varchar, DAY(@now)) + ' ' + convert(varchar, DATEPART(HOUR, @now)) + ':00:00';
	end
	else
	begin
		Set @Start30m = convert(varchar, YEAR(@now)) + '/' + convert(varchar, MONTH(@now)) + '/' + convert(varchar, DAY(@now)) + ' ' + convert(varchar, DATEPART(HOUR, @now)) + ':30:00';
	end;

	Set @End30m = DATEADD(minute, 30, @Start30m);

	--select @Start30m, @End30m

END
GO
/*
*/

