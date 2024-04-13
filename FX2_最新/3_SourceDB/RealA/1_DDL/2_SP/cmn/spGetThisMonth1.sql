USE OANDA_DemoB
GO

DROP PROCEDURE [cmn].[spGetThisMonth1]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [cmn].[spGetThisMonth1]
	@now			Datetime,
	@back_Month1		int,		-- マイナス値にしか対応していない
	@ThisMonth1		Datetime	output,
	@StartDate		Datetime	output,
	@EndDate		Datetime	output
AS
BEGIN

	--Set @now = DATEADD(MONTH, @back_Month, @now); 不要

	if DAY(@now) = 1 and DATEPART(hour, @now) < 6
	begin
		Set @ThisMonth1 = DATEADD(MONTH, @back_Month1 -1, @now);
	end
	else
	begin
		Set @ThisMonth1 = DATEADD(MONTH, @back_Month1, @now);
	end

	Set @ThisMonth1 = convert(varchar, YEAR(@ThisMonth1)) + '/' + convert(varchar, MONTH(@ThisMonth1))  + '/1 00:00:00';

	Set @StartDate = convert(varchar, YEAR(@ThisMonth1)) + '/' + convert(varchar, MONTH(@ThisMonth1))  + '/01 6:00:00';
	Set @EndDate = DATEADD(MONTH, 1, @StartDate);

END

GO

