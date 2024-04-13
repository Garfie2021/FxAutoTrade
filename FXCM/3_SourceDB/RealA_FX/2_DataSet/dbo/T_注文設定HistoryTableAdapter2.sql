use FX_RealA


DECLARE @通貨ペア int
DECLARE @TradeID varchar(100)
DECLARE @Date datetime
DECLARE @開始CloseTime datetime
DECLARE @終了CloseTime datetime
DECLARE @FromDate datetime
DECLARE @ToDate datetime
DECLARE @取引状況 varchar(100)

SET @FromDate = CONVERT(datetime, '2014/01/15 06:00:00')
SET @ToDate = CONVERT(datetime, '2014/01/17 06:00:00')
SET @終了CloseTime = 0
SET @開始CloseTime = 0
SET @Date = 0
SET @通貨ペア = 0
SET @TradeID = '1'
SET @取引状況 = 'Order中'


-- Fill
SELECT            T_注文設定History2.*
FROM              T_注文設定History2


-- FillByポジション_期間
SELECT            *
FROM              T_注文設定History2
WHERE             (通貨ペア = @通貨ペア) AND 
(Date >= @FromDate) AND 
(Date < @ToDate)
order by Date

-- FillByTop1_期間
SELECT            top 1 *
FROM              T_注文設定History2
WHERE             (通貨ペア = @通貨ペア) AND 
(Date >= @FromDate) AND 
(Date < @ToDate)
order by Date

-- FillBy_通貨ペア期間
SELECT            *
FROM              T_注文設定History2
WHERE             (通貨ペア = @通貨ペア) AND 
(Date >= @FromDate) AND 
(Date < @ToDate)
order by Date

-- ScalarMaxGrossPL小計_通貨ペア期間
SELECT            MAX(GrossPL小計)
FROM              T_注文設定History2
WHERE             (通貨ペア = @通貨ペア) AND 
(Date >= @FromDate) AND 
(Date < @ToDate)

-- ScalarMinGrossPL小計_通貨ペア期間
SELECT            MIN(GrossPL小計)
FROM              T_注文設定History2
WHERE             (通貨ペア = @通貨ペア) AND 
(Date >= @FromDate) AND 
(Date < @ToDate)


-- ScalarCnt取引状況_期間
SELECT
	COUNT(*) as cnt
FROM
	T_注文設定History2
WHERE
--	(通貨ペア = @通貨ペア) AND 
	(@FromDate <= Date) AND (Date < @ToDate) AND 
	(取引状況 like '%' + @取引状況 + '%')
--	(取引状況 like '%Order中%')
