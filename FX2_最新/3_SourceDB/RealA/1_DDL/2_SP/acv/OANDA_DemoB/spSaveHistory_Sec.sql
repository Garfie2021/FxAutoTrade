USE [OANDA_DemoB]
GO

DROP PROCEDURE [acv].[spSaveHistory_Sec]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [acv].[spSaveHistory_Sec]
AS
BEGIN

	SET NOCOUNT ON;


	DECLARE @StartDate datetime;
	declare @通貨ペアNo tinyint = 0;
	DECLARE @通貨ペアNoMax tinyint = (SELECT MAX(No) from [cmn].[t通貨ペアMst]);

	while @通貨ペアNo <= @通貨ペアNoMax
	begin

		select @StartDate = MAX([StartDate])
		from [OANDA_DemoB_ACV].[hstr].[tSec]
		where [通貨ペアNo] = @通貨ペアNo

		--select @StartDate

		if @StartDate is null or @StartDate < 1
		begin

			--select 'A', @通貨ペアNo

			INSERT INTO [OANDA_DemoB_ACV].[hstr].[tSec]
				([通貨ペアNo]
				,[StartDate]
				,[買いSwap]
				,[買いRate]
				,[売りSwap]
				,[売りRate])
			SELECT 
				 [通貨ペアNo]
				,[StartDate]
				,[買いSwap]
				,[買いRate]
				,[売りSwap]
				,[売りRate]
			FROM [OANDA_DemoB].[hstr].[tSec]
			where [通貨ペアNo] = @通貨ペアNo;

		end
		else
		begin

			--select 'B', @通貨ペアNo

			INSERT INTO [OANDA_DemoB_ACV].[hstr].[tSec]
				([通貨ペアNo]
				,[StartDate]
				,[買いSwap]
				,[買いRate]
				,[売りSwap]
				,[売りRate])
			SELECT 
				 [通貨ペアNo]
				,[StartDate]
				,[買いSwap]
				,[買いRate]
				,[売りSwap]
				,[売りRate]
			FROM [OANDA_DemoB].[hstr].[tSec]
			where [通貨ペアNo] = @通貨ペアNo and [StartDate] > @StartDate;

		end;

		Set @通貨ペアNo = @通貨ペアNo + 1;
	end;

END
GO

