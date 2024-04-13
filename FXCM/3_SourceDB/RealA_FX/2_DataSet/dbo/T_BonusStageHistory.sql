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
SELECT            T_BonusStageHistory.*
FROM              T_BonusStageHistory


-- Delete通貨ペア期間
delete FROM T_BonusStageHistory
WHERE (通貨ペアNo = @通貨ペアNo) AND (@FromDate <= 日時) AND (日時 <= @ToDate)

