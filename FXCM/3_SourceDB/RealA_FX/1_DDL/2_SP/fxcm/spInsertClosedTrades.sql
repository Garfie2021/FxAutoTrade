USE [DemoA_FX]
GO

DROP PROCEDURE [fxcm].[spInsertClosedTrades]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [fxcm].[spInsertClosedTrades]
	@TradeID		varchar(100),
	@AccountID		varchar(100),
	@AccountName	varchar(100),
	@OfferID		varchar(100),
	@Instrument		varchar(100),
	@Lot			int,
	@AmountK		float,
	@BS				varchar(100),
	@Open			float,
	@Close			float,
	@PL				float,
	@GrossPL		float,
	@Com			float,
	@Int			float,
	@OpenTime		datetime,
	@CloseTime		datetime,
	@Kind			varchar(100),
	@OpenOrderID	varchar(100),
	@OpenOrderReqID	varchar(100),
	@CloseOrderID	varchar(100),
	@CloseOrderReqID	varchar(100),
	@OQTXT				varchar(100),
	@CQTXT				varchar(100),
	@TradeIDOrigin		varchar(100),
	@TradeIDRemain		varchar(100)
AS
BEGIN

	SET NOCOUNT ON;

	INSERT INTO [fxcm].[tClosedTrades]
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
		,[PL]
		,[GrossPL]
		,[Com]
		,[Int]
		,[OpenTime]
		,[CloseTime]
		,[Kind]
		,[OpenOrderID]
		,[OpenOrderReqID]
		,[CloseOrderID]
		,[CloseOrderReqID]
		,[OQTXT]
		,[CQTXT]
		,[TradeIDOrigin]
		,[TradeIDRemain])
	VALUES
		(@TradeID
		,@AccountID
		,@AccountName
		,@OfferID
		,@Instrument
		,@Lot
		,@AmountK
		,@BS
		,@Open
		,@Close
		,@PL
		,@GrossPL
		,@Com
		,@Int
		,@OpenTime
		,@CloseTime
		,@Kind
		,@OpenOrderID
		,@OpenOrderReqID
		,@CloseOrderID
		,@CloseOrderReqID
		,@OQTXT
		,@CQTXT
		,@TradeIDOrigin
		,@TradeIDRemain);

END
GO
