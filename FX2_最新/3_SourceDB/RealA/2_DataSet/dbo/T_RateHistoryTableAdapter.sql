use FX_RealA


DECLARE @通貨ペア int
DECLARE @割合 float
DECLARE @FromDate datetime
DECLARE @ToDate datetime
DECLARE @MinDate datetime
DECLARE @MaxDate datetime
SET @MaxDate = CONVERT(datetime, '2013/08/13 06:00:00')
SET @MinDate = CONVERT(datetime, '2013/08/13 06:00:00')
SET @FromDate = CONVERT(datetime, '2013/08/13 06:00:00')
SET @ToDate = CONVERT(datetime, '2013/08/14 06:00:00')
SET @通貨ペア = 0
SET @割合 = 0.3


-- Fill
SELECT            通貨ペア, Date, Rate_買い, Rate_売り, Swap_買い, Swap_売り, Rate相反Status_買い, Rate相反Status_売り
FROM              T_RateHistory

-- FillBy
SELECT            Date, Rate_売り, Rate_買い, Rate相反Status_売り, Rate相反Status_買い, Swap_売り, Swap_買い, 通貨ペア
FROM              T_RateHistory
WHERE             (通貨ペア = @通貨ペア)
ORDER BY       Date

-- FillBy期間
SELECT            Date, Rate_売り, Rate_買い, Rate相反Status_売り, Rate相反Status_買い, Swap_売り, Swap_買い, 通貨ペア
FROM              T_RateHistory
WHERE             (通貨ペア = @通貨ペア) AND (@FromDate <= Date) AND (Date < @ToDate)
ORDER BY       Date

-- FillByLastDate
SELECT            TOP (1) 通貨ペア, Date, Rate_買い, Rate_売り, Swap_買い, Swap_売り, Rate相反Status_買い, Rate相反Status_売り
FROM              T_RateHistory
WHERE             (通貨ペア = @通貨ペア)
ORDER BY       Date DESC

-- FillByLastDate_通貨ペア日時
SELECT            TOP (1) 通貨ペア, Date, Rate_買い, Rate_売り, Swap_買い, Swap_売り, Rate相反Status_買い, Rate相反Status_売り
FROM              T_RateHistory
WHERE             (通貨ペア = @通貨ペア) and [Date] <= @ToDate
ORDER BY       Date DESC

-- FillBy週_開始点
SELECT            TOP (1) Date, Rate_売り, Rate_買い, Rate相反Status_売り, Rate相反Status_買い, Swap_売り, Swap_買い, 通貨ペア
FROM              T_RateHistory
WHERE             (通貨ペア = @通貨ペア) AND (Date >= @FromDate) AND (Date < @ToDate)
ORDER BY       Date

-- FillBy週_終了点
SELECT            TOP (1) Date, Rate_売り, Rate_買い, Rate相反Status_売り, Rate相反Status_買い, Swap_売り, Swap_買い, 通貨ペア
FROM              T_RateHistory
WHERE             (通貨ペア = @通貨ペア) AND (Date >= @FromDate) AND (Date < @ToDate)
ORDER BY       Date DESC

-- ScalarAvgRate買い
SELECT            AVG(Rate_買い) AS AvgRate
FROM              T_RateHistory
WHERE             (Date > @MinDate) AND (Date < @MaxDate) AND (通貨ペア = @通貨ペア)

-- ScalarAvgRate売り
SELECT            AVG(Rate_売り) AS AvgRate
FROM              T_RateHistory
WHERE             (Date > @MinDate) AND (Date < @MaxDate) AND (通貨ペア = @通貨ペア)

-- ScalarMaxDate
SELECT            MAX(Date) AS Expr1
FROM              T_RateHistory
WHERE             (通貨ペア = @通貨ペア)

-- ScalarMaxRate
SELECT
	MAX(Rate) AS Expr1
FROM(
	SELECT
		MAX(Rate_買い) AS Rate
	FROM
		T_RateHistory
	WHERE
		(通貨ペア = @通貨ペア)
	UNION
	SELECT
		MAX(Rate_売り) AS Rate
	FROM
		T_RateHistory AS T_RateHistory_1
	WHERE
		(通貨ペア = @通貨ペア)
) AS t

-- ScalarMinDate
SELECT            Min(Date) AS Expr1
FROM              T_RateHistory
WHERE             (通貨ペア = @通貨ペア)


-- ScalarMinRate
SELECT            MIN(Rate) AS Expr1
FROM              (SELECT            MIN(Rate_買い) AS Rate
                         FROM              T_RateHistory
                         WHERE             (通貨ペア = @通貨ペア)
                         UNION
                         SELECT            MIN(Rate_売り) AS Rate
                         FROM              T_RateHistory AS T_RateHistory_1
                         WHERE             (通貨ペア = @通貨ペア)) AS t
                         
-- ScalarMaxSwap
SELECT            MAX(Swap) AS Expr1
FROM              (SELECT            MAX(Swap_買い) AS Swap
                         FROM              T_RateHistory
                         WHERE             (通貨ペア = @通貨ペア)
                         UNION
                         SELECT            MAX(Swap_売り) AS Swap
                         FROM              T_RateHistory AS T_RateHistory_1
                         WHERE             (通貨ペア = @通貨ペア)) AS t
                         
-- ScalarMinSwap
SELECT            MIN(Swap) AS Expr1
FROM              (SELECT            MIN(Swap_買い) AS Swap
                         FROM              T_RateHistory
                         WHERE             (通貨ペア = @通貨ペア)
                         UNION
                         SELECT            MIN(Swap_売り) AS Swap
                         FROM              T_RateHistory AS T_RateHistory_1
                         WHERE             (通貨ペア = @通貨ペア)) AS t


-- ScalarRate幅
SELECT
	--MIN(Rate_買い) as minRate,
	--MAX(Rate_買い) as maxRate,
	--MIN(Date) as minDate,
	--MAX(Date) as maxDate,
	(MAX(Rate_買い) - MIN(Rate_買い)) AS Rate幅
FROM
	T_RateHistory
WHERE
	(通貨ペア = @通貨ペア) AND 
	(@FromDate <= Date) AND 
	(Date < @ToDate)


-- ScalarMaxRate買い_通貨ペア期間
SELECT
	MAX(Rate_買い) AS Rate
FROM
	T_RateHistory
WHERE
	(通貨ペア = @通貨ペア) AND 
	(@FromDate <= Date) AND 
	(Date < @ToDate)

-- ScalarMinRate買い_通貨ペア期間
SELECT
	MIN(Rate_買い) AS Rate
FROM
	T_RateHistory
WHERE
	(通貨ペア = @通貨ペア) AND 
	(@FromDate <= Date) AND 
	(Date < @ToDate)

-- ScalarMaxRate売り_通貨ペア期間
SELECT
	MAX(Rate_売り) AS Rate
FROM
	T_RateHistory
WHERE
	(通貨ペア = @通貨ペア) AND 
	(@FromDate <= Date) AND 
	(Date < @ToDate)

-- ScalarMinRate売り_通貨ペア期間
SELECT
	MIN(Rate_売り) AS Rate
FROM
	T_RateHistory
WHERE
	(通貨ペア = @通貨ペア) AND 
	(@FromDate <= Date) AND 
	(Date < @ToDate)
