USE OANDA_DemoB
GO

DROP PROCEDURE [oanda].[spDeleteTradeResponse]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [oanda].[spDeleteTradeResponse]
    @口座No			Int,
	@id			BigInt,
	@price		Float,
	@instrument	varchar(50),
	@profit		Float,
	@side		VarChar(50),
	@time		DateTime
AS
BEGIN

	SET NOCOUNT ON;

	INSERT INTO [oanda].[tDeleteTradeResponse](
		口座No,
		[id],
		[price],
		[instrument],
		[profit],
		[side],
		[time]
    ) VALUES (
		@口座No,
		@id,
		@price,
		@instrument,
		@profit,
		@side,
		@time
	);

END
GO
