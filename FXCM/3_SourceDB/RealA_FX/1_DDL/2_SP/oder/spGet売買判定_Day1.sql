USE DemoA_FX
GO
/*
*/
DROP PROCEDURE [oder].[spGet��������_Day1]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [oder].[spGet��������_Day1]
	@�ʉ݃y�ANo		tinyint,
	@StartDate		datetime,
	@����WMAs2		float		output,
	@����WMAs14		float		output,
	@����WMAs2		float		output,
	@����WMAs14		float		output,
	@��������		varchar(10)	output		-- �� or ��
AS
BEGIN
	/*
	DECLARE @�ʉ݃y�ANo		tinyint = 21
	DECLARE @StartDate		datetime = getdate()
	DECLARE @�V�O�}臒l		float = 2.5
	DECLARE @WMA����		varchar(5)
	DECLARE @BonusStage����	varchar(5)
	DECLARE @WMA�O_S2		float = 2.5
	DECLARE @WMA��_S2		float = 2.5
	*/

	SELECT TOP 1 @����WMAs2 = [����WMAs2], @����WMAs14 = [����WMAs14], @����WMAs2 = [����WMAs2], @����WMAs14 = [����WMAs14]
	FROM [hstr].[tDay1]
	where �ʉ݃y�ANo = @�ʉ݃y�ANo and [StartDate] <= @StartDate
	order by [StartDate] desc;

	-- GC�t����

	if @����WMAs14 < @����WMAs2
	begin
		SET @�������� = '��';
	end
	else if @����WMAs14 > @����WMAs2
	begin
		SET @�������� = '��';
	end
	else
	begin
		SET @�������� = '';
	end;


END
GO
/*
*/

