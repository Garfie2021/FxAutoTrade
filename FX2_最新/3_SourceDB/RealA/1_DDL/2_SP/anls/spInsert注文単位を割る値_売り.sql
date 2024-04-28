USE OANDA_DemoB
GO
/*
*/
DROP PROCEDURE [anls].[spInsert�����P�ʂ�����l_����]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [anls].[spInsert�����P�ʂ�����l_����]
AS
BEGIN

	-- �萔
	-- 10�`1000�̊ԂŒ����P�ʂ�����B�댯��Rate��ł͒����P�ʂ��ő�1000�Ŋ���B
	DECLARE @�����P�ʂ�����l_�ő� int;
	DECLARE @�����P�ʂ�����l_�ŏ� int;
	DECLARE @YearDiff smallint = 0;

	SELECT @�����P�ʂ�����l_�ő� = [�l] FROM [cmn].[t���ݒ�] WHERE [No] = 1;	-- spInsert�����P�ʂ�����l_����  @�����P�ʂ�����l_�ő�


	DELETE FROM [anls].[t�����P�ʂ�����l]
	WHERE [����] = 0;


	DECLARE @�ʉ݃y�ANo tinyint = 0;
	DECLARE @�ʉ݃y�ANoMax tinyint = (SELECT MAX(No) from [cmn].[t�ʉ݃y�AMst]);

	while @�ʉ݃y�ANo <= @�ʉ݃y�ANoMax
	begin

		DECLARE @Rate_Center1 float = 0;
		DECLARE @Rate_Center2 float = 0;
		DECLARE @RowCnt int = 0;

		SELECT @�����P�ʂ�����l_�ŏ� = [�l] FROM [cmn].[t���ݒ�] WHERE [No] = 2;	-- spInsert�����P�ʂ�����l_����  @�����P�ʂ�����l_�ŏ�

		SELECT @YearDiff = DATEDIFF(year, MIN([StartDate]), MAX([StartDate]))
		FROM [hstr].[tMonth1]
		where [�ʉ݃y�ANo] = @�ʉ݃y�ANo

		IF @YearDiff < 2
		BEGIN
			-- 2�N�����͍Œ�400�Ŋ���B
			SET @�����P�ʂ�����l_�ŏ� = 400;
		END
		ELSE IF @YearDiff < 3
		BEGIN
			-- 3�N�����͍Œ�300�Ŋ���B
			SET @�����P�ʂ�����l_�ŏ� = 300;
		END
		ELSE IF @YearDiff < 4
		BEGIN
			-- 4�N�����͍Œ�200�Ŋ���B
			SET @�����P�ʂ�����l_�ŏ� = 200;
		END;

		DECLARE @Cnt int = 0;
		SELECT @CNT = COUNT(*)
		FROM [anls].[t�f���^Rate]
		WHERE [�ʉ݃y�ANo] = @�ʉ݃y�ANo AND [����] = 0;

		IF @Cnt < 1
		BEGIN
			Set @�ʉ݃y�ANo = @�ʉ݃y�ANo + 1;
			CONTINUE;
		END;

		--print @�ʉ݃y�ANo;
		--print @�����P�ʂ�����l_�ő�;
		--print @�����P�ʂ�����l_�ŏ�;
		--print @CNT;

		DECLARE @OneTime int = (@�����P�ʂ�����l_�ő� - @�����P�ʂ�����l_�ŏ�) / @CNT;

		declare cursor_�f���^Rate cursor for
		SELECT [Rate_Center]
		FROM [anls].[t�f���^Rate]
		WHERE [�ʉ݃y�ANo] = @�ʉ݃y�ANo AND [����] = 0
		ORDER BY [Rate_Center] DESC;

		open cursor_�f���^Rate;

		DECLARE @Rate_Center float;
		FETCH NEXT FROM cursor_�f���^Rate INTO @Rate_Center;

		SET @Rate_Center1 = @Rate_Center * 2;
		
		WHILE @@FETCH_STATUS = 0
		BEGIN
			
			SET @Rate_Center2 = @Rate_Center1;
			SET @Rate_Center1 = @Rate_Center;

			--IF @Rate_Center1 = 0 OR @Rate_Center2 = 0
			--BEGIN
			--	--SELECT '1';
			--	FETCH NEXT FROM cursor_�f���^Rate INTO @Rate_Center;
			--	CONTINUE;
			--END;

			IF @Rate_Center1 = @Rate_Center2
			BEGIN
				--SELECT '2';
				FETCH NEXT FROM cursor_�f���^Rate INTO @Rate_Center;
				CONTINUE;
			END;

			INSERT INTO [anls].[t�����P�ʂ�����l] (
				[�ʉ݃y�ANo],
				[����],
				[Rate_High],
				[Rate_Low],
				[�����P�ʂ�����l],
				[�o�^����]
			) VALUES (
				@�ʉ݃y�ANo,
				0,
				@Rate_Center2,
				@Rate_Center1,
				@�����P�ʂ�����l_�ŏ� + (@OneTime * @RowCnt),
				GETDATE()
			);

			SET @RowCnt = @RowCnt +1;
			FETCH NEXT FROM cursor_�f���^Rate INTO @Rate_Center;
		END

		CLOSE cursor_�f���^Rate;
		DEALLOCATE cursor_�f���^Rate;

		INSERT INTO [anls].[t�����P�ʂ�����l] (
			[�ʉ݃y�ANo],
			[����],
			[Rate_High],
			[Rate_Low],
			[�����P�ʂ�����l],
			[�o�^����]
		) VALUES (
			@�ʉ݃y�ANo,
			0,
			@Rate_Center1,
			@Rate_Center1 - (@Rate_Center1 * 0.1), --�ō��l��-10%�܂ł͒����Ώۂɂ��Ƃ�
			@�����P�ʂ�����l_�ő�,
			GETDATE()
		);

		Set @�ʉ݃y�ANo = @�ʉ݃y�ANo + 1;
	end;

END
GO
/*
*/
