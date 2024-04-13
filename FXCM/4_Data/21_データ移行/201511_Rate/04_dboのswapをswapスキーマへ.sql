USE [DemoA_FX];
go

INSERT INTO [swap].[tSwapHistory_Hour1]
	([通貨ペアNo]
	,[日時]
	,[Swap_買い]
	,[Swap_売り])
SELECT 
	 [通貨ペアNo]
	,[日時]
	,[Swap_買い]
	,[Swap_売り]
FROM [dbo].[T_SwapHistory_Hourly]
GO

