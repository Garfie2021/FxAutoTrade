USE [FXCM_DemoA]
GO

DROP PROCEDURE [acv].[spSaveHistory_ClosedTrades_DemoA]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [acv].[spSaveHistory_ClosedTrades_DemoA]
AS
BEGIN

	SET NOCOUNT ON;

	DECLARE @StartDate datetime;

	select @StartDate = MAX([CloseTime])
	from [FXCM_DemoA_ACV].[fxcm].[tClosedTrades]

	if @StartDate is null or @StartDate < 1
	begin

		INSERT INTO [FXCM_DemoA_ACV].[fxcm].[tClosedTrades]
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
		SELECT
			 [TradeID]
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
			,[TradeIDRemain]
		FROM [fxcm].[tClosedTrades]

	end
	else
	begin

		INSERT INTO [FXCM_DemoA_ACV].[fxcm].[tClosedTrades]
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
		SELECT
			 [TradeID]
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
			,[TradeIDRemain]
		FROM [fxcm].[tClosedTrades]
		where [CloseTime] > @StartDate;

	end;

END
GO

