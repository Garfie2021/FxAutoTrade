-- 
-- テストでは必要でも、実際の移行ではやらないはず。
-- 


USE [FX2_Demo]
GO

DECLARE @StartDate	Datetime = getdate();
EXECUTE [reca].[sp再計算_Rate_Min1] -10, @StartDate;
GO
DECLARE @StartDate	Datetime = getdate();
EXECUTE [reca].[sp再計算_Rate_Min5] -10, @StartDate;
GO
DECLARE @StartDate	Datetime = getdate();
EXECUTE [reca].[sp再計算_Rate_Min15] -10, @StartDate;
GO
--DECLARE @StartDate	Datetime = getdate();
--EXECUTE [reca].[sp再計算_Rate_Min30] -10, @StartDate;
--GO
--DECLARE @StartDate	Datetime = getdate();
--EXECUTE [reca].[sp再計算_Rate_Hour1] -10, @StartDate;
--GO
--DECLARE @StartDate	Datetime = getdate();
--EXECUTE [reca].[sp再計算_Rate_Day1] -10, @StartDate;
--GO
--DECLARE @StartDate	Datetime = getdate();
--EXECUTE [reca].[sp再計算_Rate_Week1] -10, @StartDate;
--GO
--DECLARE @StartDate	Datetime = getdate();
--EXECUTE [reca].[sp再計算_Rate_Month1] -10, @StartDate;
--GO

