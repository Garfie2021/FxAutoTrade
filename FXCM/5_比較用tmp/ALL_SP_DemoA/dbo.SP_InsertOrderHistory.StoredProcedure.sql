USE [RealA_FX]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[SP_InsertOrderHistory]
	 @通貨ペアNo tinyint
	,@日時 datetime
	,@売買モード varchar(5)
	,@Close済み tinyint
	,@Rate_買い float
	,@Rate_売り float
	,@Close区分 varchar(50)
	,@BonusStage varchar(1)
	,@注文単位 tinyint
	,@OpenOrderID varchar(50)
AS
BEGIN

	SET NOCOUNT ON;

	INSERT INTO [dbo].[T_OrderHistory] (
		 [通貨ペアNo]
		,[日時]
		,[売買モード]
		,[Close済み]
		,[Rate_買い]
		,[Rate_売り]
		,[Close区分]
		,[BonusStage]
		,[注文単位]
		,[OpenOrderID]
	) VALUES (
		 @通貨ペアNo
		,@日時
		,@売買モード
		,@Close済み
		,@Rate_買い
		,@Rate_売り
		,@Close区分
		,@BonusStage
		,@注文単位
		,@OpenOrderID
	);

END

GO
