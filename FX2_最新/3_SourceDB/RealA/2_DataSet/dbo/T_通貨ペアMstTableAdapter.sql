use FX_RealA

DECLARE @�ʉ݃y�A int
DECLARE @�y�A�� varchar(100)
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
SET @�y�A�� = '1'

-- Fill
SELECT            T_�ʉ݃y�AMst.*
FROM              T_�ʉ݃y�AMst


-- DeleteAll
DELETE FROM T_�ʉ݃y�AMst


-- ScalarNo
SELECT            No
FROM              T_�ʉ݃y�AMst
WHERE             (�y�A�� = @�y�A��)