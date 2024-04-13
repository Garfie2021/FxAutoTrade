USE [FX2_Demo]
GO

DROP PROCEDURE [cmn].[spGetTerm_Day1]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [cmn].[spGetTerm_Day1]
	@now			Datetime,
	@back_Day		int,		-- É}ÉCÉiÉXílÇ…ÇµÇ©ëŒâûÇµÇƒÇ¢Ç»Ç¢
	@ThisDay		Date		output,
	@StartDate		Datetime	output,
	@EndDate		Datetime	output
AS
BEGIN
	/*
	DECLARE @now datetime = '2014/5/6 5:59:00'
	DECLARE @back_Day smallint = -1
	DECLARE @ThisDay date
	DECLARE @StartDate datetime
	DECLARE @EndDate datetime
	*/

	Set @now = DATEADD(DAY, @back_Day, @now);

	-- éûä‘ë—í≤êÆ
	if DATEPART(hour, @now) < 6
	begin
		Set @now = DATEADD(DAY, -1, @now);
	end

	-- ìyì˙í≤êÆ
	declare @WeekName varchar(20) = DATENAME(WEEKDAY, @now);
	if @WeekName = 'ìyójì˙'
	begin
		Set @now = DATEADD(DAY, -1, @now);
	end
	else if @WeekName = 'ì˙ójì˙'
	begin
		Set @now = DATEADD(DAY, -2, @now);
	end;

	Set @ThisDay = @now;
	Set @StartDate = convert(varchar, YEAR(@ThisDay)) + '/' + convert(varchar, MONTH(@ThisDay)) + '/' + convert(varchar, DAY(@ThisDay)) + ' 6:00:00';
	Set @EndDate = DATEADD(DAY, 1, @StartDate);

	--select @ThisDay, @StartDate, @EndDate

END
GO
/*
*/

