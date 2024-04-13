USE OANDA_DemoB
GO

DROP PROCEDURE [oanda].[spSelectマイナスInstrument]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [oanda].[spSelectマイナスInstrument]
    @口座No	Int,
	@from	DateTime,
	@to		DateTime
AS
BEGIN

	SELECT
		 [id]
		,[time]
		,[instrument]
		,[interest]
	FROM
		[oanda].[tTransaction]
	where
		口座No = @口座No AND 
		@from <= [time] and [time] < @to AND 
		[Type] = 'DAILY_INTEREST' AND interest < 0;

END
GO

