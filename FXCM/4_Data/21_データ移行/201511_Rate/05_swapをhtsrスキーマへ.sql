USE [DemoA_FX];
go

INSERT INTO [hstr].[tHour1]
	([�ʉ݃y�ANo]
	,[StartDate]
	,[����Swap]
	,[����Swap])
SELECT 
	 [�ʉ݃y�ANo]
	,[����]
	,[Swap_����]
	,[Swap_����]
FROM [dbo].[T_SwapHistory_Hourly]
GO

