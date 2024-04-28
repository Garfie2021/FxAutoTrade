USE OANDA_RealA
GO
/*
*/
DROP PROCEDURE [pfmc].[spChk�o���ς�]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [pfmc].[spChk�o���ς�]
	@now				datetime,
	@���݂̎���؋���	int,
	@�挎���v			int,
	@�o���σt���O		tinyint	output
AS
BEGIN
	/*
	DECLARE @now datetime = '2014/05/01 3:12:32';
	DECLARE @���݂̎���؋���	int = 9326056;
	DECLARE @�挎���v			int = -18358;
	DECLARE @�o���σt���O	tinyint;
	*/

	Set @now = DATEADD(month, -1, @now);
	DECLARE @�挎 date = convert(varchar, YEAR(@now)) + '/' + convert(varchar, MONTH(@now)) + '/01';

	select @�o���σt���O = [�o���σt���O]
	from pfmc.t���vMonthly
	WHERE [�N��] = @�挎

	if @�o���σt���O = 1
	begin
		--�o���ς�
		return;
	end;

	-- ���݂͏o���ς݁H
	-- 1���ԑO�̏؋����ƁA���݂̏؋������r���āA�����������Ƃ��\�z�������Ă�����A�o�����ꂽ�ƌ��Ȃ��A�o���ς݃t���O��1�ɂ���

	DECLARE @1���ԑO�̎���؋���	int;
	SELECT TOP 1
		@1���ԑO�̎���؋��� = [Balance]
	FROM
		fxcm.tAccounts
	WHERE
		���� < DATEADD(HOUR, -1, @now)
	ORDER BY
		���� DESC

	if @1���ԑO�̎���؋��� is NULL
	begin
		--���o��
		Set @�o���σt���O = 0;
		return;
	end;

	if @1���ԑO�̎���؋��� > (@���݂̎���؋��� - (@�挎���v - @�挎���v * 0.1))
	begin
		--�o���ς�
		UPDATE pfmc.t���vMonthly
		SET [�o���σt���O] = 1,
			[�o�����莞_1���ԑO�̎���؋���] = @1���ԑO�̎���؋���,
			[�o�����莞_���݂̎���؋���] = @���݂̎���؋���,
			[�o�����莞_�挎���v] = @�挎���v
		WHERE [�N��] = @�挎
					
		--�o���ς݁A�]������瓖���o���\�z�����炷�̂͂�߂�
		Set @�o���σt���O = 1;
		return;
	end
	else
	begin
		--���o��
		Set @�o���σt���O = 0;
		return;
	end

END
GO
/*
*/

