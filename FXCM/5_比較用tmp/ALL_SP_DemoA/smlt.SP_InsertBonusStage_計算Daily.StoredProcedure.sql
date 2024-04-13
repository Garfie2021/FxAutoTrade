USE [RealA_FX]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [smlt].[SP_InsertBonusStage_計算Daily]
AS
BEGIN
	SET NOCOUNT ON;

	declare @EndDate datetime = convert(varchar, YEAR(GETDATE())) + '-' + convert(varchar, MONTH(GETDATE())) + '-' + convert(varchar, DAY(GETDATE())) + ' 06:00:00';
	declare @StartDate datetime = DATEADD(day, -1, @EndDate);

	DECLARE @通貨ペアNo	tinyint = 0;
	WHILE @通貨ペアNo < 44
	BEGIN

		EXECUTE [smlt].[SP_InsertBonusStage] @通貨ペアNo, @StartDate, @EndDate

		SET @通貨ペアNo = @通貨ペアNo + 1;
	END;

END

GO
