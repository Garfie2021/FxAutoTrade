use FX_RealA

DECLARE @�ʉ݃y�ANo int
DECLARE @���� float
DECLARE @FromDate datetime
DECLARE @ToDate datetime
DECLARE @MinDate datetime
DECLARE @MaxDate datetime
SET @MaxDate = CONVERT(datetime, '2013/08/13 06:00:00')
SET @MinDate = CONVERT(datetime, '2013/08/13 06:00:00')
SET @FromDate = CONVERT(datetime, '2013/08/13 06:00:00')
SET @ToDate = CONVERT(datetime, '2013/08/14 06:00:00')
SET @�ʉ݃y�ANo = 0
SET @���� = 0.3


-- Fill
SELECT            T_RateHistory_Weekly.*
FROM              T_RateHistory_Weekly

-- FillBy�ʉ݃y�A
SELECT
	T_RateHistory_Weekly.*
FROM
	T_RateHistory_Weekly
WHERE
	(�ʉ݃y�ANo = @�ʉ݃y�ANo)
ORDER BY
	[Year], [Week]
	
-- ScalarMinRate�ʉ݃y�A
SELECT
	MIN(MinRate) as Rate
FROM
	T_RateHistory_Weekly
WHERE
	(�ʉ݃y�ANo = @�ʉ݃y�ANo)

-- ScalarMaxRate�ʉ݃y�A
SELECT
	MAX(MaxRate) as Rate
FROM
	T_RateHistory_Weekly
WHERE
	(�ʉ݃y�ANo = @�ʉ݃y�ANo)
