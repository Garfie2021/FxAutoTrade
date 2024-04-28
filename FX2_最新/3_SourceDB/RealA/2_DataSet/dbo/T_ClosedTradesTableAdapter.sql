use FX_RealA


DECLARE @�ʉ݃y�A int
DECLARE @TradeID varchar(100)
DECLARE @Date datetime
DECLARE @�J�nCloseTime datetime
DECLARE @�I��CloseTime datetime
DECLARE @FromDate datetime
DECLARE @ToDate datetime
DECLARE @From datetime
DECLARE @To datetime
SET @FromDate = CONVERT(datetime, '2013/08/13 06:00:00')
SET @ToDate = CONVERT(datetime, '2013/08/14 06:00:00')
SET @From = CONVERT(datetime, '2013/08/13 06:00:00')
SET @To = CONVERT(datetime, '2013/08/14 06:00:00')
SET @�I��CloseTime = 0
SET @�J�nCloseTime = 0
SET @Date = 0
SET @�ʉ݃y�A = 0
SET @TradeID = '1'



-- Fill
SELECT            T_ClosedTrades.*
FROM              T_ClosedTrades


-- FillByTradID
SELECT            T_ClosedTrades.*
FROM              T_ClosedTrades
where TradeID = @TradeID


-- ScalarCnt
SELECT            COUNT(*) AS CNT
FROM              T_ClosedTrades
WHERE             (TradeID = @TradeID)


-- ScalarCnt_����
SELECT            COUNT(*) AS Expr1
FROM              T_ClosedTrades
WHERE             (Instrument = @�ʉ݃y�A) AND (CloseTime > @from) AND (CloseTime < @to)


-- ScalarMaxGrossPL
SELECT
	MAX(GrossPL) AS GrossPL
FROM
	T_ClosedTrades
WHERE
	(@�J�nCloseTime <= CloseTime) AND 
	(CloseTime <= @�I��CloseTime) 

-- ScalarMinGrossPL
SELECT            MIN(GrossPL) AS GrossPL
FROM              T_ClosedTrades
WHERE             (CloseTime >= @�J�nCloseTime) AND (CloseTime <= @�I��CloseTime)

-- ScalarSUM���v
SELECT
	SUM(GrossPL)
FROM
	T_ClosedTrades
WHERE
	(@FromDate <= CloseTime) AND 
	(CloseTime < @ToDate)

-- ScalarSUM���v_�ʉ݃y�A
SELECT
	SUM(GrossPL)
FROM
	T_ClosedTrades
WHERE
	(Instrument = @�ʉ݃y�A) AND 
	(@FromDate <= CloseTime) AND 
	(CloseTime < @ToDate)

-- ScalarSUM����_GrossPL_OpenTime
SELECT
	SUM(GrossPL)
FROM
	T_ClosedTrades
WHERE
	(@FromDate <= OpenTime) AND 
	(OpenTime < @ToDate)


-- ScalarCnt������������Close_����
SELECT
	COUNT(*) as CNT
FROM
	T_ClosedTrades
WHERE
	(@FromDate <= OpenTime) AND  (OpenTime < @ToDate) AND 
	(@FromDate <= CloseTime) AND  (CloseTime < @ToDate)

-- ScalarCnt������������Close_�ʉ݃y�A����
SELECT
	COUNT(*) as CNT
FROM
	T_ClosedTrades
WHERE
	(Instrument = @�ʉ݃y�A) AND 
	(@FromDate <= OpenTime) AND  (OpenTime < @ToDate) AND 
	(@FromDate <= CloseTime) AND  (CloseTime < @ToDate)

-- ScalarSumGrossPL
SELECT
	SUM(GrossPL)
FROM
	T_ClosedTrades
WHERE
	YEAR(CloseTime) = @YEAR AND MONTH(CloseTime) = @MONTH
