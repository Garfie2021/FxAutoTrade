USE [DemoA_FX]
GO
/*
*/
DROP PROCEDURE [cmn].[spGetThisMin1]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [cmn].[spGetThisMin1]
	@now			Datetime,
	@back_Min1		int,		-- マイナス値にしか対応していない
	@StartMin1		Datetime	output,
	@EndMin1			Datetime	output
AS
BEGIN
	/*
	DECLARE @now datetime = '2014/5/6 5:59:00'
	DECLARE @back_Day smallint = -1
	DECLARE @ThisDay date
	DECLARE @StartDate datetime
	DECLARE @EndDate datetime
	*/

	Set @now = DATEADD(MINUTE, @back_Min1, @now);

	Set @StartMin1 = convert(varchar, YEAR(@now)) + '/' + convert(varchar, MONTH(@now)) + '/' + convert(varchar, DAY(@now)) + ' ' + 
	convert(varchar, DATEPART(HOUR, @now)) + ':' + convert(varchar, DATEPART(minute, @now)) + ':00';

	Set @EndMin1 = DATEADD(minute, 1, @StartMin1);

	--select @Start30m, @End30m

END
GO
/*
*/

