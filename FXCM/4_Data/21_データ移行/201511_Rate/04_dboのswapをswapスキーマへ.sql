USE [DemoA_FX];
go

INSERT INTO [swap].[tSwapHistory_Hour1]
	([�ʉ݃y�ANo]
	,[����]
	,[Swap_����]
	,[Swap_����])
SELECT 
	 [�ʉ݃y�ANo]
	,[����]
	,[Swap_����]
	,[Swap_����]
FROM [dbo].[T_SwapHistory_Hourly]
GO

