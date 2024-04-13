USE [RealA_FX]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [cmn].[SP_GetThis6h]
	@now		Datetime,
	@back_6h	int = 0,		-- マイナス値にしか対応していない
	@Start6h	Datetime	output,
	@End6h		Datetime	output
AS
BEGIN
	/*
	DECLARE @now datetime = '2014/5/6 5:59:00'
	DECLARE @back_Day smallint = -1
	DECLARE @ThisDay date
	DECLARE @StartDate datetime
	DECLARE @EndDate datetime
	*/

	Set @now = DATEADD(HOUR, @back_6h * 6, @now);

	Declare @hour tinyint = DATEPART(hour , @now);

	if @hour < 6
	begin
		Set @Start6h = convert(varchar, YEAR(@now)) + '/' + convert(varchar, MONTH(@now)) + '/' + convert(varchar, DAY(@now)) + ' 00:00:00';
	end
	else if @hour < 12
	begin
		Set @Start6h = convert(varchar, YEAR(@now)) + '/' + convert(varchar, MONTH(@now)) + '/' + convert(varchar, DAY(@now)) + ' 06:00:00';
	end
	else if @hour < 18
	begin
		Set @Start6h = convert(varchar, YEAR(@now)) + '/' + convert(varchar, MONTH(@now)) + '/' + convert(varchar, DAY(@now)) + ' 12:00:00';
	end
	else
	begin
		Set @Start6h = convert(varchar, YEAR(@now)) + '/' + convert(varchar, MONTH(@now)) + '/' + convert(varchar, DAY(@now)) + ' 18:00:00';
	end;

	Set @End6h = DATEADD(HOUR, 6, @Start6h);

	--select @Start30m, @End30m

END

GO
