USE [DemoA_FX];
go

INSERT INTO [swap].[tSwapHistory_Hour1]
	([ΚέyANo]
	,[ϊ]
	,[Swap_’]
	,[Swap_θ])
SELECT 
	 [ΚέyANo]
	,[ϊ]
	,[Swap_’]
	,[Swap_θ]
FROM [dbo].[T_SwapHistory_Hourly]
GO

