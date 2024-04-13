USE OANDA_DemoB
GO
/*
*/
DROP PROCEDURE [cmn].[spChkTrade時間外]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [cmn].[spChkTrade時間外]
	@now	datetime,
	@時間外	tinyint		OUTPUT	-- 0=時間内 1=時間外 
AS
BEGIN
	/*
	declare @now	datetime = '2014-06-24 19:00:00.000'
	declare @時間外	tinyint
	*/

	declare @WeekName varchar(20) = DATENAME(WEEKDAY, @now);

	if @WeekName = '土曜日' AND DATEPART(HOUR, @now) > 6
	begin
		Set @時間外 = 1;	--時間外
	end
	else if @WeekName = '日曜日'
	begin
		Set @時間外 = 1;	--時間外
	end
	else if @WeekName = '月曜日' AND DATEPART(HOUR, @now) < 5
	begin
		Set @時間外 = 1;	--時間外
	end
	else
	begin
		Set @時間外 = 0;	--時間内
	end;

	--select @時間外
END
GO
/*
*/

