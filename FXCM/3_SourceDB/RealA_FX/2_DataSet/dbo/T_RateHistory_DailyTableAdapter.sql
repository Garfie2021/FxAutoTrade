use FX_RealA

DECLARE @通貨ペアNo int
DECLARE @割合 float
DECLARE @StartDate datetime
DECLARE @EndDate datetime
DECLARE @MinDate datetime
DECLARE @MaxDate datetime
SET @MaxDate = CONVERT(datetime, '2013/08/13 06:00:00')
SET @MinDate = CONVERT(datetime, '2013/08/13 06:00:00')
SET @StartDate = CONVERT(datetime, '2013/08/13 06:00:00')
SET @EndDate = CONVERT(datetime, '2013/08/14 06:00:00')
SET @通貨ペアNo = 0
SET @割合 = 0.3


-- Fill
SELECT            T_RateHistory_Daily.*
FROM              T_RateHistory_Daily

-- FillBy通貨ペアNo期間
SELECT
	T_RateHistory_Daily.*
FROM
	T_RateHistory_Daily
WHERE
	(通貨ペアNo = @通貨ペアNo) and
	(@StartDate < 日時 and 日時 < @EndDate)
ORDER BY
	日時


