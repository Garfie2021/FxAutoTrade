use FX_RealA

DECLARE @�ʉ݃y�ANo int
DECLARE @���� float
DECLARE @StartDate datetime
DECLARE @EndDate datetime
DECLARE @MinDate datetime
DECLARE @MaxDate datetime
SET @MaxDate = CONVERT(datetime, '2013/08/13 06:00:00')
SET @MinDate = CONVERT(datetime, '2013/08/13 06:00:00')
SET @StartDate = CONVERT(datetime, '2013/08/13 06:00:00')
SET @EndDate = CONVERT(datetime, '2013/08/14 06:00:00')
SET @�ʉ݃y�ANo = 0
SET @���� = 0.3


-- Fill
SELECT            T_RateHistory_Daily.*
FROM              T_RateHistory_Daily

-- FillBy�ʉ݃y�ANo����
SELECT
	T_RateHistory_Daily.*
FROM
	T_RateHistory_Daily
WHERE
	(�ʉ݃y�ANo = @�ʉ݃y�ANo) and
	(@StartDate < ���� and ���� < @EndDate)
ORDER BY
	����


