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
	@back_Week		int,		-- マイナス値にしか対応していない。　-1：1週間前　-2：2週間前
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

	declare @月曜日までの日数 smallint;

	declare @WeekName varchar(20) = DATENAME(WEEKDAY, @now);
	if @WeekName = '月曜日'
	begin
		Set @月曜日までの日数 = 0;
	end
	else if @WeekName = '火曜日'
	begin
		Set @月曜日までの日数 = -1;
	end
	else if @WeekName = '水曜日'
	begin
		Set @月曜日までの日数 = -2;
	end
	else if @WeekName = '木曜日'
	begin
		Set @月曜日までの日数 = -3;
	end
	else if @WeekName = '金曜日'
	begin
		Set @月曜日までの日数 = -4;
	end
	else if @WeekName = '土曜日'
	begin
		Set @月曜日までの日数 = -5;
	end
	else if @WeekName = '日曜日'
	begin
		Set @月曜日までの日数 = -6;
	end;

	Set @ThisWeek = DATEADD(DAY, @月曜日までの日数, @now);
	Set @StartDate = convert(varchar, YEAR(@ThisWeek)) + '/' + convert(varchar, MONTH(@ThisWeek)) + '/' + convert(varchar, DAY(@ThisWeek)) + ' 00:00:00';
	Set @EndDate = DATEADD(DAY, 6, @StartDate);

	--select @ThisWeek, @StartDate, @EndDate

END
GO
/*
*/
