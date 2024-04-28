USE OANDA_RealB
GO
/*
*/
DROP PROCEDURE [anls].[spGet�����^�C�~���O�]��]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [anls].[spGet�����^�C�~���O�]��]
	@now		datetime,
	@�]��		varchar(8000)	output
AS
BEGIN

	/*
	DECLARE @now	datetime = '2017/04/21 6:00:00';
	DECLARE @�]��	varchar(8000) = '';
	*/

	DECLARE @�ʉ݃y�ANo tinyint = 0;
	DECLARE @�ʉ݃y�ANoMax tinyint = (SELECT MAX(No) from [cmn].[t�ʉ݃y�AMst]);

	DECLARE @�ʉ݃y�A�� varchar(10) = '';
	DECLARE @����Swap float;
	DECLARE @����Swap float;
	DECLARE @Swap���� varchar(10) = '';
	DECLARE @��Rate���� varchar(10) = '';
	DECLARE @�TRate���� varchar(10) = '';
	DECLARE @��Rate���� varchar(10) = '';
	DECLARE @Hour1Rate�L����	varchar(10) = '';
	DECLARE @Min30Rate�L����	varchar(10) = '';
	DECLARE @Min15Rate�L����	varchar(10) = '';
	DECLARE @Min5Rate�L����	varchar(10) = '';
	DECLARE @Min1Rate�L����	varchar(10) = '';
	DECLARE @Min15BS������	varchar(10) = '';

	DECLARE @back_Month1		int = 0;
	DECLARE @ThisMonth1			Datetime;
	DECLARE @StartDateMonth1	Datetime;
	DECLARE @EndDateMonth1		Datetime;
	EXEC [cmn].[spGetThisMonth1] @now, @back_Month1, @ThisMonth1, @StartDateMonth1, @EndDateMonth1;

	DECLARE @back_Week1		int = 0;
	DECLARE @ThisWeek1		Datetime;
	DECLARE @StartDateWeek1	Datetime;
	DECLARE @EndDateWeek1	Datetime;
	EXEC [cmn].[spGetThisWeek1] @now, @back_Week1, @ThisWeek1, @StartDateWeek1, @EndDateWeek1;

	DECLARE @back_Day1		int = 0;
	DECLARE @ThisDay1		Datetime;
	DECLARE @StartDateDay1	Datetime;
	DECLARE @EndDateDay1	Datetime;
	EXEC [cmn].[spGetThisDay1] @now, @back_Day1, @ThisDay1, @StartDateDay1, @EndDateDay1;

	DECLARE @Cnt tinyint = 0;


	SET @�]�� = '�ʉ݃y�ANo\t�ʉ݃y�A��\tSwap����\t��Rate����\t�TRate����\t��Rate����\r\n';

	-- �c�͒ʉ݃y�A
	while @�ʉ݃y�ANo <= @�ʉ݃y�ANoMax
	begin

		-- �ʉ݃y�A��

		SELECT @�ʉ݃y�A�� = [�y�A��]
		FROM [cmn].[t�ʉ݃y�AMst]
		WHERE [No] = @�ʉ݃y�ANo;


		-- Swap����

		SELECT TOP 1 @����Swap = [����Swap], @����Swap = [����Swap]
		FROM [swap].[tSwap�蓮�o�^_Day1]
		WHERE [�ʉ݃y�ANo] = @�ʉ݃y�ANo
		ORDER BY [StartDate] DESC;

		IF @����Swap = NULL OR @����Swap = NULL
		BEGIN
			SET @�]�� = @�]�� + CONVERT(varchar, @�ʉ݃y�ANo) + '\t' + @�ʉ݃y�A�� + '\t\t\t\r\n';
			SET @�ʉ݃y�ANo = @�ʉ݃y�ANo + 1;
			CONTINUE;
		END;

		IF @����Swap > @����Swap AND @����Swap > 0
		BEGIN
			SET @Swap���� = '����';
		END
		ELSE IF @����Swap > @����Swap AND @����Swap > 0
		BEGIN
			SET @Swap���� = '����';
		END;


		-- ��Rate����

		IF @Swap���� = '����'
		BEGIN

			SELECT @Cnt = count(*)
			FROM [hstr].[tMonth1]
			WHERE �ʉ݃y�ANo = @�ʉ݃y�ANo and [StartDate] = @StartDateMonth1 and 
				[����WMAs2] > [����WMAs14] and [����WMAs2�p�x] > 0;

			IF @Cnt > 0
			BEGIN
				SET @��Rate���� = '����';
			END
			ELSE
			BEGIN
				SET @��Rate���� = '';
			END;

		END
		ELSE IF @Swap���� = '����'
		BEGIN

			SELECT @Cnt = count(*)
			FROM [hstr].[tMonth1]
			WHERE �ʉ݃y�ANo = @�ʉ݃y�ANo and [StartDate] = @StartDateMonth1 and 
				[����WMAs2] < [����WMAs14] and [����WMAs2�p�x] < 0;

			IF @Cnt > 0
			BEGIN
				SET @��Rate���� = '����';
			END
			ELSE
			BEGIN
				SET @��Rate���� = '';
			END;

		END;

		IF @��Rate���� = ''
		BEGIN
			SET @�]�� = @�]�� + CONVERT(varchar, @�ʉ݃y�ANo) + '\t' + @�ʉ݃y�A�� + '\t' + @Swap���� + '\t\t\r\n';
			SET @�ʉ݃y�ANo = @�ʉ݃y�ANo + 1;
			CONTINUE;
		END;


		-- �TRate����

		IF @Swap���� = '����'
		BEGIN

			SELECT @Cnt = count(*)
			FROM [hstr].[tWeek1]
			WHERE �ʉ݃y�ANo = @�ʉ݃y�ANo and [StartDate] = @StartDateWeek1 and 
				[����WMAs2] > [����WMAs14] and [����WMAs2�p�x] > 0;

			IF @Cnt > 0
			BEGIN
				SET @�TRate���� = '����';
			END
			ELSE
			BEGIN
				SET @�TRate���� = '';
			END;

		END
		ELSE IF @Swap���� = '����'
		BEGIN

			SELECT @Cnt = count(*)
			FROM [hstr].[tWeek1]
			WHERE �ʉ݃y�ANo = @�ʉ݃y�ANo and [StartDate] = @StartDateWeek1 and 
				[����WMAs2] < [����WMAs14] and [����WMAs2�p�x] < 0;

			IF @Cnt > 0
			BEGIN
				SET @�TRate���� = '����';
			END
			ELSE
			BEGIN
				SET @�TRate���� = '';
			END;

		END;

		IF @�TRate���� = ''
		BEGIN
			SET @�]�� = @�]�� + CONVERT(varchar, @�ʉ݃y�ANo) + '\t' + @�ʉ݃y�A�� + '\t' + @Swap���� + '\t' + @��Rate���� + '\t\r\n';
			SET @�ʉ݃y�ANo = @�ʉ݃y�ANo + 1;
			CONTINUE;
		END;


		-- ��Rate����

		IF @Swap���� = '����'
		BEGIN

			SELECT @Cnt = count(*)
			FROM [hstr].[tDay1]
			WHERE �ʉ݃y�ANo = @�ʉ݃y�ANo and [StartDate] = @StartDateDay1 and
				[����WMAs2] > [����WMAs14] and [����WMAs2�p�x] > 0;

			IF @Cnt > 0
			BEGIN
				SET @��Rate���� = '����';
			END
			ELSE
			BEGIN
				SET @��Rate���� = '';
			END;

		END
		ELSE IF @Swap���� = '����'
		BEGIN

			SELECT @Cnt = count(*)
			FROM [hstr].[tDay1]
			WHERE �ʉ݃y�ANo = @�ʉ݃y�ANo and [StartDate] = @StartDateDay1 and
				[����WMAs2] < [����WMAs14] and [����WMAs2�p�x] < 0;

			IF @Cnt > 0
			BEGIN
				SET @��Rate���� = '����';
			END
			ELSE
			BEGIN
				SET @��Rate���� = '';
			END;

		END;

		IF @��Rate���� = ''
		BEGIN
			SET @�]�� = @�]�� + CONVERT(varchar, @�ʉ݃y�ANo) + '\t' + @�ʉ݃y�A�� + '\t' + @Swap���� + '\t' + @��Rate���� + '\t' + @�TRate���� + '\r\n';
			SET @�ʉ݃y�ANo = @�ʉ݃y�ANo + 1;
			CONTINUE;
		END;


		-- Hour1Rate����

		IF @Swap���� = '����'
		BEGIN

			SELECT @Cnt = count(*)
			FROM [hstr].[tHour1]
			WHERE �ʉ݃y�ANo = @�ʉ݃y�ANo and @StartDateDay1 <= [StartDate] and [StartDate] < @StartDateDay1 and
				[����WMAs2] > [����WMAs14] and [����WMAs2�p�x] > 0;

			SET @Hour1Rate�L���� = '����(' + CONVERT(varchar, @Cnt) + ')';

		END
		ELSE IF @Swap���� = '����'
		BEGIN

			SELECT @Cnt = count(*)
			FROM [hstr].[tHour1]
			WHERE �ʉ݃y�ANo = @�ʉ݃y�ANo and @StartDateDay1 <= [StartDate] and [StartDate] < @StartDateDay1 and
				[����WMAs2] < [����WMAs14] and [����WMAs2�p�x] < 0;

			SET @Hour1Rate�L���� = '����(' + CONVERT(varchar, @Cnt) + ')';

		END;


		-- Min15Rate����

		IF @Swap���� = '����'
		BEGIN

			SELECT @Cnt = count(*)
			FROM [hstr].[tMin15]
			WHERE �ʉ݃y�ANo = @�ʉ݃y�ANo and @StartDateDay1 <= [StartDate] and [StartDate] < @EndDateDay1 and
				[����WMAs2] > [����WMAs14] and [����WMAs2�p�x] > 0;

			SET @Min15Rate�L���� = '����(' + CONVERT(varchar, @Cnt) + ')';

		END
		ELSE IF @Swap���� = '����'
		BEGIN

			SELECT @Cnt = count(*)
			FROM [hstr].[tMin15]
			WHERE �ʉ݃y�ANo = @�ʉ݃y�ANo and @StartDateDay1 <= [StartDate] and [StartDate] < @EndDateDay1 and
				[����WMAs2] < [����WMAs14] and [����WMAs2�p�x] < 0;

			SET @Min15Rate�L���� = '����(' + CONVERT(varchar, @Cnt) + ')';

		END;


		-- Min5Rate����

		IF @Swap���� = '����'
		BEGIN

			SELECT @Cnt = count(*)
			FROM [hstr].[tMin5]
			WHERE �ʉ݃y�ANo = @�ʉ݃y�ANo and @StartDateDay1 <= [StartDate] and [StartDate] < @EndDateDay1 and
				[����WMAs2] > [����WMAs14] and [����WMAs2�p�x] > 0;

			SET @Min5Rate�L���� = '����(' + CONVERT(varchar, @Cnt) + ')';

		END
		ELSE IF @Swap���� = '����'
		BEGIN

			SELECT @Cnt = count(*)
			FROM [hstr].[tMin5]
			WHERE �ʉ݃y�ANo = @�ʉ݃y�ANo and @StartDateDay1 <= [StartDate] and [StartDate] < @EndDateDay1 and
				[����WMAs2] < [����WMAs14] and [����WMAs2�p�x] < 0;

			SET @Min5Rate�L���� = '����(' + CONVERT(varchar, @Cnt) + ')';

		END;


		-- Min1Rate����

		IF @Swap���� = '����'
		BEGIN

			SELECT @Cnt = count(*)
			FROM [hstr].[tMin1]
			WHERE �ʉ݃y�ANo = @�ʉ݃y�ANo and @StartDateDay1 <= [StartDate] and [StartDate] < @EndDateDay1 and
				[����WMAs2] > [����WMAs14] and [����WMAs2�p�x] > 0;

			SET @Min1Rate�L���� = '����(' + CONVERT(varchar, @Cnt) + ')';

		END
		ELSE IF @Swap���� = '����'
		BEGIN

			SELECT @Cnt = count(*)
			FROM [hstr].[tMin1]
			WHERE �ʉ݃y�ANo = @�ʉ݃y�ANo and @StartDateDay1 <= [StartDate] and [StartDate] < @EndDateDay1 and
				[����WMAs2] < [����WMAs14] and [����WMAs2�p�x] < 0;

			SET @Min1Rate�L���� = '����(' + CONVERT(varchar, @Cnt) + ')';

		END;


		-- Min15BS������

		SELECT @Cnt = count(*)
		FROM [hstr].[tBonusStage]
		WHERE �ʉ݃y�ANo = @�ʉ݃y�ANo and @StartDateDay1 <= [����] and [����] < @EndDateDay1 and
			[BS����_�O] = 'B';

		SET @Min15BS������ = 'BS(' + CONVERT(varchar, @Cnt) + ')';


		-- 1�s�̌���

		SET @�]�� = @�]�� + 
			CONVERT(varchar, @�ʉ݃y�ANo) + '\t' + @�ʉ݃y�A�� + '\t' + @Swap���� + '\t' + 
			@��Rate���� + '\t' + @�TRate���� + '\t' + @��Rate���� + '\t' + 
			@Hour1Rate�L���� + '\t' + @Min30Rate�L���� + '\t' + @Min15Rate�L���� + '\t' + 
			@Min15BS������ + '\t' + 
			@Min5Rate�L���� + '\t' + @Min1Rate�L���� + 
			'\r\n';

		SET @�ʉ݃y�ANo = @�ʉ݃y�ANo + 1;
	end;

	--select @�]��
END
GO
/*
*/

