USE OANDA_RealA
GO
/*
*/
DROP PROCEDURE [oder].[spGet��������2_Day1]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [oder].[spGet��������2_Day1]
	@�ʉ݃y�ANo		tinyint,
	@StartDate		datetime,
	@����WMAs2		float		output,
	@����WMAs14		float		output,
	@����WMAs2		float		output,
	@����WMAs14		float		output,
	@��������		varchar(1)	output		-- B(����) or S(����)
AS
BEGIN
	/*
	DECLARE @�ʉ݃y�ANo		tinyint = 0;
	DECLARE @StartDate		datetime = getdate();
	DECLARE @����WMAs2		float;
	DECLARE @����WMAs14		float;
	DECLARE @����WMAs2		float;
	DECLARE @����WMAs14		float;
	DECLARE @��������		varchar(1);

	select @StartDate;
	*/

	SELECT TOP 1 @����WMAs2 = [����WMAs2], @����WMAs14 = [����WMAs14], @����WMAs2 = [����WMAs2], @����WMAs14 = [����WMAs14]
	FROM [hstr].[tDay1]
	where �ʉ݃y�ANo = @�ʉ݃y�ANo and [StartDate] <= @StartDate
	order by [StartDate] desc;

	--select @����WMAs2, @����WMAs14, @����WMAs2, @����WMAs14;

	-- GC�t����

	if @����WMAs14 < @����WMAs2
	begin
		SET @�������� = 'B';
	end
	else if @����WMAs14 > @����WMAs2
	begin
		SET @�������� = 'S';
	end
	else
	begin
		SET @�������� = '';
	end;

	--select @��������;
END
GO
/*
*/

