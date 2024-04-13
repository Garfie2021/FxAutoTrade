USE [DB_Profiler]
GO

DROP PROCEDURE [dbo].[SP_SelectSQL]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[SP_SelectSQL]
AS
BEGIN


	SELECT TOP 100
		[RowNumber]
		,[EventClass]
		,[TextData]
		,[ApplicationName]
		,[NTUserName]
		,[LoginName]
		,[CPU]
		,[Reads]
		,[Writes]
		,[Duration]
		,[ClientProcessID]
		,[SPID]
		,[StartTime]
		,[EndTime]
	FROM [dbo].[–³‘è - 1]
	where TextData is not null 
		and TextData not like '%sp_reset_connection%'
		and TextData not like '%/*%'
		and TextData not like '%sys.%'		
	--order by [StartTime] desc
	order by [Duration] desc


END

GO

