USE OANDA_RealA
GO

DROP PROCEDURE [anls].[spInsert�z�蔄���^�C�~���O_�����^�C�~���O�𒊏o]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [anls].[spInsert�z�蔄���^�C�~���O_�����^�C�~���O�𒊏o]
	@StartDate_Month1	datetime
AS
BEGIN

	DECLARE @�ʉ݃y�ANo tinyint = 0;
	DECLARE @�ʉ݃y�ANoMax tinyint = (SELECT MAX(No) from [cmn].[t�ʉ݃y�AMst]);

	while @�ʉ݃y�ANo <= @�ʉ݃y�ANoMax
	begin

		declare cursor_Month1 cursor for
		SELECT  [StartDate]
		FROM [hstr].[tMonth1]
		where �ʉ݃y�ANo = @�ʉ݃y�ANo 
			and [����Swap] > [����Swap] and [����Swap] > 0 and [����WMAs2] > [����WMAs14] and [����WMAs2�p�x] > 0
			and [StartDate] = @StartDate_Month1;

		open cursor_Month1;

		declare @Month1_StartDate datetime;
		FETCH NEXT FROM cursor_Month1 INTO @Month1_StartDate;

		WHILE @@FETCH_STATUS = 0
		BEGIN
			declare cursor_Week1 cursor for
			SELECT  [StartDate]
			FROM [hstr].[tWeek1]
			where �ʉ݃y�ANo = @�ʉ݃y�ANo 
				and [����Swap] > [����Swap] and [����Swap] > 0 and [����WMAs2] > [����WMAs14] and [����WMAs2�p�x] > 0
				and @Month1_StartDate <= [StartDate] and [StartDate] <DATEADD(MONTH, 1, @Month1_StartDate)

			open cursor_Week1;

			declare @Week1_StartDate datetime;
			FETCH NEXT FROM cursor_Week1 INTO @Week1_StartDate;

			WHILE @@FETCH_STATUS = 0
			BEGIN
				declare cursor_Day1 cursor for
				SELECT  [StartDate]
				FROM [hstr].[tDay1]
				where �ʉ݃y�ANo = @�ʉ݃y�ANo 
					and [����Swap] > [����Swap] and [����Swap] > 0 and [����WMAs2] > [����WMAs14] and [����WMAs2�p�x] > 0
					and @Week1_StartDate <= [StartDate] and [StartDate] <DATEADD(WEEK, 1, @Week1_StartDate)

				open cursor_Day1;

				declare @Day1_StartDate datetime;
				FETCH NEXT FROM cursor_Day1 INTO @Day1_StartDate;

				WHILE @@FETCH_STATUS = 0
				BEGIN
					declare cursor_Hour1 cursor for
					SELECT  [StartDate]
					FROM [hstr].[tHour1]
					where �ʉ݃y�ANo = @�ʉ݃y�ANo 
						and [����Swap] > [����Swap] and [����Swap] > 0 and [����WMAs2] > [����WMAs14] and [����WMAs2�p�x] > 0
						and @Day1_StartDate <= [StartDate] and [StartDate] <DATEADD(DAY, 1, @Day1_StartDate)

					open cursor_Hour1;

					declare @Hour1_StartDate datetime;
					FETCH NEXT FROM cursor_Hour1 INTO @Hour1_StartDate;

					WHILE @@FETCH_STATUS = 0
					BEGIN
						declare cursor_Min15 cursor for
						SELECT  [StartDate]
						FROM [hstr].[tMin15]
						where �ʉ݃y�ANo = @�ʉ݃y�ANo 
							and [����Swap] > [����Swap] and [����Swap] > 0 and [����WMAs2] > [����WMAs14] and [����WMAs2�p�x] > 0
							and @Hour1_StartDate <= [StartDate] and [StartDate] <DATEADD(HOUR, 1, @Hour1_StartDate)

						open cursor_Min15;

						declare @Min15_StartDate datetime;
						FETCH NEXT FROM cursor_Min15 INTO @Min15_StartDate;

						WHILE @@FETCH_STATUS = 0
						BEGIN
							declare cursor_Min5 cursor for
							SELECT  [StartDate]
							FROM [hstr].[tMin5]
							where �ʉ݃y�ANo = @�ʉ݃y�ANo 
								and [����Swap] > [����Swap] and [����Swap] > 0 and [����WMAs2] > [����WMAs14] and [����WMAs2�p�x] > 0
								and @Min15_StartDate <= [StartDate] and [StartDate] <DATEADD(MINUTE, 5, @Min15_StartDate)

							open cursor_Min5;

							declare @Min5_StartDate datetime;
							FETCH NEXT FROM cursor_Min5 INTO @Min5_StartDate;

							WHILE @@FETCH_STATUS = 0
							BEGIN
								declare cursor_Min1 cursor for
								SELECT  [StartDate], [����Swap], [����Swap]
								FROM [hstr].[tMin1]
								where �ʉ݃y�ANo = @�ʉ݃y�ANo 
									and [����Swap] > [����Swap] and [����Swap] > 0 and [����WMAs2] > [����WMAs14] and [����WMAs2�p�x] > 0
									and @Min5_StartDate <= [StartDate] and [StartDate] <DATEADD(MINUTE, 5, @Min5_StartDate)

								open cursor_Min1;

								declare @Min1_StartDate datetime;
								declare @Min1_����Swap float;
								declare @Min1_����Swap float;
								FETCH NEXT FROM cursor_Min1 INTO @Min1_StartDate, @Min1_����Swap, @Min1_����Swap;

								WHILE @@FETCH_STATUS = 0
								BEGIN
								
									DELETE FROM [anls].[t�z�蔄���^�C�~���O]
									WHERE [�ʉ݃y�ANo]=@�ʉ݃y�ANo AND [��������]='B' AND [StartDateMin1]=@Min1_StartDate

									INSERT INTO [anls].[t�z�蔄���^�C�~���O]
										([�ʉ݃y�ANo]
										,[��������]
										,[����Swap]
										,[����Swap]
										,[StartDateMin1]
										,[StartDateMin5]
										,[StartDateMin15]
										,[StartDateHour1]
										,[StartDateDay1]
										,[StartDateWeek1]
										,[StartDateMonth1]
										,[�o�^����])
									VALUES
										(@�ʉ݃y�ANo,
										'B',	-- ����
										@Min1_����Swap,
										@Min1_����Swap,
										@Min1_StartDate,
										@Min5_StartDate,
										@Min15_StartDate,
										@Hour1_StartDate,
										@Day1_StartDate,
										@Week1_StartDate,
										@Month1_StartDate,
										getdate());

									FETCH NEXT FROM cursor_Min1 INTO @Min1_StartDate, @Min1_����Swap, @Min1_����Swap;
								END

								CLOSE cursor_Min1;
								DEALLOCATE cursor_Min1;

								FETCH NEXT FROM cursor_Min5 INTO @Min5_StartDate;
							END

							CLOSE cursor_Min5;
							DEALLOCATE cursor_Min5;

							FETCH NEXT FROM cursor_Min15 INTO @Min15_StartDate;
						END

						CLOSE cursor_Min15;
						DEALLOCATE cursor_Min15;

						FETCH NEXT FROM cursor_Hour1 INTO @Hour1_StartDate;
					END

					CLOSE cursor_Hour1;
					DEALLOCATE cursor_Hour1;

					FETCH NEXT FROM cursor_Day1 INTO @Day1_StartDate;
				END

				CLOSE cursor_Day1;
				DEALLOCATE cursor_Day1;

				FETCH NEXT FROM cursor_Week1 INTO @Week1_StartDate;
			END

			CLOSE cursor_Week1;
			DEALLOCATE cursor_Week1;


			FETCH NEXT FROM cursor_Month1 INTO @Month1_StartDate;
		END

		CLOSE cursor_Month1;
		DEALLOCATE cursor_Month1;

		Set @�ʉ݃y�ANo = @�ʉ݃y�ANo + 1;
	end;

END
GO

