USE [FX2_Demo]
GO

DROP PROCEDURE [cmn].[spGetTerm_Hour1]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [cmn].[spGetTerm_Hour1]
	@now		Datetime,
	@back_1h	int = 0,		-- マイナス値にしか対応していない
	@Start1h	Datetime	output,
	@End1h		Datetime	output
AS
BEGIN
	/*
	DECLARE @now datetime = '2014/5/6 5:59:00'
	DECLARE @back_Day smallint = -1
	DECLARE @ThisDay date
	DECLARE @StartDate datetime
	DECLARE @EndDate datetime
	*/

	Set @now = DATEADD(HOUR, @back_1h, @now);

	Set @Start1h = convert(varchar, YEAR(@now)) + '/' + convert(varchar, MONTH(@now)) + '/' + convert(varchar, DAY(@now)) + ' ' + convert(varchar, DATEPART(HOUR, @now)) + ':00:00';
	Set @End1h = DATEADD(HOUR, 1, @Start1h);

	--select @Start30m, @End30m

END
GO
/*
*/

