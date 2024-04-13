USE [FX2_Demo]
GO

DROP PROCEDURE [rate].[spInsertRateHistory]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [rate].[spInsertRateHistory]
	 @通貨ペアNo tinyint
	,@StartDate datetime
	,@買いRate float
	,@売りRate float
AS
BEGIN

	SET NOCOUNT ON;

	INSERT INTO [rate].[tRateHistory] (
		[通貨ペアNo],
		[StartDate],
		[買いRate],
		[売りRate]
	) VALUES (
		@通貨ペアNo,
		@StartDate,
		@買いRate,
		@売りRate
	);

END
GO
