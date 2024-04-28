USE OANDA_DemoB
GO

DROP PROCEDURE [pfmc].[spInsertExecLog_���v_�ʉ݃y�A��]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [pfmc].[spInsertExecLog_���v_�ʉ݃y�A��]
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

		--DELETE FROM [pfmc].[tExecLog_���v_�ʉ݃y�A��] Where [StartDate] = @StartDate;

		INSERT INTO [pfmc].[tExecLog_���v_�ʉ݃y�A��] (
			 [����No]
			,[StartDate]
			,[�����敪]
			,[�ʉ݃y�ANo]
			,[������]
			,[�����]
			,[Count]
		)
		SELECT
			 [����No]
			,@StartDate
			,[�����敪]
			,[�ʉ݃y�ANo]
			,[������]
			,[�����]
			,count(*)
		FROM [pfmc].[tExecLog]
		where @StartDate <= [ExecDate] and [ExecDate] < @EndDate
		group by [����No], [�����敪], [�ʉ݃y�ANo], [������], [�����];

		Set @back_Day1 = @back_Day1 + 1;
	end;

END
GO

