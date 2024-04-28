USE OANDA_DemoB
GO

DROP PROCEDURE [cmn].[spGetThisWeek1]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [cmn].[spGetThisWeek1]
	@now			Datetime,
	@back_Week1		int,		-- �}�C�i�X�l�ɂ����Ή����Ă��Ȃ��B�@-1�F1�T�ԑO�@-2�F2�T�ԑO
	@ThisWeek1		Date		output,
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

	Set @now = DATEADD(DAY, @back_Week1 * 7, @now);

	declare @���j���܂ł̓��� smallint;

	declare @WeekName varchar(20) = DATENAME(WEEKDAY, @now);
	if @WeekName = '���j��'
	begin
		Set @���j���܂ł̓��� = 0;
	end
	else if @WeekName = '�Ηj��'
	begin
		Set @���j���܂ł̓��� = -1;
	end
	else if @WeekName = '���j��'
	begin
		Set @���j���܂ł̓��� = -2;
	end
	else if @WeekName = '�ؗj��'
	begin
		Set @���j���܂ł̓��� = -3;
	end
	else if @WeekName = '���j��'
	begin
		Set @���j���܂ł̓��� = -4;
	end
	else if @WeekName = '�y�j��'
	begin
		Set @���j���܂ł̓��� = -5;
	end
	else if @WeekName = '���j��'
	begin
		Set @���j���܂ł̓��� = -6;
	end;

	Set @ThisWeek1 = DATEADD(DAY, @���j���܂ł̓���, @now);
	Set @StartDate = convert(varchar, YEAR(@ThisWeek1)) + '/' + convert(varchar, MONTH(@ThisWeek1)) + '/' + convert(varchar, DAY(@ThisWeek1)) + ' 06:00:00';
	Set @EndDate = DATEADD(DAY, 7, @StartDate);

	--select @ThisWeek, @StartDate, @EndDate

END
GO
/*
*/
