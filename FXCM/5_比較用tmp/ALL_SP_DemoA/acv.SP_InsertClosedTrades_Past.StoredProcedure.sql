USE [RealA_FX]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [acv].[SP_InsertClosedTrades_Past]
AS
BEGIN

	SET NOCOUNT ON;

	DECLARE @StartDate datetime;

	select @StartDate = MAX([CloseTime])
	from [acv].[T_ClosedTrades_Past]

	if @StartDate is null or @StartDate < 1
	begin

		INSERT INTO [acv].[T_ClosedTrades_Past]
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
		FROM [dbo].[T_ClosedTrades]

	end
	else
	begin

		INSERT INTO [acv].[T_ClosedTrades_Past]
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
		FROM [dbo].[T_ClosedTrades]
		where [CloseTime] > @StartDate;

	end;

END

GO
