use FX_RealA


DECLARE @通貨ペア int
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
SET @通貨ペア = 0
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


-- ScalarCnt_期間
SELECT            COUNT(*) AS Expr1
FROM              T_ClosedTrades
WHERE             (Instrument = @通貨ペア) AND (CloseTime > @from) AND (CloseTime < @to)


-- ScalarMaxGrossPL
SELECT
	MAX(GrossPL) AS GrossPL
FROM
	T_ClosedTrades
WHERE
	(@開始CloseTime <= CloseTime) AND 
	(CloseTime <= @終了CloseTime) 

-- ScalarMinGrossPL
SELECT            MIN(GrossPL) AS GrossPL
FROM              T_ClosedTrades
WHERE             (CloseTime >= @開始CloseTime) AND (CloseTime <= @終了CloseTime)

-- ScalarSUM差益
SELECT
	SUM(GrossPL)
FROM
	T_ClosedTrades
WHERE
	(@FromDate <= CloseTime) AND 
	(CloseTime < @ToDate)

-- ScalarSUM差益_通貨ペア
SELECT
	SUM(GrossPL)
FROM
	T_ClosedTrades
WHERE
	(Instrument = @通貨ペア) AND 
	(@FromDate <= CloseTime) AND 
	(CloseTime < @ToDate)

-- ScalarSUM期間_GrossPL_OpenTime
SELECT
	SUM(GrossPL)
FROM
	T_ClosedTrades
WHERE
	(@FromDate <= OpenTime) AND 
	(OpenTime < @ToDate)


-- ScalarCnt当日注文当日Close_期間
SELECT
	COUNT(*) as CNT
FROM
	T_ClosedTrades
WHERE
	(@FromDate <= OpenTime) AND  (OpenTime < @ToDate) AND 
	(@FromDate <= CloseTime) AND  (CloseTime < @ToDate)

-- ScalarCnt当日注文当日Close_通貨ペア期間
SELECT
	COUNT(*) as CNT
FROM
	T_ClosedTrades
WHERE
	(Instrument = @通貨ペア) AND 
	(@FromDate <= OpenTime) AND  (OpenTime < @ToDate) AND 
	(@FromDate <= CloseTime) AND  (CloseTime < @ToDate)

-- ScalarSumGrossPL
SELECT
	SUM(GrossPL)
FROM
	T_ClosedTrades
WHERE
	YEAR(CloseTime) = @YEAR AND MONTH(CloseTime) = @MONTH
