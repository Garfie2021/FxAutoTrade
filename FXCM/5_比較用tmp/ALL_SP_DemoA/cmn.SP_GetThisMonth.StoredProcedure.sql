USE [RealA_FX]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [cmn].[SP_GetThisMonth]
	@now			Datetime,
	@back_Month		int,		-- マイナス値にしか対応していない
	@ThisMonth		Datetime	output,
	@StartDate		Datetime	output,
	@EndDate		Datetime	output
AS
BEGIN

	--Set @now = DATEADD(MONTH, @back_Month, @now); 不要

	if DAY(@now) = 1 and DATEPART(hour, @now) < 6
	begin
		Set @ThisMonth = DATEADD(MONTH, @back_Month -1, @now);
	end
	else
	begin
		Set @ThisMonth = DATEADD(MONTH, @back_Month, @now);
	end

	Set @ThisMonth = convert(varchar, YEAR(@ThisMonth)) + '/' + convert(varchar, MONTH(@ThisMonth))  + '/1 00:00:00';

	Set @StartDate = convert(varchar, YEAR(@ThisMonth)) + '/' + convert(varchar, MONTH(@ThisMonth))  + '/01 6:00:00';
	Set @EndDate = DATEADD(MONTH, 1, @StartDate);

END


GO
