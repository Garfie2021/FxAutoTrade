USE [RealA_FX]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [smlt].[SP_InsertBonusStage_再計算]
AS
BEGIN
	SET NOCOUNT ON;

	DECLARE @通貨ペアNo	tinyint = 28;
	DECLARE @StartDate DateTime = '2014-05-01 00:00:00';
	DECLARE @EndDate DateTime = '2014-05-24 06:00:00';

	WHILE @通貨ペアNo < 44
	BEGIN

		EXECUTE [smlt].[SP_InsertBonusStage] @通貨ペアNo, @StartDate, @EndDate

		SET @通貨ペアNo = @通貨ペアNo + 1;
	END;

END

GO
