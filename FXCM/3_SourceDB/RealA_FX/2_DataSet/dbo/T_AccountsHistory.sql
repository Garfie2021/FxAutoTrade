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
SELECT            T_AccountsHistory.*
FROM              T_AccountsHistory


-- FillBy期間
SELECT            T_AccountsHistory.*
FROM              T_AccountsHistory
WHERE             (@FromDate < 日時) AND (日時 < @ToDate)


SELECT TOP 1
	[Balance]
FROM
	[dbo].[T_AccountsHistory]
WHERE
	(@FromDate < 日時)
ORDER BY
	日時 DESC

