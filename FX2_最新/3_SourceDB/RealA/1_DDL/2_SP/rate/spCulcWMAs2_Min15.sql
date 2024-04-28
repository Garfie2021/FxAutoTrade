USE OANDA_DemoB
GO
/*
*/
DROP PROCEDURE [rate].[spCulcWMAs2_Min15]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [rate].[spCulcWMAs2_Min15]
	@�ʉ݃y�ANo	tinyint,
	@StartDate	datetime,
	@����WMAs2	float	output,
	@����WMAs2	float	output
AS
BEGIN
	/*	
	declare @�ʉ݃y�ANo	tinyint = 0;
	declare @StartDate	datetime = '2015/12/04 21:30:00';
	declare @����WMAs2	float;
	declare @����WMAs2	float;
	*/

	declare @���� datetime;
	declare @����Rate_�I�l float = 0;
	declare @����Rate_�I�l float = 0;

	declare @����	float = 2; --  Top 2 ����{�l
	declare @�O�p��	float = 0; --  Top 2 ����{�l
	
	exec [cmn].[spGet�O�p��] @����, @�O�p�� output;

	declare cursor_tRateHistory_Min15 cursor for
	SELECT TOP 2 --  Top 2 ����{�l
       [StartDate], [����Rate_�I�l], [����Rate_�I�l]
	FROM [hstr].[tMin15]
	where �ʉ݃y�ANo = @�ʉ݃y�ANo and [StartDate] <= @StartDate
	order by [StartDate] desc;
	
	open cursor_tRateHistory_Min15;

	FETCH NEXT FROM cursor_tRateHistory_Min15 INTO @����, @����Rate_�I�l, @����Rate_�I�l;

	declare @����Cnt int = @����;
	Set @����WMAs2 = 0;
	Set @����WMAs2 = 0;

	Set @����WMAs2 = @����WMAs2 + (@����Rate_�I�l * (@����Cnt / @�O�p��));
	Set @����WMAs2 = @����WMAs2 + (@����Rate_�I�l * (@����Cnt / @�O�p��));

	FETCH NEXT FROM cursor_tRateHistory_Min15 INTO @����, @����Rate_�I�l, @����Rate_�I�l;
	Set @����Cnt = @����Cnt - 1;

	Set @����WMAs2 = @����WMAs2 + (@����Rate_�I�l * (@����Cnt / @�O�p��));
	Set @����WMAs2 = @����WMAs2 + (@����Rate_�I�l * (@����Cnt / @�O�p��));

	CLOSE cursor_tRateHistory_Min15;
	DEALLOCATE cursor_tRateHistory_Min15;

	--SELECT @����WMAs2, @����WMAs2;

END
GO
/*
*/
