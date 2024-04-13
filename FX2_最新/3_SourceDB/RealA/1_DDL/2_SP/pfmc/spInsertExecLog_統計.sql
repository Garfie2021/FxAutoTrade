USE OANDA_DemoB
GO

DROP PROCEDURE [pfmc].[spInsertExecLog_統計]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [pfmc].[spInsertExecLog_統計]
	@back_Day1 int = -1,
	@max_Day1 int = 0
AS
BEGIN
	/*
	Declare @StartDate	datetime = '2017/08/18 6:00:00';
	Declare @EndDate	datetime = '2017/08/19 6:00:00';
	*/
	DECLARE @now		Datetime = GETDATE();
	DECLARE @ThisDate	datetime;
	DECLARE @StartDate	datetime;
	DECLARE @EndDate	datetime;

	while @back_Day1 < @max_Day1
	begin

		EXECUTE [cmn].[spGetThisDay1] @now, @back_Day1, @ThisDate OUTPUT, @StartDate OUTPUT, @EndDate OUTPUT;

		--DELETE FROM [pfmc].[tExecLog_統計] Where [StartDate] = @StartDate;

		INSERT INTO [pfmc].[tExecLog_統計] (
			 [口座No]
			,[StartDate]
			,[処理区分]
			,[処理名]
			,[取引状況]
			,[Count]
		)
		SELECT
			 [口座No]
			,@StartDate
			,[処理区分]
			,[処理名]
			,[取引状況]
			,SUM([Count])
		FROM [pfmc].[tExecLog_統計_通貨ペア別] 
		Where [StartDate] = @StartDate
		Group by [口座No], [処理区分], [処理名], [取引状況];

		Set @back_Day1 = @back_Day1 + 1;
	end;

END
GO

