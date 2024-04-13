USE [FX2_Demo]
GO
/*
*/
DROP PROCEDURE [rate].[spCulcWMAs2pxVO}±Κ_Min5_θ]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [rate].[spCulcWMAs2pxVO}±Κ_Min5_θ]
	@ΚέyANo				tinyint,
	@StartDate				datetime,
	@θRate_Il_Target	float,
	@θWMAs2px_Target	float,
	@±s				int		output,
	@Rate·					float	output
AS
BEGIN
	/*
	declare @ΚέyANo				tinyint = 34;
	declare @StartDate				datetime = '2015-08-24 07:30:00.000';
	declare @θRate_Il_Target	float = 121.693;
	declare @θWMAs2px_Target	float = -8.69879615470361;
	--declare @StartDate				datetime = '2015-08-24 08:00:00.000';
	--declare @θRate_Il_Target	float = 121.311;
	--declare @θWMAs2px_Target	float = 11.5301303888022;
	declare @±s				int;
	declare @Rate·					float;
	*/

	DECLARE @θRate_Il float;
	DECLARE @θWMAs2px float;

	-- θ
	declare cursor_tRateHistory_Min5 cursor for
	SELECT [θRate_Il], [θWMAs2px]
	from [rate].[tRateHistory_Min5]
	where [ΚέyANo] = @ΚέyANo AND [StartDate] > @StartDate
	order by [StartDate];

	open cursor_tRateHistory_Min5;
	FETCH NEXT FROM cursor_tRateHistory_Min5 INTO @θRate_Il, @θWMAs2px;

	SET @±s = 0;

	WHILE @@FETCH_STATUS = 0
	BEGIN
			
		if @θWMAs2px_Target > 0
		begin
			if @θWMAs2px > 0
			begin
				--WMAs2pxVO}±
				SET @±s = @±s + 1;
				SET @Rate· = @θRate_Il - @θRate_Il_Target;
			end
			else
			begin
				--WMAs2pxVO}±IΉ
				BREAK;
			end;
		end
		else
		begin
			if @θWMAs2px < 0
			begin
				--WMAs2pxVO}±
				SET @±s = @±s + 1;
				SET @Rate· = @θRate_Il_Target - @θRate_Il;
			end
			else
			begin
				--WMAs2pxVO}±IΉ
				BREAK;
			end;
		end;


		FETCH NEXT FROM cursor_tRateHistory_Min5 INTO @θRate_Il, @θWMAs2px;
	END

	CLOSE cursor_tRateHistory_Min5;
	DEALLOCATE cursor_tRateHistory_Min5;

	--select @±s as ±s, @Rate· as Rate·, @θRate_Il as θRate_Il, @θWMAs2px as θWMAs2px;

END
GO
/*
*/
