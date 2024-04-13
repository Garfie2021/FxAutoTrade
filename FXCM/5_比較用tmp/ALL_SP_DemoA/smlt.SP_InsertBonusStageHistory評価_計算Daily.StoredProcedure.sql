USE [RealA_FX]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [smlt].[SP_InsertBonusStageHistory評価_計算Daily]
AS
BEGIN

	SET NOCOUNT ON;

	declare @LastDate datetime = convert(varchar, YEAR(GETDATE())) + '-' + convert(varchar, MONTH(GETDATE())) + '-' + convert(varchar, DAY(GETDATE())) + ' 06:00:00';
	declare @StartDate datetime = DATEADD(day, -1, @LastDate);
	declare @年月日 date = convert(varchar, YEAR(GETDATE())) + '-' + convert(varchar, MONTH(GETDATE())) + '-' + convert(varchar, DAY(GETDATE()));

	declare @EndDate datetime;
	WHILE @StartDate < @LastDate
	BEGIN

		SET @EndDate = DATEADD(day, 1, @StartDate)

		declare @通貨ペアNo tinyint = 0;
		WHILE @通貨ペアNo < 44
		BEGIN

			declare @シグマ閾値 float = 1.0;
			WHILE @シグマ閾値 < 4.5
			BEGIN

				/*
				declare @通貨ペアNo tinyint = 2;
				declare @シグマ閾値 float = 1;
				declare @年月日 datetime = '2014-05-15';
				declare @StartDate datetime = '2014-05-15 20:00:00';
				declare @EndDate datetime = '2014-05-16 00:00:00';
				*/
				EXECUTE [smlt].[SP_InsertBonusStageHistory評価] @通貨ペアNo, @シグマ閾値, @年月日, @StartDate, @EndDate;

				SET @シグマ閾値 = @シグマ閾値 + 0.5;
			END;

			SET @通貨ペアNo = @通貨ペアNo + 1;
		END;

		SET @年月日 = DATEADD(day, 1, @年月日);
		SET @StartDate = @EndDate;

	END;

END

GO
