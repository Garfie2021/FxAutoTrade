use FX_RealA


DECLARE @�ʉ݃y�A int
DECLARE @���� float
DECLARE @FromDate datetime
DECLARE @ToDate datetime
DECLARE @MinDate datetime
DECLARE @MaxDate datetime
SET @MaxDate = CONVERT(datetime, '2013/08/13 06:00:00')
SET @MinDate = CONVERT(datetime, '2013/08/13 06:00:00')
SET @FromDate = CONVERT(datetime, '2013/08/13 06:00:00')
SET @ToDate = CONVERT(datetime, '2013/08/14 06:00:00')
SET @�ʉ݃y�A = 0
SET @���� = 0.3


-- Fill
SELECT            �ʉ݃y�A, Date, Rate_����, Rate_����, Swap_����, Swap_����, Rate����Status_����, Rate����Status_����
FROM              T_RateHistory

-- FillBy
SELECT            Date, Rate_����, Rate_����, Rate����Status_����, Rate����Status_����, Swap_����, Swap_����, �ʉ݃y�A
FROM              T_RateHistory
WHERE             (�ʉ݃y�A = @�ʉ݃y�A)
ORDER BY       Date

-- FillBy����
SELECT            Date, Rate_����, Rate_����, Rate����Status_����, Rate����Status_����, Swap_����, Swap_����, �ʉ݃y�A
FROM              T_RateHistory
WHERE             (�ʉ݃y�A = @�ʉ݃y�A) AND (@FromDate <= Date) AND (Date < @ToDate)
ORDER BY       Date

-- FillByLastDate
SELECT            TOP (1) �ʉ݃y�A, Date, Rate_����, Rate_����, Swap_����, Swap_����, Rate����Status_����, Rate����Status_����
FROM              T_RateHistory
WHERE             (�ʉ݃y�A = @�ʉ݃y�A)
ORDER BY       Date DESC

-- FillByLastDate_�ʉ݃y�A����
SELECT            TOP (1) �ʉ݃y�A, Date, Rate_����, Rate_����, Swap_����, Swap_����, Rate����Status_����, Rate����Status_����
FROM              T_RateHistory
WHERE             (�ʉ݃y�A = @�ʉ݃y�A) and [Date] <= @ToDate
ORDER BY       Date DESC

-- FillBy�T_�J�n�_
SELECT            TOP (1) Date, Rate_����, Rate_����, Rate����Status_����, Rate����Status_����, Swap_����, Swap_����, �ʉ݃y�A
FROM              T_RateHistory
WHERE             (�ʉ݃y�A = @�ʉ݃y�A) AND (Date >= @FromDate) AND (Date < @ToDate)
ORDER BY       Date

-- FillBy�T_�I���_
SELECT            TOP (1) Date, Rate_����, Rate_����, Rate����Status_����, Rate����Status_����, Swap_����, Swap_����, �ʉ݃y�A
FROM              T_RateHistory
WHERE             (�ʉ݃y�A = @�ʉ݃y�A) AND (Date >= @FromDate) AND (Date < @ToDate)
ORDER BY       Date DESC

-- ScalarAvgRate����
SELECT            AVG(Rate_����) AS AvgRate
FROM              T_RateHistory
WHERE             (Date > @MinDate) AND (Date < @MaxDate) AND (�ʉ݃y�A = @�ʉ݃y�A)

-- ScalarAvgRate����
SELECT            AVG(Rate_����) AS AvgRate
FROM              T_RateHistory
WHERE             (Date > @MinDate) AND (Date < @MaxDate) AND (�ʉ݃y�A = @�ʉ݃y�A)

-- ScalarMaxDate
SELECT            MAX(Date) AS Expr1
FROM              T_RateHistory
WHERE             (�ʉ݃y�A = @�ʉ݃y�A)

-- ScalarMaxRate
SELECT
	MAX(Rate) AS Expr1
FROM(
	SELECT
		MAX(Rate_����) AS Rate
	FROM
		T_RateHistory
	WHERE
		(�ʉ݃y�A = @�ʉ݃y�A)
	UNION
	SELECT
		MAX(Rate_����) AS Rate
	FROM
		T_RateHistory AS T_RateHistory_1
	WHERE
		(�ʉ݃y�A = @�ʉ݃y�A)
) AS t

-- ScalarMinDate
SELECT            Min(Date) AS Expr1
FROM              T_RateHistory
WHERE             (�ʉ݃y�A = @�ʉ݃y�A)


-- ScalarMinRate
SELECT            MIN(Rate) AS Expr1
FROM              (SELECT            MIN(Rate_����) AS Rate
                         FROM              T_RateHistory
                         WHERE             (�ʉ݃y�A = @�ʉ݃y�A)
                         UNION
                         SELECT            MIN(Rate_����) AS Rate
                         FROM              T_RateHistory AS T_RateHistory_1
                         WHERE             (�ʉ݃y�A = @�ʉ݃y�A)) AS t
                         
-- ScalarMaxSwap
SELECT            MAX(Swap) AS Expr1
FROM              (SELECT            MAX(Swap_����) AS Swap
                         FROM              T_RateHistory
                         WHERE             (�ʉ݃y�A = @�ʉ݃y�A)
                         UNION
                         SELECT            MAX(Swap_����) AS Swap
                         FROM              T_RateHistory AS T_RateHistory_1
                         WHERE             (�ʉ݃y�A = @�ʉ݃y�A)) AS t
                         
-- ScalarMinSwap
SELECT            MIN(Swap) AS Expr1
FROM              (SELECT            MIN(Swap_����) AS Swap
                         FROM              T_RateHistory
                         WHERE             (�ʉ݃y�A = @�ʉ݃y�A)
                         UNION
                         SELECT            MIN(Swap_����) AS Swap
                         FROM              T_RateHistory AS T_RateHistory_1
                         WHERE             (�ʉ݃y�A = @�ʉ݃y�A)) AS t


-- ScalarRate��
SELECT
	--MIN(Rate_����) as minRate,
	--MAX(Rate_����) as maxRate,
	--MIN(Date) as minDate,
	--MAX(Date) as maxDate,
	(MAX(Rate_����) - MIN(Rate_����)) AS Rate��
FROM
	T_RateHistory
WHERE
	(�ʉ݃y�A = @�ʉ݃y�A) AND 
	(@FromDate <= Date) AND 
	(Date < @ToDate)


-- ScalarMaxRate����_�ʉ݃y�A����
SELECT
	MAX(Rate_����) AS Rate
FROM
	T_RateHistory
WHERE
	(�ʉ݃y�A = @�ʉ݃y�A) AND 
	(@FromDate <= Date) AND 
	(Date < @ToDate)

-- ScalarMinRate����_�ʉ݃y�A����
SELECT
	MIN(Rate_����) AS Rate
FROM
	T_RateHistory
WHERE
	(�ʉ݃y�A = @�ʉ݃y�A) AND 
	(@FromDate <= Date) AND 
	(Date < @ToDate)

-- ScalarMaxRate����_�ʉ݃y�A����
SELECT
	MAX(Rate_����) AS Rate
FROM
	T_RateHistory
WHERE
	(�ʉ݃y�A = @�ʉ݃y�A) AND 
	(@FromDate <= Date) AND 
	(Date < @ToDate)

-- ScalarMinRate����_�ʉ݃y�A����
SELECT
	MIN(Rate_����) AS Rate
FROM
	T_RateHistory
WHERE
	(�ʉ݃y�A = @�ʉ݃y�A) AND 
	(@FromDate <= Date) AND 
	(Date < @ToDate)
