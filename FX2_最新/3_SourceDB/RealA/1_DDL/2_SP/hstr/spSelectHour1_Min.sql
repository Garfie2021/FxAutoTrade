USE OANDA_DemoB
GO

DROP PROCEDURE [hstr].[spSelectHour1_Min]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [hstr].[spSelectHour1_Min]
	@通貨ペアNo	tinyint
AS
BEGIN

	SET NOCOUNT ON;

	SELECT TOP 1
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
	FROM [hstr].[tHour1]
	WHERE [通貨ペアNo] = @通貨ペアNo
  	order by [StartDate];

END
GO
