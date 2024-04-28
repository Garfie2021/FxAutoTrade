use FX_RealA


DECLARE @�ʉ݃y�A int
DECLARE @TradeID varchar(100)
DECLARE @Date datetime
DECLARE @�J�nCloseTime datetime
DECLARE @�I��CloseTime datetime
DECLARE @FromDate datetime
DECLARE @ToDate datetime
DECLARE @����� varchar(100)

SET @FromDate = CONVERT(datetime, '2014/01/15 06:00:00')
SET @ToDate = CONVERT(datetime, '2014/01/17 06:00:00')
SET @�I��CloseTime = 0
SET @�J�nCloseTime = 0
SET @Date = 0
SET @�ʉ݃y�A = 0
SET @TradeID = '1'
SET @����� = 'Order��'


-- Fill
SELECT            T_�����ݒ�History2.*
FROM              T_�����ݒ�History2


-- FillBy�|�W�V����_����
SELECT            *
FROM              T_�����ݒ�History2
WHERE             (�ʉ݃y�A = @�ʉ݃y�A) AND 
(Date >= @FromDate) AND 
(Date < @ToDate)
order by Date

-- FillByTop1_����
SELECT            top 1 *
FROM              T_�����ݒ�History2
WHERE             (�ʉ݃y�A = @�ʉ݃y�A) AND 
(Date >= @FromDate) AND 
(Date < @ToDate)
order by Date

-- FillBy_�ʉ݃y�A����
SELECT            *
FROM              T_�����ݒ�History2
WHERE             (�ʉ݃y�A = @�ʉ݃y�A) AND 
(Date >= @FromDate) AND 
(Date < @ToDate)
order by Date

-- ScalarMaxGrossPL���v_�ʉ݃y�A����
SELECT            MAX(GrossPL���v)
FROM              T_�����ݒ�History2
WHERE             (�ʉ݃y�A = @�ʉ݃y�A) AND 
(Date >= @FromDate) AND 
(Date < @ToDate)

-- ScalarMinGrossPL���v_�ʉ݃y�A����
SELECT            MIN(GrossPL���v)
FROM              T_�����ݒ�History2
WHERE             (�ʉ݃y�A = @�ʉ݃y�A) AND 
(Date >= @FromDate) AND 
(Date < @ToDate)


-- ScalarCnt�����_����
SELECT
	COUNT(*) as cnt
FROM
	T_�����ݒ�History2
WHERE
--	(�ʉ݃y�A = @�ʉ݃y�A) AND 
	(@FromDate <= Date) AND (Date < @ToDate) AND 
	(����� like '%' + @����� + '%')
--	(����� like '%Order��%')
