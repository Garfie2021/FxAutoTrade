USE OANDA_DemoB
GO

DELETE FROM [hstr].[tMin1] WHERE StartDate = '2017/08/18 22:33:00';
--DELETE FROM [hstr].[tMin5] WHERE StartDate = '2017/08/18 22:30:00';
--DELETE FROM [hstr].[tMin15] WHERE StartDate = '2017/08/18 22:30:00';
--DELETE FROM [hstr].[tHour1] WHERE StartDate = '2017/08/18 22:00:00';
--DELETE FROM [hstr].[tDay1] WHERE StartDate = '2017/08/18 6:00:00';
--DELETE FROM [hstr].[tWeek1] WHERE StartDate = '2017/08/14 6:00:00';
--DELETE FROM [hstr].[tMonth1] WHERE StartDate = '2017/08/01 6:00:00';
--GO

EXECUTE recu.spInsertHistoryçƒåvéZ_nëOÇ©ÇÁ_Min1 -1, 0;
go


/*
EXECUTE [rate].[spInsertHistoryAll_Min1] @StartDate = '2017/08/18 22:33:00', @EndDate = '2017/08/18 22:34:00';
GO
EXECUTE [rate].[spInsertHistoryAll_Min5] @StartDate = '2017/08/18 22:30:00', @EndDate = '2017/08/18 22:35:00';
GO

EXECUTE [rate].[spInsertHistoryAll_Min15] @StartDate = '2017/08/18 22:30:00', @EndDate = '2017/08/18 23:45:00';
GO

EXECUTE [rate].[spInsertHistoryAll_Hour1] @StartDate = '2017/08/18 22:00:00', @EndDate = '2017/08/18 23:00:00';
GO

EXECUTE [rate].[spInsertHistoryAll_Day1] @StartDate = '2017/08/18 6:00:00', @EndDate = '2017/08/19 6:00:00';
GO

EXECUTE [rate].[spInsertHistoryAll_Week1] @StartDate = '2017/08/14 6:00:00', @EndDate = '2017/08/21 6:00:00';
GO

EXECUTE [rate].[spInsertHistoryAll_Month1] @StartDate = '2017/08/01 6:00:00', @EndDate = '2017/09/01 6:00:00';
GO
*/
