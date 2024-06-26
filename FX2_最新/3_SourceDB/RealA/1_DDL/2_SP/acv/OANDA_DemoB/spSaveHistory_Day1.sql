USE [OANDA_DemoB]
GO

DROP PROCEDURE [acv].[spSaveHistory_Day1]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [acv].[spSaveHistory_Day1]
AS
BEGIN

	SET NOCOUNT ON;


	DECLARE @StartDate datetime;
	declare @通貨ペアNo tinyint = 0;
	DECLARE @通貨ペアNoMax tinyint = (SELECT MAX(No) from [cmn].[t通貨ペアMst]);

	while @通貨ペアNo <= @通貨ペアNoMax
	begin

		select @StartDate = MAX([StartDate])
		from [OANDA_DemoB_ACV].[hstr].[tDay1]
		where [通貨ペアNo] = @通貨ペアNo

		if @StartDate is null or @StartDate < 1
		begin

			INSERT INTO [OANDA_DemoB_ACV].[hstr].[tDay1]
			   ([通貨ペアNo]
			   ,[StartDate]
			   ,[買いSwap]
			   ,[買いRate_始値]
			   ,[買いRate_高値]
			   ,[買いRate_安値]
			   ,[買いRate_終値]
			   ,[買いWMAs2]
			   ,[買いWMAs2角度]
			   ,[買いWMAs2角度シグマ]
			   ,[買いWMAs2角度持続時間]
			   ,[買いWMAs2角度持続Rate]
			   ,[買いWMAs14]
			   ,[買いWMAs14角度]
			   ,[買いWMAs14角度シグマ]
			   ,[買いWMAs14角度持続時間]
			   ,[買いWMAs14角度持続Rate]
			   ,[売りSwap]
			   ,[売りRate_始値]
			   ,[売りRate_高値]
			   ,[売りRate_安値]
			   ,[売りRate_終値]
			   ,[売りWMAs2]
			   ,[売りWMAs2角度]
			   ,[売りWMAs2角度シグマ]
			   ,[売りWMAs2角度持続時間]
			   ,[売りWMAs2角度持続Rate]
			   ,[売りWMAs14]
			   ,[売りWMAs14角度]
			   ,[売りWMAs14角度シグマ]
			   ,[売りWMAs14角度持続時間]
			   ,[売りWMAs14角度持続Rate]
			   ,[登録日時]
			   ,[更新日時])
			SELECT 
				 [通貨ペアNo]
				,[StartDate]
				,[買いSwap]
				,[買いRate_始値]
				,[買いRate_高値]
				,[買いRate_安値]
				,[買いRate_終値]
				,[買いWMAs2]
				,[買いWMAs2角度]
				,[買いWMAs2角度シグマ]
				,[買いWMAs2角度持続時間]
				,[買いWMAs2角度持続Rate]
				,[買いWMAs14]
				,[買いWMAs14角度]
				,[買いWMAs14角度シグマ]
				,[買いWMAs14角度持続時間]
				,[買いWMAs14角度持続Rate]
				,[売りSwap]
				,[売りRate_始値]
				,[売りRate_高値]
				,[売りRate_安値]
				,[売りRate_終値]
				,[売りWMAs2]
				,[売りWMAs2角度]
				,[売りWMAs2角度シグマ]
				,[売りWMAs2角度持続時間]
				,[売りWMAs2角度持続Rate]
				,[売りWMAs14]
				,[売りWMAs14角度]
				,[売りWMAs14角度シグマ]
				,[売りWMAs14角度持続時間]
				,[売りWMAs14角度持続Rate]
				,[登録日時]
				,[更新日時]
			FROM [OANDA_DemoB].[hstr].[tDay1]
			where [通貨ペアNo] = @通貨ペアNo;

		end
		else
		begin

			INSERT INTO [OANDA_DemoB_ACV].[hstr].[tDay1]
			   ([通貨ペアNo]
			   ,[StartDate]
			   ,[買いSwap]
			   ,[買いRate_始値]
			   ,[買いRate_高値]
			   ,[買いRate_安値]
			   ,[買いRate_終値]
			   ,[買いWMAs2]
			   ,[買いWMAs2角度]
			   ,[買いWMAs2角度シグマ]
			   ,[買いWMAs2角度持続時間]
			   ,[買いWMAs2角度持続Rate]
			   ,[買いWMAs14]
			   ,[買いWMAs14角度]
			   ,[買いWMAs14角度シグマ]
			   ,[買いWMAs14角度持続時間]
			   ,[買いWMAs14角度持続Rate]
			   ,[売りSwap]
			   ,[売りRate_始値]
			   ,[売りRate_高値]
			   ,[売りRate_安値]
			   ,[売りRate_終値]
			   ,[売りWMAs2]
			   ,[売りWMAs2角度]
			   ,[売りWMAs2角度シグマ]
			   ,[売りWMAs2角度持続時間]
			   ,[売りWMAs2角度持続Rate]
			   ,[売りWMAs14]
			   ,[売りWMAs14角度]
			   ,[売りWMAs14角度シグマ]
			   ,[売りWMAs14角度持続時間]
			   ,[売りWMAs14角度持続Rate]
			   ,[登録日時]
			   ,[更新日時])
			SELECT 
				 [通貨ペアNo]
				,[StartDate]
				,[買いSwap]
				,[買いRate_始値]
				,[買いRate_高値]
				,[買いRate_安値]
				,[買いRate_終値]
				,[買いWMAs2]
				,[買いWMAs2角度]
				,[買いWMAs2角度シグマ]
				,[買いWMAs2角度持続時間]
				,[買いWMAs2角度持続Rate]
				,[買いWMAs14]
				,[買いWMAs14角度]
				,[買いWMAs14角度シグマ]
				,[買いWMAs14角度持続時間]
				,[買いWMAs14角度持続Rate]
				,[売りSwap]
				,[売りRate_始値]
				,[売りRate_高値]
				,[売りRate_安値]
				,[売りRate_終値]
				,[売りWMAs2]
				,[売りWMAs2角度]
				,[売りWMAs2角度シグマ]
				,[売りWMAs2角度持続時間]
				,[売りWMAs2角度持続Rate]
				,[売りWMAs14]
				,[売りWMAs14角度]
				,[売りWMAs14角度シグマ]
				,[売りWMAs14角度持続時間]
				,[売りWMAs14角度持続Rate]
				,[登録日時]
				,[更新日時]
			FROM [OANDA_DemoB].[hstr].[tDay1]
			where [通貨ペアNo] = @通貨ペアNo and [StartDate] > @StartDate;
		end;

		Set @通貨ペアNo = @通貨ペアNo + 1;
	end;

END
GO

