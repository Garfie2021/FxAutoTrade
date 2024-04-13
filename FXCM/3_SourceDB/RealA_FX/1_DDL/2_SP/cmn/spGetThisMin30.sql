USE [DemoA_FX]
GO
/*
*/
DROP PROCEDURE [cmn].[spGetThisMin30]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [cmn].[spGetThisMin30]
	@now			Datetime,
	@back_Min30		int,		-- マイナス値にしか対応していない
	@StartMin30		Datetime	output,
	@EndMin30			Datetime	output
AS
BEGIN
	/*
	DECLARE @now datetime = '2014/5/6 5:59:00'
	DECLARE @back_Day smallint = -1
	DECLARE @ThisDay date
	DECLARE @StartDate datetime
	DECLARE @EndDate datetime
	*/

	Set @now = DATEADD(MINUTE, @back_Min30 * 30, @now);


	if DATEPART(minute , @now) < 30
	begin
		Set @StartMin30 = convert(varchar, YEAR(@now)) + '/' + convert(varchar, MONTH(@now)) + '/' + convert(varchar, DAY(@now)) + ' ' + convert(varchar, DATEPART(HOUR, @now)) + ':00:00';
	end
	else
	begin
		Set @StartMin30 = convert(varchar, YEAR(@now)) + '/' + convert(varchar, MONTH(@now)) + '/' + convert(varchar, DAY(@now)) + ' ' + convert(varchar, DATEPART(HOUR, @now)) + ':30:00';
	end;

	Set @EndMin30 = DATEADD(minute, 30, @StartMin30);

	--select @StartMin30, @EndMin30

END
GO
/*
*/

