USE DemoA_FX
GO

DROP PROCEDURE [oder].[spInsert�����Ώےʉ݃y�ADaily]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [oder].[spInsert�����Ώےʉ݃y�ADaily]
	@StartDate	datetime,
	@�ʉ݃y�ANo	tinyint
AS
BEGIN
	/*
	DECLARE @StartDate datetime = '2016/05/02 6:00:00'
	DECLARE @�ʉ݃y�ANo tinyint = 10
	*/

	DECLARE @�ʉ݃y�ANo��	tinyint;

	select @�ʉ݃y�ANo�� = count(*)
	from [oder].[t�����Ώےʉ݃y�ADaily]
	where [StartDate] = @StartDate and �ʉ݃y�ANo = @�ʉ݃y�ANo;

	if @�ʉ݃y�ANo�� < 1
	begin
		INSERT INTO [oder].[t�����Ώےʉ݃y�ADaily] ([StartDate], [�ʉ݃y�ANo])
		VALUES (@StartDate, @�ʉ݃y�ANo);
	end;

END
GO
/*
*/

