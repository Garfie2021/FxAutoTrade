use FX_RealA

DECLARE @year_wk varchar(100)
DECLARE @TradeID varchar(100)
DECLARE @Date datetime
DECLARE @開始CloseTime datetime
DECLARE @終了CloseTime datetime
DECLARE @FromDate datetime
DECLARE @ToDate datetime
DECLARE @From datetime
DECLARE @To datetime
SET @FromDate = CONVERT(datetime, '2013/08/13 06:00:00')
SET @ToDate = CONVERT(datetime, '2013/08/14 06:00:00')
SET @From = CONVERT(datetime, '2013/08/13 06:00:00')
SET @To = CONVERT(datetime, '2013/08/14 06:00:00')
SET @終了CloseTime = 0
SET @開始CloseTime = 0
SET @Date = 0
SET @year_wk = ''
SET @TradeID = '1'


-- Fill
SELECT            T_year_wk.*
FROM              T_year_wk

-- FillBy
SELECT            T_year_wk.*
FROM              T_year_wk
where year_wk = @year_wk

-- DeleteAll
DELETE FROM [T_year_wk]

-- Scalar_year_wk
SELECT        top 1 year_wk
FROM              T_year_wk
where StartDate <= @date and @date <= EndDate
