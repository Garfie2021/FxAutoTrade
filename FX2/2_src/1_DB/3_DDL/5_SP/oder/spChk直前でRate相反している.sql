USE [FX2_DemoA]
GO

DROP PROCEDURE [oder].[spChk���O��Rate�������Ă���]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [oder].[spChk���O��Rate�������Ă���]
	@�ʉ݃y�ANo		tinyint,
	@��������		tinyint,		-- 0�F����@1�F����
	@����			tinyint	output	-- 0�F�������Ă���@1�F�������Ă��Ȃ�
AS
BEGIN
	/*
	DECLARE @�ʉ݃y�ANo		tinyint = 29
	DECLARE @�������[�h		varchar = '����'
	DECLARE @����			tinyint
	*/

	DECLARE @��_Rate_���� float;
	DECLARE @��_Rate_���� float;
	DECLARE @1�O_Rate_���� float;
	DECLARE @1�O_Rate_���� float;

	DECLARE cursor_T_RateHistory CURSOR FOR
	SELECT TOP 2 [����Rate], [����Rate]
	FROM [rate].[tRateHistory]
	where �ʉ݃y�ANo = @�ʉ݃y�ANo
	order by [StartDate] desc

	open cursor_T_RateHistory;
	
	FETCH NEXT FROM cursor_T_RateHistory INTO @��_Rate_����, @��_Rate_����;
	FETCH NEXT FROM cursor_T_RateHistory INTO @1�O_Rate_����, @1�O_Rate_����;

	CLOSE cursor_T_RateHistory;
	DEALLOCATE cursor_T_RateHistory;

	if @�������� = 1
	begin
		--����
		if @1�O_Rate_���� > @��_Rate_����
		begin
			Set @���� = 0;	-- Order���o���̂͊댯
		end
		else
		begin
			Set @���� = 1;	-- Order���o���Ă����v
		end
	end
	else
	begin
		--����
		if @1�O_Rate_���� < @��_Rate_����
		begin
			Set @���� = 0;	-- Order���o���̂͊댯
		end
		else
		begin
			Set @���� = 1;	-- Order���o���Ă����v
		end
	end

	--select @����

END
GO
/*
*/

