USE OANDA_DemoB
GO

DROP PROCEDURE [pfmc].[spUpdateExecLog_シグマ]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [pfmc].[spUpdateExecLog_シグマ]
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




		DECLARE @TableName NVARCHAR(128), @TriggerName NVARCHAR(128), @TriggerNameList NVARCHAR(MAX) = '';

		DECLARE cursorExecLog_統計 CURSOR FOR
		SELECT [口座No], [StartDate], [処理区分], [処理名], [取引状況], [Count]
		FROM [pfmc].[tExecLog_統計]




			SELECT O.name AS TableName,
				   TR.name AS TriggerName
			FROM   sys.triggers AS TR
					  INNER JOIN sys.objects AS O
						 ON TR.parent_id = O.object_id
			WHERE  TR.is_disabled = 0
				   AND O.type = 'U'
			ORDER BY TableName, TriggerName;

		OPEN crTriggerList;

		FETCH NEXT FROM crTriggerList
		INTO @TableName, @TriggerName;

		WHILE @@FETCH_STATUS = 0
		BEGIN

			SET @TriggerNameList = @TriggerNameList 
					 + @TriggerName 
					 + '[' + @TableName + ']' 
					 + CHAR(13);

			FETCH NEXT FROM crTriggerList
			INTO @TableName, @TriggerName;

		END

		CLOSE crTriggerList;
		DEALLOCATE crTriggerList;

		SELECT @買いWMAs14角度シグマ = (@買いWMAs14角度 - AVG([買いWMAs14角度])) / STDEV([買いWMAs14角度])
		FROM [hstr].[tMin15]
		WHERE 通貨ペアNo = @通貨ペアNo and 0 < [買いWMAs14角度] and 
			DATEADD(month, -2, @StartDate) < [StartDate] and [StartDate] < @StartDate;


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

