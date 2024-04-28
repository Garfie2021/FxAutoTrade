use FX_RealA

DECLARE @�ʉ݃y�ANo int
DECLARE @�ʉ݃y�A varchar(100)
DECLARE @TradeID varchar(100)
DECLARE @Date datetime
DECLARE @�J�nCloseTime datetime
DECLARE @�I��CloseTime datetime
DECLARE @to1�T�Ԍ� datetime
DECLARE @FromDate datetime
DECLARE @ToDate datetime
DECLARE @From datetime
DECLARE @To datetime
SET @FromDate = CONVERT(datetime, '2013/08/13 06:00:00')
SET @ToDate = CONVERT(datetime, '2013/08/14 06:00:00')
SET @From = CONVERT(datetime, '2013/08/13 06:00:00')
SET @To = CONVERT(datetime, '2013/08/14 06:00:00')
SET @to1�T�Ԍ� = CONVERT(datetime, '2013/08/14 06:00:00')
SET @�I��CloseTime = 0
SET @�J�nCloseTime = 0
SET @Date = 0
SET @�ʉ݃y�ANo = 0
SET @�ʉ݃y�A = ''
SET @TradeID = '1'


-- Fill
SELECT            T_Trades.*
FROM              T_Trades


-- FillBy
SELECT            TradeID, AccountID, AccountName, OfferID, Instrument, Lot, AmountK, BS, [Open], [Close], Stop, UntTrlMove, Limit, UntTrlMoveLimit, PL, GrossPL, Com, Int, Time, IsBuy, Kind, 
                        QuoteID, OpenOrderID, OpenOrderReqID, QTXT, StopOrderID, LimitOrderID, TradeIDOrigin
FROM              T_Trades
WHERE             (Instrument = @�ʉ݃y�A)
ORDER BY       Time DESC


-- FillBy����
SELECT *
FROM              T_Trades
WHERE             (Instrument = @�ʉ݃y�A) and @from < Time and Time < @to

-- ScalarCnt
SELECT            COUNT(*) AS CNT
FROM              T_Trades
WHERE             (TradeID = @TradeID)

-- ScalarCnt�ʉ݊���
SELECT
count(*)
FROM              T_Trades
WHERE             (Instrument = @�ʉ݃y�A) and
@from < Time and Time < @to

-- ScalarSum����
SELECT
SUM(AmountK)
FROM              T_Trades
WHERE             @from < Time and Time < @to

-- ScalarSum����_�cOrder
SELECT SUM([AmountK])
FROM [dbo].[T_Trades]
where TradeID not in(select TradeID from [dbo].[T_ClosedTrades] where @from < CloseTime)
and @from < Time and Time < @to

-- ScalarSum����_�cOrder_1�T�Ԃ�Close
SELECT SUM([AmountK])
FROM [dbo].[T_Trades]
where TradeID in(select TradeID from [dbo].[T_ClosedTrades] where @from < CloseTime and CloseTime < @to1�T�Ԍ�)
and @from < Time and Time < @to

-- ScalarMaxOpen
SELECT            MAX([Open]) AS Expr1
FROM              T_Trades
WHERE             (Instrument = @�ʉ݃y�A)


-- ScalarMinOpen
SELECT           MIN([Open])
FROM              T_Trades
WHERe      Instrument=@�ʉ݃y�A

