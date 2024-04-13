USE [RealA_FX]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[SP_InsertTrades]
	 @TradeID			varchar(100)
	,@AccountID			varchar(100)
	,@AccountName		varchar(100)
	,@OfferID			varchar(100)
	,@Instrument		varchar(100)
	,@Lot				int
	,@AmountK			float
	,@BS				varchar(100)
	,@Open				float
	,@Close				float
	,@Stop				float
	,@UntTrlMove		float
	,@Limit				float
	,@UntTrlMoveLimit	float
	,@PL				float
	,@GrossPL			float
	,@Com				float
	,@Int				float
	,@Time				datetime
	,@IsBuy				tinyint
	,@Kind				varchar(100)
	,@QuoteID			varchar(100)
	,@OpenOrderID		varchar(100)
	,@OpenOrderReqID	varchar(100)
	,@QTXT				varchar(100)
	,@StopOrderID		varchar(100)
	,@LimitOrderID		varchar(100)
	,@TradeIDOrigin		varchar(100)
AS
BEGIN

	SET NOCOUNT ON;


	INSERT INTO [dbo].[T_Trades]
		([TradeID]
		,[AccountID]
		,[AccountName]
		,[OfferID]
		,[Instrument]
		,[Lot]
		,[AmountK]
		,[BS]
		,[Open]
		,[Close]
		,[Stop]
		,[UntTrlMove]
		,[Limit]
		,[UntTrlMoveLimit]
		,[PL]
		,[GrossPL]
		,[Com]
		,[Int]
		,[Time]
		,[IsBuy]
		,[Kind]
		,[QuoteID]
		,[OpenOrderID]
		,[OpenOrderReqID]
		,[QTXT]
		,[StopOrderID]
		,[LimitOrderID]
		,[TradeIDOrigin]
	)VALUES(
		 @TradeID
		,@AccountID
		,@AccountName
		,@OfferID
		,@Instrument
		,@Lot
		,@AmountK
		,@BS
		,@Open
		,@Close
		,@Stop
		,@UntTrlMove
		,@Limit
		,@UntTrlMoveLimit
		,@PL
		,@GrossPL
		,@Com
		,@Int
		,@Time
		,@IsBuy
		,@Kind
		,@QuoteID
		,@OpenOrderID
		,@OpenOrderReqID
		,@QTXT
		,@StopOrderID
		,@LimitOrderID
		,@TradeIDOrigin
	);


END

GO
