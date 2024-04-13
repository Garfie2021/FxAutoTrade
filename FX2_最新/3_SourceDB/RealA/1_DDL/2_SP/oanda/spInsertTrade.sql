USE OANDA_DemoB
GO

DROP PROCEDURE [oanda].[spInsertTrade]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [oanda].[spInsertTrade]
    @口座No			Int,
    @id				BigInt,
    @units			Int,
    @side			VarChar(50),
    @instrument		VarChar(50),
    @time			DateTime,
    @price			Float,
    @takeProfit		Float,
    @stopLoss		Float,
    @trailingStop	Int,
    @trailingAmount	Float
AS
BEGIN

	SET NOCOUNT ON;

	DECLARE @Cnt int = (
		SELECT COUNT([id])  
		FROM [oanda].[tTrade] 
		WHERE 口座No = @口座No AND [id] = @id
	);
	
	IF @Cnt > 0
	BEGIN
		RETURN;
	END;

	INSERT INTO [oanda].[tTrade] (
		口座No,
		[id],
		[units],
		[side],
		[instrument],
		[time],
		[price],
		[takeProfit],
		[stopLoss],
		[trailingStop],
		[trailingAmount],
		[登録日時]
     ) VALUES (
		@口座No,
		@id,
		@units,
		@side,
		@instrument,
		@time,
		@price,
		@takeProfit,
		@stopLoss,
		@trailingStop,
		@trailingAmount,
		GETDATE()
	);

END
GO
