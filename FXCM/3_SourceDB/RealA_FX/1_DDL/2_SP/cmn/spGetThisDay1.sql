USE [DemoA_FX]
GO
/*
*/
DROP PROCEDURE [cmn].[spGetThisDay1]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [cmn].[spGetThisDay1]
	@now			Datetime,
	@back_Day1		int,		-- É}ÉCÉiÉXílÇ…ÇµÇ©ëŒâûÇµÇƒÇ¢Ç»Ç¢
	@ThisDay1		Date		output,
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

	Set @now = DATEADD(DAY, @back_Day1, @now);

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

	Set @ThisDay1 = @now;
	Set @StartDate = convert(varchar, YEAR(@ThisDay1)) + '/' + convert(varchar, MONTH(@ThisDay1)) + '/' + convert(varchar, DAY(@ThisDay1)) + ' 6:00:00';
	Set @EndDate = DATEADD(DAY, 1, @StartDate);

	--select @ThisDay, @StartDate, @EndDate

END
GO
/*
*/

