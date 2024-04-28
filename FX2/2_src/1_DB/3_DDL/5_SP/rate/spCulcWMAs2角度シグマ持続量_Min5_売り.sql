USE [FX2_Demo]
GO
/*
*/
DROP PROCEDURE [rate].[spCulcWMAs2�p�x�V�O�}������_Min5_����]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [rate].[spCulcWMAs2�p�x�V�O�}������_Min5_����]
	@�ʉ݃y�ANo				tinyint,
	@StartDate				datetime,
	@����Rate_�I�l_Target	float,
	@����WMAs2�p�x_Target	float,
	@�����s��				int		output,
	@Rate��					float	output
AS
BEGIN
	/*
	declare @�ʉ݃y�ANo				tinyint = 34;
	declare @StartDate				datetime = '2015-08-24 07:30:00.000';
	declare @����Rate_�I�l_Target	float = 121.693;
	declare @����WMAs2�p�x_Target	float = -8.69879615470361;
	--declare @StartDate				datetime = '2015-08-24 08:00:00.000';
	--declare @����Rate_�I�l_Target	float = 121.311;
	--declare @����WMAs2�p�x_Target	float = 11.5301303888022;
	declare @�����s��				int;
	declare @Rate��					float;
	*/

	DECLARE @����Rate_�I�l float;
	DECLARE @����WMAs2�p�x float;

	-- ����
	declare cursor_tRateHistory_Min5 cursor for
	SELECT [����Rate_�I�l], [����WMAs2�p�x]
	from [rate].[tRateHistory_Min5]
	where [�ʉ݃y�ANo] = @�ʉ݃y�ANo AND [StartDate] > @StartDate
	order by [StartDate];

	open cursor_tRateHistory_Min5;
	FETCH NEXT FROM cursor_tRateHistory_Min5 INTO @����Rate_�I�l, @����WMAs2�p�x;

	SET @�����s�� = 0;

	WHILE @@FETCH_STATUS = 0
	BEGIN
			
		if @����WMAs2�p�x_Target > 0
		begin
			if @����WMAs2�p�x > 0
			begin
				--WMAs2�p�x�V�O�}������
				SET @�����s�� = @�����s�� + 1;
				SET @Rate�� = @����Rate_�I�l - @����Rate_�I�l_Target;
			end
			else
			begin
				--WMAs2�p�x�V�O�}�����I��
				BREAK;
			end;
		end
		else
		begin
			if @����WMAs2�p�x < 0
			begin
				--WMAs2�p�x�V�O�}������
				SET @�����s�� = @�����s�� + 1;
				SET @Rate�� = @����Rate_�I�l_Target - @����Rate_�I�l;
			end
			else
			begin
				--WMAs2�p�x�V�O�}�����I��
				BREAK;
			end;
		end;


		FETCH NEXT FROM cursor_tRateHistory_Min5 INTO @����Rate_�I�l, @����WMAs2�p�x;
	END

	CLOSE cursor_tRateHistory_Min5;
	DEALLOCATE cursor_tRateHistory_Min5;

	--select @�����s�� as �����s��, @Rate�� as Rate��, @����Rate_�I�l as ����Rate_�I�l, @����WMAs2�p�x as ����WMAs2�p�x;

END
GO
/*
*/
