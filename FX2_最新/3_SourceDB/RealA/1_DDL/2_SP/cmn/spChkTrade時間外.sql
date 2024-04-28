USE OANDA_DemoB
GO
/*
*/
DROP PROCEDURE [cmn].[spChkTrade���ԊO]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [cmn].[spChkTrade���ԊO]
	@now	datetime,
	@���ԊO	tinyint		OUTPUT	-- 0=���ԓ� 1=���ԊO 
AS
BEGIN
	/*
	declare @now	datetime = '2014-06-24 19:00:00.000'
	declare @���ԊO	tinyint
	*/

	declare @WeekName varchar(20) = DATENAME(WEEKDAY, @now);

	if @WeekName = '�y�j��' AND DATEPART(HOUR, @now) > 6
	begin
		Set @���ԊO = 1;	--���ԊO
	end
	else if @WeekName = '���j��'
	begin
		Set @���ԊO = 1;	--���ԊO
	end
	else if @WeekName = '���j��' AND DATEPART(HOUR, @now) < 5
	begin
		Set @���ԊO = 1;	--���ԊO
	end
	else
	begin
		Set @���ԊO = 0;	--���ԓ�
	end;

	--select @���ԊO
END
GO
/*
*/

