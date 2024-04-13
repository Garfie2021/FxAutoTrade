USE OANDA_DemoB
GO

DROP PROCEDURE [oanda].[spInsertTrade_リミット変更]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [oanda].[spInsertTrade_リミット変更]
    @口座No				Int	,
    @リミット変更対象id	BigInt,
    @id					BigInt,
    @units				Int	,
    @side				VarChar(50),
    @instrument			VarChar(50),
    @time				DateTime,
    @price				Float,
    @takeProfit			Float,
    @stopLoss			Float,
    @trailingStop		Int,
    @trailingAmount		Float
AS
BEGIN

	SET NOCOUNT ON;

	INSERT INTO [oanda].[tTrade_リミット変更] (
		口座No,
		日時,
		リミット変更対象id,
		[id],
		[units],
		[side],
		[instrument],
		[time],
		[price],
		[takeProfit],
		[stopLoss],
		[trailingStop],
		[trailingAmount]
     ) VALUES (
		@口座No,
		GETDATE(),
		@リミット変更対象id,
		@id,
		@units,
		@side,
		@instrument,
		@time,
		@price,
		@takeProfit,
		@stopLoss,
		@trailingStop,
		@trailingAmount
	);

END
GO
