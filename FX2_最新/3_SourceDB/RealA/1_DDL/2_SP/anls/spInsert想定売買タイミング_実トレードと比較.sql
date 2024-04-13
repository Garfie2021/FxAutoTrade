USE OANDA_RealA
GO

DROP PROCEDURE [anls].[spInsertzθ^C~O_ΐg[hΖδr]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [anls].[spInsertzθ^C~O_ΐg[hΖδr]
	@StartDate_Month1	datetime
AS
BEGIN

	DECLARE cursor_zθ^C~O cursor for
	SELECT  [ΚέyANo], [»θ], [StartDateMin1], [StartDateMin5], [StartDateMin15], [StartDateHour1], [StartDateDay1]
	FROM [anls].[tzθ^C~O]
	WHERE [StartDateMonth1] = @StartDate_Month1;

	OPEN cursor_zθ^C~O;

	DECLARE @ΚέyANo			tinyint;
	DECLARE @»θ			bit;
	DECLARE @StartDateMin1		datetime;
	DECLARE @StartDateMin5		datetime;
	DECLARE @StartDateMin15		datetime;
	DECLARE @StartDateHour1		datetime;
	DECLARE @StartDateDay1		datetime;
	FETCH NEXT FROM cursor_zθ^C~O INTO @ΚέyANo, @»θ, @StartDateMin1, @StartDateMin5, @StartDateMin15, @StartDateHour1, @StartDateDay1;

	WHILE @@FETCH_STATUS = 0
	BEGIN

		DECLARE @δrΚ varchar(8000);


		-- zθ^C~OΌίΙΆLθ

		DECLARE @Cnt int;
		SELECT @Cnt = COUNT(*)
		FROM [oder].[tOrderHistory2]
		WHERE [ΚέyANo] = @ΚέyANo AND [] = @»θ AND @StartDateDay1 <= [ϊ] AND [ϊ] < DATEADD(DAY, 1, @StartDateDay1)

		IF @Cnt > 0
		BEGIN
			SET @δrΚ = '1ϊΘΰΙΆLθB';
		END ELSE BEGIN
			SET @δrΚ = '1ϊΘΰΙΆ³΅B';
		END;

		SELECT @Cnt = COUNT(*)
		FROM [oder].[tOrderHistory2]
		WHERE [ΚέyANo] = @ΚέyANo AND [] = @»θ AND @StartDateHour1 <= [ϊ] AND [ϊ] < DATEADD(HOUR, 1, @StartDateHour1)

		IF @Cnt > 0
		BEGIN
			SET @δrΚ = '1ΤΘΰΙΆLθB';
		END ELSE BEGIN
			SET @δrΚ = '1ΤΘΰΙΆ³΅B';
		END;


		-- zθ^C~OΌίΜO

		DECLARE cursor_ExecLog cursor for
		SELECT  [ζψσ΅]
		FROM [pfmc].[tExecLog]
		WHERE [ΚέyANo] = @ΚέyANo AND @StartDateMin1 <= [ExecDate] AND [ExecDate] < @StartDateMin1;

		OPEN cursor_ExecLog;

		DECLARE @ζψσ΅ varchar(100);
		FETCH NEXT FROM cursor_ExecLog INTO @ζψσ΅;

		WHILE @@FETCH_STATUS = 0
		BEGIN
			SET @δrΚ = @δrΚ + @ζψσ΅ + 'B';

			FETCH NEXT FROM cursor_ExecLog INTO @ζψσ΅;
		END

		CLOSE cursor_ExecLog;
		DEALLOCATE cursor_ExecLog;


		-- δrΚπWrite

		UPDATE [anls].[tzθ^C~O]
		SET [δrΚ] = @δrΚ,
			[XVϊ] = getdate()
		WHERE @ΚέyANo = [ΚέyANo] AND @»θ = [»θ] AND @StartDateMin1 = [StartDateMin1];

		FETCH NEXT FROM cursor_zθ^C~O INTO @ΚέyANo, @»θ, @StartDateMin1, @StartDateMin5, @StartDateMin15, @StartDateHour1, @StartDateDay1;
	END

	CLOSE cursor_zθ^C~O;
	DEALLOCATE cursor_zθ^C~O;


END
GO

