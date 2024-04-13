USE OANDA_DemoB
GO
/*
*/
DROP PROCEDURE [anls].[spInsertf^^C~O_’]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [anls].[spInsertf^^C~O_’]
AS
BEGIN

	DELETE FROM [anls].[tf^Rate]
	WHERE [] = '1';


	DECLARE @ΚέyANo tinyint = 0;
	DECLARE @ΚέyANoMax tinyint = (SELECT MAX(No) from [cmn].[tΚέyAMst]);

	DECLARE @5YearBackDate DateTime = DATEADD(year, -5, GETDATE());
	

	while @ΚέyANo <= @ΚέyANoMax
	begin

		DECLARE @StartDate1 datetime = null;
		DECLARE @StartDate2 datetime = null;
		DECLARE @StartDate3 datetime = null;
		DECLARE @’Rate_l1 float = null;
		DECLARE @’Rate_l2 float = null;
		DECLARE @’Rate_l3 float = null;

		declare cursor_Month1 cursor for
		SELECT  [StartDate], ’Rate_l
		FROM [hstr].[tMonth1]
		where ΚέyANo = @ΚέyANo AND [StartDate] > @5YearBackDate
		ORDER BY [StartDate];

		open cursor_Month1;

		DECLARE @StartDate datetime;
		DECLARE @’Rate_l float;
		FETCH NEXT FROM cursor_Month1 INTO @StartDate, @’Rate_l;

		WHILE @@FETCH_STATUS = 0
		BEGIN
			
			--SELECT @ΚέyANo as ΚέyANo, @StartDate as StartDate, @’Rate_l as ’Rate_l;

			SET @StartDate1 = @StartDate2;
			SET @StartDate2 = @StartDate3;
			SET @StartDate3 = @StartDate;

			SET @’Rate_l1 = @’Rate_l2;
			SET @’Rate_l2 = @’Rate_l3;
			SET @’Rate_l3 = @’Rate_l;

			IF @’Rate_l1 IS NULL OR @’Rate_l2 IS NULL OR @’Rate_l3 IS NULL
			BEGIN
				--SELECT '1';
				FETCH NEXT FROM cursor_Month1 INTO @StartDate, @’Rate_l;
				CONTINUE;
			END;

			IF @’Rate_l1 >= @’Rate_l2 OR @’Rate_l2 <= @’Rate_l3
			BEGIN
				--SELECT '2';
				FETCH NEXT FROM cursor_Month1 INTO @StartDate, @’Rate_l;
				CONTINUE;
			END;

			--SELECT @ΚέyANo as ΚέyANo, 'B' as »θ, @StartDate1 as StartDate1, @StartDate2 as StartDate2, @StartDate3 as StartDate3, 
			--	@’Rate_l1 as ’Rate_l1, @’Rate_l2 as ’Rate_l2, @’Rate_l3 as ’Rate_l3, GETDATE();

			INSERT INTO [anls].[tf^Rate](
				[ΚέyANo],
				[],
				[StartDateMonth1_Begin],
				[StartDateMonth1_Center],
				[StartDateMonth1_End],
				[Rate_Begin],
				[Rate_Center],
				[Rate_End],
				[o^ϊ]
			)VALUES(
				@ΚέyANo,
				1,
				@StartDate1,
				@StartDate2,
				@StartDate3,
				@’Rate_l1,
				@’Rate_l2,
				@’Rate_l3,
				GETDATE()
			);

			FETCH NEXT FROM cursor_Month1 INTO @StartDate, @’Rate_l;
		END

		CLOSE cursor_Month1;
		DEALLOCATE cursor_Month1;

		Set @ΚέyANo = @ΚέyANo + 1;
	end;

END
GO
/*
*/
