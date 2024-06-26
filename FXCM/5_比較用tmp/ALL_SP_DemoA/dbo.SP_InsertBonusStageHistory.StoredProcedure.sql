USE [RealA_FX]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[SP_InsertBonusStageHistory]
	 @通貨ペアNo tinyint
	,@日時 datetime
	,@シグマ閾値 float
	,@買いRate float
	,@売りRate float
	,@WMA判定_15m varchar(10)
	,@BS開始終了 varchar(1)
	,@補足 varchar(200)
AS
BEGIN

	SET NOCOUNT ON;

	delete from [dbo].[T_BonusStageHistory]
	where 通貨ペアNo = @通貨ペアNo and シグマ閾値 = @シグマ閾値 and 日時 = @日時

	INSERT INTO [dbo].[T_BonusStageHistory]
		([通貨ペアNo]
		,シグマ閾値
		,[日時]
		,買いRate
		,売りRate
		,WMA判定_15m
		,BS開始終了
		,[補足])
	VALUES
		(@通貨ペアNo
		,@シグマ閾値
		,@日時
		,@買いRate
		,@売りRate
		,@WMA判定_15m
		,@BS開始終了
		,@補足);


END

GO
