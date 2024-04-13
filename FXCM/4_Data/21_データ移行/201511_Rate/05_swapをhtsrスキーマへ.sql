USE [DemoA_FX];
go

INSERT INTO [hstr].[tHour1]
	([通貨ペアNo]
	,[StartDate]
	,[買いSwap]
	,[売りSwap])
SELECT 
	 [通貨ペアNo]
	,[日時]
	,[Swap_買い]
	,[Swap_売り]
FROM [dbo].[T_SwapHistory_Hourly]
GO

