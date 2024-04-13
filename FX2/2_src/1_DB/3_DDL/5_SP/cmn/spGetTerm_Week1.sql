USE [FX2_Demo]
GO

DROP PROCEDURE [cmn].[spGetTerm_Week1]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [cmn].[spGetTerm_Week1]
	@now			Datetime,
	@back_Week		int,		-- ƒ}ƒCƒiƒX’l‚É‚µ‚©‘Î‰‚µ‚Ä‚¢‚È‚¢B@-1F1TŠÔ‘O@-2F2TŠÔ‘O
	@ThisWeek		Date		output,
	@StartDate		Datetime	output,
	@EndDate		Datetime	output
AS
BEGIN
	/*
	declare @now			Datetime = '2014/5/5 6:00:00'
	declare @ThisWeek		Date
	declare @StartDate		Datetime
	declare @EndDate		Datetime
	*/

	Set @now = DATEADD(DAY, @back_Week * 7, @now);

	declare @Œ—j“ú‚Ü‚Å‚Ì“ú” smallint;

	declare @WeekName varchar(20) = DATENAME(WEEKDAY, @now);
	if @WeekName = 'Œ—j“ú'
	begin
		Set @Œ—j“ú‚Ü‚Å‚Ì“ú” = 0;
	end
	else if @WeekName = '‰Î—j“ú'
	begin
		Set @Œ—j“ú‚Ü‚Å‚Ì“ú” = -1;
	end
	else if @WeekName = '…—j“ú'
	begin
		Set @Œ—j“ú‚Ü‚Å‚Ì“ú” = -2;
	end
	else if @WeekName = '–Ø—j“ú'
	begin
		Set @Œ—j“ú‚Ü‚Å‚Ì“ú” = -3;
	end
	else if @WeekName = '‹à—j“ú'
	begin
		Set @Œ—j“ú‚Ü‚Å‚Ì“ú” = -4;
	end
	else if @WeekName = '“y—j“ú'
	begin
		Set @Œ—j“ú‚Ü‚Å‚Ì“ú” = -5;
	end
	else if @WeekName = '“ú—j“ú'
	begin
		Set @Œ—j“ú‚Ü‚Å‚Ì“ú” = -6;
	end;

	Set @ThisWeek = DATEADD(DAY, @Œ—j“ú‚Ü‚Å‚Ì“ú”, @now);
	Set @StartDate = convert(varchar, YEAR(@ThisWeek)) + '/' + convert(varchar, MONTH(@ThisWeek)) + '/' + convert(varchar, DAY(@ThisWeek)) + ' 00:00:00';
	Set @EndDate = DATEADD(DAY, 6, @StartDate);

	--select @ThisWeek, @StartDate, @EndDate

END
GO
/*
*/
