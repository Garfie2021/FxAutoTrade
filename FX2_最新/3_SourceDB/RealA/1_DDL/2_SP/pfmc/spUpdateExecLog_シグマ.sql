USE OANDA_DemoB
GO

DROP PROCEDURE [pfmc].[spUpdateExecLog_�V�O�}]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [pfmc].[spUpdateExecLog_�V�O�}]
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

		DECLARE cursorExecLog_���v CURSOR FOR
		SELECT [����No], [StartDate], [�����敪], [������], [�����], [Count]
		FROM [pfmc].[tExecLog_���v]




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

		SELECT @����WMAs14�p�x�V�O�} = (@����WMAs14�p�x - AVG([����WMAs14�p�x])) / STDEV([����WMAs14�p�x])
		FROM [hstr].[tMin15]
		WHERE �ʉ݃y�ANo = @�ʉ݃y�ANo and 0 < [����WMAs14�p�x] and 
			DATEADD(month, -2, @StartDate) < [StartDate] and [StartDate] < @StartDate;


		INSERT INTO [pfmc].[tExecLog_���v] (
			 [����No]
			,[StartDate]
			,[�����敪]
			,[������]
			,[�����]
			,[Count]
		)
		SELECT
			 [����No]
			,@StartDate
			,[�����敪]
			,[������]
			,[�����]
			,SUM([Count])
		FROM [pfmc].[tExecLog_���v_�ʉ݃y�A��] 
		Where [StartDate] = @StartDate
		Group by [����No], [�����敪], [������], [�����];

		Set @back_Day1 = @back_Day1 + 1;
	end;

END
GO

