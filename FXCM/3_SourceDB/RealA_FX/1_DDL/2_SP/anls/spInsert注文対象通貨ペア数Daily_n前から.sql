USE DemoA_FX
GO

DROP PROCEDURE [anls].[spInsert�����Ώےʉ݃y�A��Daily_n�O����]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [anls].[spInsert�����Ώےʉ݃y�A��Daily_n�O����]
	@back_Day1 int = -1
AS
BEGIN
	/*
	DECLARE @back_Day1 int = -1;
	*/

	DECLARE @now						Datetime = GETDATE();
	DECLARE @ThisDate					datetime;
	DECLARE @StartDate					datetime;
	DECLARE @EndDate					datetime;
	DECLARE @Cnt						tinyint;
	DECLARE @�����Ώےʉ݃y�A��_�z��	tinyint;
	DECLARE @�����Ώےʉ݃y�A��_����	tinyint;

	while @back_Day1 < 1
	begin

		EXECUTE [cmn].[spGetThisDay1] @now, @back_Day1, @ThisDate OUTPUT, @StartDate OUTPUT, @EndDate OUTPUT;

		SELECT @�����Ώےʉ݃y�A��_�z�� = count(*)
		from (
			SELECT [�ʉ݃y�ANo]
			FROM [DemoA_FX].[anls].[t�z�蔄���^�C�~���O]
			where [StartDateDay1] = @StartDate
			group by [�ʉ݃y�ANo]
		) as t;

		SELECT @�����Ώےʉ݃y�A��_���� = count(*)
		FROM [oder].[t�����Ώےʉ݃y�ADaily]
		WHERE [StartDate] = @StartDate

		select @Cnt = count(*)
		from [anls].[t�����Ώےʉ݃y�A��Daily]
		where [StartDate] = @StartDate

		if @Cnt < 1
		begin
			INSERT INTO [anls].[t�����Ώےʉ݃y�A��Daily] (
				[StartDate], �����Ώےʉ݃y�A��_�z��, [�����Ώےʉ݃y�A��_����]
			) VALUES (
				@StartDate, @�����Ώےʉ݃y�A��_�z��, @�����Ώےʉ݃y�A��_����
			);
		end
		else
		begin
			UPDATE [anls].[t�����Ώےʉ݃y�A��Daily]
			SET [�����Ώےʉ݃y�A��_�z��] = @�����Ώےʉ݃y�A��_�z��,
				[�����Ώےʉ݃y�A��_����] = @�����Ώےʉ݃y�A��_����
			WHERE [StartDate] = @StartDate;
		end;

		Set @back_Day1 = @back_Day1 + 1;
	end;
END
GO
/*
*/
