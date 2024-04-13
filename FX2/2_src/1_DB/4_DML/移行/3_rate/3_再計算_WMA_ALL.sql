USE [FX2_Demo]
GO

--DECLARE @now	datetime = getdate();
--DECLARE @back_Month1 int;
--select @back_Month1 = DATEDIFF(MONTH, GETDATE(), MIN(StartDate)) from rate.tRateHistory_Month1;
--EXECUTE [reca].[spçƒåvéZ_WMA_Month1] @back_Month1, @now;
--GO

--DECLARE @now	datetime = getdate();
--DECLARE @back_Week1 int;
--select @back_Week1 = DATEDIFF(WEEK, GETDATE(), MIN(StartDate)) from rate.tRateHistory_Week1;
--EXECUTE [reca].[spçƒåvéZ_WMA_Week1] @back_Week1, @now;
--GO

--DECLARE @now	datetime = getdate();
--DECLARE @back_Day1 int;
--select @back_Day1 = DATEDIFF(DAY, GETDATE(), MIN(StartDate)) from rate.tRateHistory_Day1;
--EXECUTE [reca].[spçƒåvéZ_WMA_Day1] @back_Day1, @now;
--GO

--DECLARE @now	datetime = getdate();
--DECLARE @back_Hour1 int;
--select @back_Hour1 = DATEDIFF(HOUR, GETDATE(), MIN(StartDate)) from rate.tRateHistory_Hour1;
--EXECUTE [reca].[spçƒåvéZ_WMA_Hour1] @back_Hour1, @now;
--GO

--DECLARE @now	datetime = getdate();
--DECLARE @back_Min30 int;
--select @back_Min30 = DATEDIFF(MINUTE, GETDATE(), MIN(StartDate)) / 30 from rate.tRateHistory_Min30;
--EXECUTE [reca].[spçƒåvéZ_WMA_Min30] @back_Min30, @now;
--GO

--select GETDATE()
--select MIN(StartDate) from rate.tRateHistory_Min15;
--select DATEDIFF(MINUTE, GETDATE(), MIN(StartDate)) / 15 from rate.tRateHistory_Min15;
DECLARE @now	datetime = getdate();
DECLARE @back_Min15 int;
select @back_Min15 = DATEDIFF(MINUTE, GETDATE(), MIN(StartDate)) / 15 from rate.tRateHistory_Min15;
--select @back_Min15
EXECUTE [reca].[spçƒåvéZ_WMA_Min15] @back_Min15, @now;
GO

DECLARE @now	datetime = getdate();
DECLARE @back_Min5 int;
select @back_Min5 = DATEDIFF(MINUTE, GETDATE(), MIN(StartDate)) / 5 from rate.tRateHistory_Min5;
EXECUTE [reca].[spçƒåvéZ_WMA_Min5] @back_Min5, @now;
GO

DECLARE @now	datetime = getdate();
DECLARE @back_Min1 int;
select @back_Min1 = DATEDIFF(MINUTE, GETDATE(), MIN(StartDate)) from rate.tRateHistory_Min1;
EXECUTE [reca].[spçƒåvéZ_WMA_Min1] @back_Min1, @now;
GO
