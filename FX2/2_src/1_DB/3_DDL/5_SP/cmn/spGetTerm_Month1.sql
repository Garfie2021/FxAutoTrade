USE [FX2_Demo]
GO

DROP PROCEDURE [cmn].[spGetTerm_Month1]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [cmn].[spGetTerm_Month1]
	@now			Datetime,
	@back_Month		int,		-- マイナス値にしか対応していない
	@StartDate		Datetime	output,
	@EndDate		Datetime	output
AS
BEGIN

	declare @ThisMonth datetime;

	--Set @now = DATEADD(MONTH, @back_Month, @now); 不要

	if DAY(@now) = 1 and DATEPART(hour, @now) < 6
	begin
		Set @ThisMonth = DATEADD(MONTH, @back_Month -1, @now);
	end
	else
	begin
		Set @ThisMonth = DATEADD(MONTH, @back_Month, @now);
	end

	Set @StartDate = convert(varchar, YEAR(@ThisMonth)) + '/' + convert(varchar, MONTH(@ThisMonth))  + '/01 6:00:00';
	Set @EndDate = DATEADD(MONTH, 1, @StartDate);
END

GO

