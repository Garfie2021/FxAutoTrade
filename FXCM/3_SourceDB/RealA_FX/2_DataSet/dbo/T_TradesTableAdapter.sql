use FX_RealA

DECLARE @通貨ペアNo int
DECLARE @通貨ペア varchar(100)
DECLARE @TradeID varchar(100)
DECLARE @Date datetime
DECLARE @開始CloseTime datetime
DECLARE @終了CloseTime datetime
DECLARE @to1週間後 datetime
DECLARE @FromDate datetime
DECLARE @ToDate datetime
DECLARE @From datetime
DECLARE @To datetime
SET @FromDate = CONVERT(datetime, '2013/08/13 06:00:00')
SET @ToDate = CONVERT(datetime, '2013/08/14 06:00:00')
SET @From = CONVERT(datetime, '2013/08/13 06:00:00')
SET @To = CONVERT(datetime, '2013/08/14 06:00:00')
SET @to1週間後 = CONVERT(datetime, '2013/08/14 06:00:00')
SET @終了CloseTime = 0
SET @開始CloseTime = 0
SET @Date = 0
SET @通貨ペアNo = 0
SET @通貨ペア = ''
SET @TradeID = '1'


-- Fill
SELECT            T_Trades.*
FROM              T_Trades


-- FillBy
SELECT            TradeID, AccountID, AccountName, OfferID, Instrument, Lot, AmountK, BS, [Open], [Close], Stop, UntTrlMove, Limit, UntTrlMoveLimit, PL, GrossPL, Com, Int, Time, IsBuy, Kind, 
                        QuoteID, OpenOrderID, OpenOrderReqID, QTXT, StopOrderID, LimitOrderID, TradeIDOrigin
FROM              T_Trades
WHERE             (Instrument = @通貨ペア)
ORDER BY       Time DESC


-- FillBy期間
SELECT *
FROM              T_Trades
WHERE             (Instrument = @通貨ペア) and @from < Time and Time < @to

-- ScalarCnt
SELECT            COUNT(*) AS CNT
FROM              T_Trades
WHERE             (TradeID = @TradeID)

-- ScalarCnt通貨期間
SELECT
count(*)
FROM              T_Trades
WHERE             (Instrument = @通貨ペア) and
@from < Time and Time < @to

-- ScalarSum期間
SELECT
SUM(AmountK)
FROM              T_Trades
WHERE             @from < Time and Time < @to

-- ScalarSum期間_残Order
SELECT SUM([AmountK])
FROM [dbo].[T_Trades]
where TradeID not in(select TradeID from [dbo].[T_ClosedTrades] where @from < CloseTime)
and @from < Time and Time < @to

-- ScalarSum期間_残Order_1週間でClose
SELECT SUM([AmountK])
FROM [dbo].[T_Trades]
where TradeID in(select TradeID from [dbo].[T_ClosedTrades] where @from < CloseTime and CloseTime < @to1週間後)
and @from < Time and Time < @to

-- ScalarMaxOpen
SELECT            MAX([Open]) AS Expr1
FROM              T_Trades
WHERE             (Instrument = @通貨ペア)


-- ScalarMinOpen
SELECT           MIN([Open])
FROM              T_Trades
WHERe      Instrument=@通貨ペア

