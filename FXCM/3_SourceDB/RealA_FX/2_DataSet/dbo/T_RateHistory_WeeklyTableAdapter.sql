use FX_RealA

DECLARE @通貨ペアNo int
DECLARE @割合 float
DECLARE @FromDate datetime
DECLARE @ToDate datetime
DECLARE @MinDate datetime
DECLARE @MaxDate datetime
SET @MaxDate = CONVERT(datetime, '2013/08/13 06:00:00')
SET @MinDate = CONVERT(datetime, '2013/08/13 06:00:00')
SET @FromDate = CONVERT(datetime, '2013/08/13 06:00:00')
SET @ToDate = CONVERT(datetime, '2013/08/14 06:00:00')
SET @通貨ペアNo = 0
SET @割合 = 0.3


-- Fill
SELECT            T_RateHistory_Weekly.*
FROM              T_RateHistory_Weekly

-- FillBy通貨ペア
SELECT
	T_RateHistory_Weekly.*
FROM
	T_RateHistory_Weekly
WHERE
	(通貨ペアNo = @通貨ペアNo)
ORDER BY
	[Year], [Week]
	
-- ScalarMinRate通貨ペア
SELECT
	MIN(MinRate) as Rate
FROM
	T_RateHistory_Weekly
WHERE
	(通貨ペアNo = @通貨ペアNo)

-- ScalarMaxRate通貨ペア
SELECT
	MAX(MaxRate) as Rate
FROM
	T_RateHistory_Weekly
WHERE
	(通貨ペアNo = @通貨ペアNo)
