USE [RealB_2370741683_FX]
GO
/*
*/
DROP PROCEDURE [rate].[spCulcWMAs14_Hour1]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [rate].[spCulcWMAs14_Hour1]
	@�ʉ݃y�ANo	tinyint,
	@StartDate	datetime,
	@����WMAs14	float	output,
	@����WMAs14	float	output
AS
BEGIN
	/*
	declare @�ʉ݃y�ANo		tinyint = 0;
	declare @StartDate		datetime = '2015-08-24 07:00:00.000';
	declare @����WMAs14		float;
	declare @����WMAs14		float;
	*/

	declare @����	float = 14; --  Top 14 ����{�l
	declare @�O�p��	float = 0; --  Top 14 ����{�l
	
	exec [cmn].[spGet�O�p��] @����, @�O�p�� output;

	--SELECT TOP 14 --  Top 14 ����{�l
	--	[StartDate], [����Rate_�I�l], [����Rate_�I�l]
	--FROM [hltc].[tRateHistory_Hour1]
	--where �ʉ݃y�ANo = @�ʉ݃y�ANo and StartDate <= @StartDate
	--order by [StartDate] desc
	declare cursor_tRateHistory_Hour1 cursor for
	SELECT TOP 14 --  Top 14 ����{�l
       [StartDate], [����Rate_�I�l], [����Rate_�I�l]
	FROM [hstr].[tHour1]
	where �ʉ݃y�ANo = @�ʉ݃y�ANo and StartDate <= @StartDate
	order by [StartDate] desc
	
	open cursor_tRateHistory_Hour1;

	declare @���� datetime;
	declare @����_�I�l float = 0;
	declare @����_�I�l float = 0;
	FETCH NEXT FROM cursor_tRateHistory_Hour1 INTO @����, @����_�I�l, @����_�I�l;

	declare @����Cnt int = @����;
	Set @����WMAs14 = 0;
	Set @����WMAs14 = 0;

	WHILE @@FETCH_STATUS = 0
	BEGIN

		Set @����WMAs14 = @����WMAs14 + (@����_�I�l * (@����Cnt / @�O�p��));
		Set @����WMAs14 = @����WMAs14 + (@����_�I�l * (@����Cnt / @�O�p��));

		--select @����Cnt as ����Cnt, @�O�p�� as �O�p��, (@����Cnt / @�O�p��)
		--select (@����_�I�l * (@����Cnt / @�O�p��))
		--select @����, @����_�I�l, @����Cnt, @�O�p��, @WMA

		FETCH NEXT FROM cursor_tRateHistory_Hour1 INTO @����, @����_�I�l, @����_�I�l;
		Set @����Cnt = @����Cnt - 1;
	END

	CLOSE cursor_tRateHistory_Hour1;
	DEALLOCATE cursor_tRateHistory_Hour1;

	--select @�ʉ݃y�ANo, @StartDate, @����WMAs14, @����WMAs14;

END
GO
/*
*/
