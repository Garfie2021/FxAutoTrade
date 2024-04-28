USE [FX2_Demo]
GO

DROP PROCEDURE [cmn].[spGetTerm_Min15]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [cmn].[spGetTerm_Min15]
	@now			Datetime,
	@back_15m		int,		-- �}�C�i�X�l�ɂ����Ή����Ă��Ȃ�
	@Start15m		Datetime	output,
	@End15m			Datetime	output
AS
BEGIN
	/*
	DECLARE @now datetime = '2014/5/6 5:59:00'
	DECLARE @back_Day smallint = -1
	DECLARE @ThisDay date
	DECLARE @StartDate datetime
	DECLARE @EndDate datetime
	*/

	Set @now = DATEADD(MINUTE, @back_15m * 15, @now);

	if DATEPART(minute , @now) < 15
	begin
		Set @Start15m = convert(varchar, YEAR(@now)) + '/' + convert(varchar, MONTH(@now)) + '/' + convert(varchar, DAY(@now)) + ' ' + convert(varchar, DATEPART(HOUR, @now)) + ':00:00';
	end
	else if DATEPART(minute , @now) < 30
	begin
		Set @Start15m = convert(varchar, YEAR(@now)) + '/' + convert(varchar, MONTH(@now)) + '/' + convert(varchar, DAY(@now)) + ' ' + convert(varchar, DATEPART(HOUR, @now)) + ':15:00';
	end
	else if DATEPART(minute , @now) < 45
	begin
		Set @Start15m = convert(varchar, YEAR(@now)) + '/' + convert(varchar, MONTH(@now)) + '/' + convert(varchar, DAY(@now)) + ' ' + convert(varchar, DATEPART(HOUR, @now)) + ':30:00';
	end
	else
	begin
		Set @Start15m = convert(varchar, YEAR(@now)) + '/' + convert(varchar, MONTH(@now)) + '/' + convert(varchar, DAY(@now)) + ' ' + convert(varchar, DATEPART(HOUR, @now)) + ':45:00';
	end;

	Set @End15m = DATEADD(minute, 15, @Start15m);

	--select @Start15m, @End15m

END
GO
/*
*/

