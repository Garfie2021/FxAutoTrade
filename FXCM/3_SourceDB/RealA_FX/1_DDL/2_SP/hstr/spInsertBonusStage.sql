USE DemoA_FX
GO

DROP PROCEDURE [hstr].[spInsertBonusStage]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [hstr].[spInsertBonusStage]
	 @日時 datetime
	,@通貨ペアNo tinyint
	,@買いRate float
	,@買いWMAs14 float
	,@買いWMAs14上昇角度 float
	,@買いWMAs14上昇角度シグマ float
	,@買いリミット float
	,@売りRate float
	,@売りWMAs14 float
	,@売りWMAs14上昇角度 float
	,@売りWMAs14上昇角度シグマ float
	,@売りリミット float
	,@BS_WMA判定_15m bit
	,@保持ポジション bit
	,@BS判定_前 varchar(1)
	,@BS判定_今 varchar(1)
AS
BEGIN

	SET NOCOUNT ON;

	INSERT INTO [hstr].[tBonusStage] (
		 日時
		,通貨ペアNo
		,買いRate
		,買いWMAs14
		,買いWMAs14上昇角度
		,買いWMAs14上昇角度シグマ
		,買いリミット
		,売りRate
		,売りWMAs14
		,売りWMAs14上昇角度
		,売りWMAs14上昇角度シグマ
		,売りリミット
		,BS_WMA判定_15m
		,保持ポジション
		,BS判定_前
		,BS判定_今
	) VALUES (
		 @日時
		,@通貨ペアNo
		,@買いRate
		,@買いWMAs14
		,@買いWMAs14上昇角度
		,@買いWMAs14上昇角度シグマ
		,@買いリミット
		,@売りRate
		,@売りWMAs14
		,@売りWMAs14上昇角度
		,@売りWMAs14上昇角度シグマ
		,@売りリミット
		,@BS_WMA判定_15m
		,@保持ポジション
		,@BS判定_前
		,@BS判定_今
	);

END
GO
