USE [RealA_FX]
GO

DROP PROCEDURE [acv].[spSaveHistory_Sec_RealA]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [acv].[spSaveHistory_Sec_RealA]
AS
BEGIN

	SET NOCOUNT ON;

	DECLARE @StartDate datetime;
	declare @通貨ペアNo tinyint = 0;

	while @通貨ペアNo < 44
	begin

		select @StartDate = MAX([StartDate])
		from [RealA_FX_ACV].[hstr].[tSec]
		where [通貨ペアNo] = @通貨ペアNo

		--select @StartDate

		if @StartDate is null or @StartDate < 1
		begin

			--select 'A', @通貨ペアNo

			INSERT INTO [RealA_FX_ACV].[hstr].[tSec]
				([通貨ペアNo]
				,[StartDate]
				,[買いSwap]
				,[買いRate]
				,[売りSwap]
				,[売りRate]
				,[登録日時])
			SELECT 
				 [通貨ペアNo]
				,[StartDate]
				,[買いSwap]
				,[買いRate]
				,[売りSwap]
				,[売りRate]
				,[登録日時]
			FROM [RealA_FX].[hstr].[tSec]
			where [通貨ペアNo] = @通貨ペアNo;

		end
		else
		begin

			--select 'B', @通貨ペアNo

			INSERT INTO [RealA_FX_ACV].[hstr].[tSec]
				([通貨ペアNo]
				,[StartDate]
				,[買いSwap]
				,[買いRate]
				,[売りSwap]
				,[売りRate]
				,[登録日時])
			SELECT 
				 [通貨ペアNo]
				,[StartDate]
				,[買いSwap]
				,[買いRate]
				,[売りSwap]
				,[売りRate]
				,[登録日時]
			FROM [RealA_FX].[hstr].[tSec]
			where [通貨ペアNo] = @通貨ペアNo and [StartDate] > @StartDate;

		end;

		Set @通貨ペアNo = @通貨ペアNo + 1;
	end;

END
GO

