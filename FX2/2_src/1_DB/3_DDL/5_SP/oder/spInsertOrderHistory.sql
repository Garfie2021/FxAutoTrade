USE [FX2_Demo]
GO

DROP PROCEDURE [oder].[spInsertOrderHistory]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [oder].[spInsertOrderHistory]
	 @通貨ペアNo	tinyint
	,@OrderDate		datetime
	,@売買判定		tinyint
	,@買いRate		float
	,@売りRate		float
	,@注文数		tinyint
	,@Close予定Date	datetime
	,@OpenOrderID	varchar(50)
AS
BEGIN

	SET NOCOUNT ON;

	INSERT INTO [oder].[tOrderHistory] 
        ([通貨ペアNo]
        ,[OrderDate]
        ,[売買判定]
        ,[買いRate]
        ,[売りRate]
        ,[注文数]
        ,[Close予定Date]
        ,[OpenOrderID]
	) VALUES (
		 @通貨ペアNo
		,@OrderDate
		,@売買判定
		,@買いRate
		,@売りRate
		,@注文数
		,@Close予定Date
		,@OpenOrderID
	);


END
GO
