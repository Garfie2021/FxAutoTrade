use FX_RealA


DECLARE @�ʉ݃y�ANo int
DECLARE @TradeID varchar(100)
DECLARE @Date datetime
DECLARE @�J�nCloseTime datetime
DECLARE @�I��CloseTime datetime
DECLARE @FromDate datetime
DECLARE @ToDate datetime
DECLARE @From datetime
DECLARE @To datetime
DECLARE @Close�敪 varchar(100)
SET @FromDate = CONVERT(datetime, '2013/08/13 06:00:00')
SET @ToDate = CONVERT(datetime, '2013/08/14 06:00:00')
SET @From = CONVERT(datetime, '2013/08/13 06:00:00')
SET @To = CONVERT(datetime, '2013/08/14 06:00:00')
SET @�I��CloseTime = 0
SET @�J�nCloseTime = 0
SET @Date = 0
SET @�ʉ݃y�ANo = 0
SET @TradeID = '1'
SET @Close�敪 = 'ADX'



-- Fill
SELECT            T_OrderHistory.*
FROM              T_OrderHistory


-- ScalarLastOrder���N���[�Y
SELECT            
	TOP 1 �������[�h
FROM              
	dbo.T_OrderHistory
WHERE             
	(�ʉ݃y�ANo = @�ʉ݃y�ANo) and (Close�ς� = 0)	--���N���[�Y��Order�̂݃`�F�b�N
order by
	���� desc


-- Update�N���[�Y_�ʉ݃y�A
UPDATE
	dbo.T_OrderHistory
SET
	Close�ς� = 1,
	Close�敪 = @Close�敪
WHERE
	�ʉ݃y�ANo = @�ʉ݃y�ANo

