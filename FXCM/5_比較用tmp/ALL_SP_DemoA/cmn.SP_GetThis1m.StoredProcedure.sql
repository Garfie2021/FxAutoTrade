USE [RealA_FX]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [cmn].[SP_GetThis1m]
	@now			Datetime,
	@back_1m		int,		-- マイナス値にしか対応していない
	@Start1m		Datetime	output,
	@End1m			Datetime	output
AS
BEGIN
	/*
	DECLARE @now datetime = '2014/5/6 5:59:00'
	DECLARE @back_Day smallint = -1
	DECLARE @ThisDay date
	DECLARE @StartDate datetime
	DECLARE @EndDate datetime
	*/

	Set @now = DATEADD(MINUTE, @back_1m, @now);

	Set @Start1m = convert(varchar, YEAR(@now)) + '/' + convert(varchar, MONTH(@now)) + '/' + convert(varchar, DAY(@now)) + ' ' + 
	convert(varchar, DATEPART(HOUR, @now)) + ':' + convert(varchar, DATEPART(minute, @now)) + ':00';

	Set @End1m = DATEADD(minute, 1, @Start1m);

	--select @Start30m, @End30m

END

GO
