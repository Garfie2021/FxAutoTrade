USE SwapCollect
GO

DROP PROCEDURE [oanda].[spInsertTransaction]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [oanda].[spInsertTransaction]
    @口座No					Int,
    @id						bigint,
    @accountId				int,
    @time					DateTime,
    @type					varchar(50),
    @instrument				varchar(50),
    @side					varchar(50),
    @units					int,
    @price					float,
    @lowerBound				float,
    @upperBound				float,
    @takeProfitPrice		float,
    @stopLossPrice			float,
    @trailingStopLossDistance	float,
    @pl							float,
    @interest					float,
    @accountBalance				float,
    @tradeId					bigint,
    @orderId					bigint,
    @tradeOpened_id				bigint,
    @tradeOpened_units			int,
    @tradeOpened_side			varchar(50),
    @tradeOpened_instrument		varchar(50),
    @tradeOpened_time			varchar(50),
    @tradeOpened_price			float,
    @tradeOpened_takeProfit		float,
    @tradeOpened_stopLoss		float,
    @tradeOpened_trailingStop	int,
    @tradeOpened_trailingAmount	float,
    @tradeReduced_id			bigint,
    @tradeReduced_units			int,
    @tradeReduced_side			varchar(50),
    @tradeReduced_instrument	varchar(50),
    @tradeReduced_time			varchar(50),
    @tradeReduced_price			float,
    @tradeReduced_takeProfit	float,
    @tradeReduced_stopLoss		float,
    @tradeReduced_trailingStop	int,
    @tradeReduced_trailingAmount	float,
    @reason							varchar(50),
    @expiry							varchar(50)
AS
BEGIN

	SET NOCOUNT ON;

	INSERT INTO [oanda].[tTransaction] (
		 口座No,
         [id]
        ,[accountId]
        ,[time]
        ,[type]
        ,[instrument]
        ,[side]
        ,[units]
        ,[price]
        ,[lowerBound]
        ,[upperBound]
        ,[takeProfitPrice]
        ,[stopLossPrice]
        ,[trailingStopLossDistance]
        ,[pl]
        ,[interest]
        ,[accountBalance]
        ,[tradeId]
        ,[orderId]
        ,[tradeOpened_id]
        ,[tradeOpened_units]
        ,[tradeOpened_side]
        ,[tradeOpened_instrument]
        ,[tradeOpened_time]
        ,[tradeOpened_price]
        ,[tradeOpened_takeProfit]
        ,[tradeOpened_stopLoss]
        ,[tradeOpened_trailingStop]
        ,[tradeOpened_trailingAmount]
        ,[tradeReduced_id]
        ,[tradeReduced_units]
        ,[tradeReduced_side]
        ,[tradeReduced_instrument]
        ,[tradeReduced_time]
        ,[tradeReduced_price]
        ,[tradeReduced_takeProfit]
        ,[tradeReduced_stopLoss]
        ,[tradeReduced_trailingStop]
        ,[tradeReduced_trailingAmount]
        ,[reason]
        ,[expiry]
        ,[登録日時]
     ) VALUES (
		@口座No,
		@id,
		@accountId,
		@time,
		@type,
		@instrument,
		@side,
		@units,
		@price,
		@lowerBound,
		@upperBound,
		@takeProfitPrice,
		@stopLossPrice,
		@trailingStopLossDistance,
		@pl,
		@interest,
		@accountBalance,
		@tradeId,
		@orderId,
		@tradeOpened_id,
		@tradeOpened_units,
		@tradeOpened_side,
		@tradeOpened_instrument,
		@tradeOpened_time,
		@tradeOpened_price,
		@tradeOpened_takeProfit,
		@tradeOpened_stopLoss,
		@tradeOpened_trailingStop,
		@tradeOpened_trailingAmount,
		@tradeReduced_id,
		@tradeReduced_units,
		@tradeReduced_side,
		@tradeReduced_instrument,
		@tradeReduced_time,
		@tradeReduced_price,
		@tradeReduced_takeProfit,
		@tradeReduced_stopLoss,
		@tradeReduced_trailingStop,
		@tradeReduced_trailingAmount,
		@reason,
		@expiry,
		GETDATE());

END
GO
