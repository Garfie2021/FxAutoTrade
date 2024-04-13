use FX_RealA

DECLARE @通貨ペア int
DECLARE @ペア名 varchar(100)
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
SET @ペア名 = '1'

-- Fill
SELECT            T_通貨ペアMst.*
FROM              T_通貨ペアMst


-- DeleteAll
DELETE FROM T_通貨ペアMst


-- ScalarNo
SELECT            No
FROM              T_通貨ペアMst
WHERE             (ペア名 = @ペア名)