USE DemoA_FX
GO

DROP PROCEDURE [anls].[spInsert注文対象通貨ペア数Daily_n前から]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [anls].[spInsert注文対象通貨ペア数Daily_n前から]
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
	DECLARE @注文対象通貨ペア数_想定	tinyint;
	DECLARE @注文対象通貨ペア数_実績	tinyint;

	while @back_Day1 < 1
	begin

		EXECUTE [cmn].[spGetThisDay1] @now, @back_Day1, @ThisDate OUTPUT, @StartDate OUTPUT, @EndDate OUTPUT;

		SELECT @注文対象通貨ペア数_想定 = count(*)
		from (
			SELECT [通貨ペアNo]
			FROM [DemoA_FX].[anls].[t想定売買タイミング]
			where [StartDateDay1] = @StartDate
			group by [通貨ペアNo]
		) as t;

		SELECT @注文対象通貨ペア数_実績 = count(*)
		FROM [oder].[t注文対象通貨ペアDaily]
		WHERE [StartDate] = @StartDate

		select @Cnt = count(*)
		from [anls].[t注文対象通貨ペア数Daily]
		where [StartDate] = @StartDate

		if @Cnt < 1
		begin
			INSERT INTO [anls].[t注文対象通貨ペア数Daily] (
				[StartDate], 注文対象通貨ペア数_想定, [注文対象通貨ペア数_実績]
			) VALUES (
				@StartDate, @注文対象通貨ペア数_想定, @注文対象通貨ペア数_実績
			);
		end
		else
		begin
			UPDATE [anls].[t注文対象通貨ペア数Daily]
			SET [注文対象通貨ペア数_想定] = @注文対象通貨ペア数_想定,
				[注文対象通貨ペア数_実績] = @注文対象通貨ペア数_実績
			WHERE [StartDate] = @StartDate;
		end;

		Set @back_Day1 = @back_Day1 + 1;
	end;
END
GO
/*
*/
