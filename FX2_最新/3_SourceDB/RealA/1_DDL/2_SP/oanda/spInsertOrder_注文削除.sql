USE OANDA_DemoB
GO

DROP PROCEDURE [oanda].[spInsertOrder_注文削除]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [oanda].[spInsertOrder_注文削除]
    @口座No			Int,
    @注文削除対象id	BigInt,
    @id				BigInt,
    @instrument		VarChar(50),
    @units			Int	,
    @side			VarChar(50),
	@type			VarChar(50),
    @time			DateTime,
    @price			Float,
    @takeProfit		Float,
    @stopLoss		Float,
	@expiry			VarChar(50),
	@upperBound		Float,
	@lowerBound		Float,
    @trailingStop	Int
AS
BEGIN

	SET NOCOUNT ON;

	INSERT INTO [oanda].[tOrder_注文削除] (
		口座No,
		[日時],
		[注文削除対象id],
		[id],
		[instrument],
		[units],
		[side],
		[type],
		[time],
		[price],
		[takeProfit],
		[stopLoss],
		[expiry],
		[upperBound],
		[lowerBound],
		[trailingStop]
     ) VALUES (
		@口座No,
		GETDATE(),
		@注文削除対象id,
		@id,
		@instrument,
		@units,
		@side,
		@type,
		@time,
		@price,
		@takeProfit,
		@stopLoss,
		@expiry,
		@upperBound,
		@lowerBound,
		@trailingStop
	);

END
GO
