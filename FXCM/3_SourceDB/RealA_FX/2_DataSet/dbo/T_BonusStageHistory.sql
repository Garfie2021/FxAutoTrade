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
SELECT            T_BonusStageHistory.*
FROM              T_BonusStageHistory


-- Delete�ʉ݃y�A����
delete FROM T_BonusStageHistory
WHERE (�ʉ݃y�ANo = @�ʉ݃y�ANo) AND (@FromDate <= ����) AND (���� <= @ToDate)

