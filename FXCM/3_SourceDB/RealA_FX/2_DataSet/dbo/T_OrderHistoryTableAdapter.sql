use FX_RealA


DECLARE @通貨ペアNo int
DECLARE @TradeID varchar(100)
DECLARE @Date datetime
DECLARE @開始CloseTime datetime
DECLARE @終了CloseTime datetime
DECLARE @FromDate datetime
DECLARE @ToDate datetime
DECLARE @From datetime
DECLARE @To datetime
DECLARE @Close区分 varchar(100)
SET @FromDate = CONVERT(datetime, '2013/08/13 06:00:00')
SET @ToDate = CONVERT(datetime, '2013/08/14 06:00:00')
SET @From = CONVERT(datetime, '2013/08/13 06:00:00')
SET @To = CONVERT(datetime, '2013/08/14 06:00:00')
SET @終了CloseTime = 0
SET @開始CloseTime = 0
SET @Date = 0
SET @通貨ペアNo = 0
SET @TradeID = '1'
SET @Close区分 = 'ADX'



-- Fill
SELECT            T_OrderHistory.*
FROM              T_OrderHistory


-- ScalarLastOrder未クローズ
SELECT            
	TOP 1 売買モード
FROM              
	dbo.T_OrderHistory
WHERE             
	(通貨ペアNo = @通貨ペアNo) and (Close済み = 0)	--未クローズのOrderのみチェック
order by
	日時 desc


-- Updateクローズ_通貨ペア
UPDATE
	dbo.T_OrderHistory
SET
	Close済み = 1,
	Close区分 = @Close区分
WHERE
	通貨ペアNo = @通貨ペアNo

