USE OANDA_RealA
GO

DROP PROCEDURE [anls].[spInsert�z�蔄���^�C�~���O_���g���[�h�Ɣ�r]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [anls].[spInsert�z�蔄���^�C�~���O_���g���[�h�Ɣ�r]
	@StartDate_Month1	datetime
AS
BEGIN

	DECLARE cursor_�z�蔄���^�C�~���O cursor for
	SELECT  [�ʉ݃y�ANo], [��������], [StartDateMin1], [StartDateMin5], [StartDateMin15], [StartDateHour1], [StartDateDay1]
	FROM [anls].[t�z�蔄���^�C�~���O]
	WHERE [StartDateMonth1] = @StartDate_Month1;

	OPEN cursor_�z�蔄���^�C�~���O;

	DECLARE @�ʉ݃y�ANo			tinyint;
	DECLARE @��������			bit;
	DECLARE @StartDateMin1		datetime;
	DECLARE @StartDateMin5		datetime;
	DECLARE @StartDateMin15		datetime;
	DECLARE @StartDateHour1		datetime;
	DECLARE @StartDateDay1		datetime;
	FETCH NEXT FROM cursor_�z�蔄���^�C�~���O INTO @�ʉ݃y�ANo, @��������, @StartDateMin1, @StartDateMin5, @StartDateMin15, @StartDateHour1, @StartDateDay1;

	WHILE @@FETCH_STATUS = 0
	BEGIN

		DECLARE @��r���� varchar(8000);


		-- �z��^�C�~���O���߂ɒ����L��

		DECLARE @Cnt int;
		SELECT @Cnt = COUNT(*)
		FROM [oder].[tOrderHistory2]
		WHERE [�ʉ݃y�ANo] = @�ʉ݃y�ANo AND [����] = @�������� AND @StartDateDay1 <= [����] AND [����] < DATEADD(DAY, 1, @StartDateDay1)

		IF @Cnt > 0
		BEGIN
			SET @��r���� = '1���ȓ��ɒ����L��B';
		END ELSE BEGIN
			SET @��r���� = '1���ȓ��ɒ��������B';
		END;

		SELECT @Cnt = COUNT(*)
		FROM [oder].[tOrderHistory2]
		WHERE [�ʉ݃y�ANo] = @�ʉ݃y�ANo AND [����] = @�������� AND @StartDateHour1 <= [����] AND [����] < DATEADD(HOUR, 1, @StartDateHour1)

		IF @Cnt > 0
		BEGIN
			SET @��r���� = '1���Ԉȓ��ɒ����L��B';
		END ELSE BEGIN
			SET @��r���� = '1���Ԉȓ��ɒ��������B';
		END;


		-- �z��^�C�~���O���߂̃��O

		DECLARE cursor_ExecLog cursor for
		SELECT  [�����]
		FROM [pfmc].[tExecLog]
		WHERE [�ʉ݃y�ANo] = @�ʉ݃y�ANo AND @StartDateMin1 <= [ExecDate] AND [ExecDate] < @StartDateMin1;

		OPEN cursor_ExecLog;

		DECLARE @����� varchar(100);
		FETCH NEXT FROM cursor_ExecLog INTO @�����;

		WHILE @@FETCH_STATUS = 0
		BEGIN
			SET @��r���� = @��r���� + @����� + '�B';

			FETCH NEXT FROM cursor_ExecLog INTO @�����;
		END

		CLOSE cursor_ExecLog;
		DEALLOCATE cursor_ExecLog;


		-- ��r���ʂ�Write

		UPDATE [anls].[t�z�蔄���^�C�~���O]
		SET [��r����] = @��r����,
			[�X�V����] = getdate()
		WHERE @�ʉ݃y�ANo = [�ʉ݃y�ANo] AND @�������� = [��������] AND @StartDateMin1 = [StartDateMin1];

		FETCH NEXT FROM cursor_�z�蔄���^�C�~���O INTO @�ʉ݃y�ANo, @��������, @StartDateMin1, @StartDateMin5, @StartDateMin15, @StartDateHour1, @StartDateDay1;
	END

	CLOSE cursor_�z�蔄���^�C�~���O;
	DEALLOCATE cursor_�z�蔄���^�C�~���O;


END
GO

