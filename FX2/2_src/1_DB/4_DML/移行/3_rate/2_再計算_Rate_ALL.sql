-- 
-- �e�X�g�ł͕K�v�ł��A���ۂ̈ڍs�ł͂��Ȃ��͂��B
-- 


USE [FX2_Demo]
GO

DECLARE @StartDate	Datetime = getdate();
EXECUTE [reca].[sp�Čv�Z_Rate_Min1] -10, @StartDate;
GO
DECLARE @StartDate	Datetime = getdate();
EXECUTE [reca].[sp�Čv�Z_Rate_Min5] -10, @StartDate;
GO
DECLARE @StartDate	Datetime = getdate();
EXECUTE [reca].[sp�Čv�Z_Rate_Min15] -10, @StartDate;
GO
--DECLARE @StartDate	Datetime = getdate();
--EXECUTE [reca].[sp�Čv�Z_Rate_Min30] -10, @StartDate;
--GO
--DECLARE @StartDate	Datetime = getdate();
--EXECUTE [reca].[sp�Čv�Z_Rate_Hour1] -10, @StartDate;
--GO
--DECLARE @StartDate	Datetime = getdate();
--EXECUTE [reca].[sp�Čv�Z_Rate_Day1] -10, @StartDate;
--GO
--DECLARE @StartDate	Datetime = getdate();
--EXECUTE [reca].[sp�Čv�Z_Rate_Week1] -10, @StartDate;
--GO
--DECLARE @StartDate	Datetime = getdate();
--EXECUTE [reca].[sp�Čv�Z_Rate_Month1] -10, @StartDate;
--GO

