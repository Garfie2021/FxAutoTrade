USE OANDA_DemoB
GO

DROP PROCEDURE [hstr].[spSelectBonusStage]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [hstr].[spSelectBonusStage]
	@from	DateTime,
	@to		DateTime
AS
BEGIN

	SET NOCOUNT ON;

	SELECT 
		 a.[日時]
		,a.[通貨ペアNo]
		,b.[ペア名] as 通貨ペア名
		,a.[買いRate]
		,a.[買いWMAs14]
		,a.[買いWMAs14上昇角度]
		,a.[買いWMAs14上昇角度シグマ]
		,a.[売りRate]
		,a.[売りWMAs14]
		,a.[売りWMAs14上昇角度]
		,a.[売りWMAs14上昇角度シグマ]
		,a.[BS_WMA判定_15m]
		,a.[保持ポジション]
		,a.[BS判定_前]
		,a.[BS判定_今]
		,a.[買いSwap]
		,a.[売りSwap]
		,a.[Swap判定]
	FROM [hstr].[tBonusStage] as a LEFT JOIN [cmn].[t通貨ペアMst] as b ON a.[通貨ペアNo] = b.[No]
	where @from <= a.[日時] and a.[日時] < @to
	order by a.[日時] desc

END
GO
