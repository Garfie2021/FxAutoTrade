USE OANDA_DemoB
GO
/*
*/
DROP PROCEDURE [oder].[spSelectOrderHistory2]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [oder].[spSelectOrderHistory2]
    @口座No	Int,
	@from	DateTime,
	@to		DateTime
AS
BEGIN

	SELECT
		 c.[取引状況]
		,a.[妥当性]
		,a.[通貨ペアNo]
		,b.[ペア名] as 通貨ペア名
		,a.[日時]
		,a.[買いSwap]
		,a.[売りSwap]
		,a.[Swap判定]
		,a.[買いRate]
		,a.[売りRate]
		,a.[売買判定]
		,a.[売買]
		,a.[保持ポジション]
		,a.[BS_Min15_買いWMAs14]
		,a.[BS_Min15_買いWMAs14角度]
		,a.[BS_Min15_買いWMAs14角度シグマ]
		,a.[BS_Min15_売りWMAs14]
		,a.[BS_Min15_売りWMAs14角度]
		,a.[BS_Min15_売りWMAs14角度シグマ]
		,a.[BS_WMA判定_15m]
		,a.[BS判定_15m]
		,a.[BS開始]
		,a.[BS判定_前]
		,a.[BS判定_今]
		,a.[差分リミット通常]
		,a.[差分リミットBS]
		,a.[ポジション追加_成行_ストップ]
		,a.[ポジション追加_成行_リミット]
		,a.[ポジション追加時のリミット]
		,a.[注文単位]
		,a.[注文単位を割る値]
		,a.[ロスカット余剰金]
		,a.[ロスカット余剰金調整値]
		,a.[Month1_Start]
		,a.[Month1_End]
		,a.[Month1_買いWMAs2]
		,a.[Month1_買いWMAs2角度]
		,a.[Month1_買いWMAs14]
		,a.[Month1_売りWMAs2]
		,a.[Month1_売りWMAs2角度]
		,a.[Month1_売りWMAs14]
		,a.[Week1_Start]
		,a.[Week1_End]
		,a.[Week1_買いWMAs2]
		,a.[Week1_買いWMAs2角度]
		,a.[Week1_買いWMAs14]
		,a.[Week1_売りWMAs2]
		,a.[Week1_売りWMAs2角度]
		,a.[Week1_売りWMAs14]
		,a.[Day1_Start]
		,a.[Day1_End]
		,a.[Day1_買いWMAs2]
		,a.[Day1_買いWMAs14]
		,a.[Day1_買いWMAs2角度]
		,a.[Day1_売りWMAs2]
		,a.[Day1_売りWMAs14]
		,a.[Day1_売りWMAs2角度]
		,a.[Hour1_Start]
		,a.[Hour1_End]
		,a.[Hour1_買いWMAs2]
		,a.[Hour1_買いWMAs2角度]
		,a.[Hour1_買いWMAs14]
		,a.[Hour1_売りWMAs2]
		,a.[Hour1_売りWMAs2角度]
		,a.[Hour1_売りWMAs14]
		,a.[Min15_Start]
		,a.[Min15_End]
		,a.[Min15_買いWMAs2]
		,a.[Min15_買いWMAs2角度]
		,a.[Min15_買いWMAs14]
		,a.[Min15_売りWMAs2]
		,a.[Min15_売りWMAs2角度]
		,a.[Min15_売りWMAs14]
		,a.[Min5_Start]
		,a.[Min5_End]
		,a.[Min5_買いWMAs2]
		,a.[Min5_買いWMAs2角度]
		,a.[Min5_買いWMAs14]
		,a.[Min5_売りWMAs2]
		,a.[Min5_売りWMAs2角度]
		,a.[Min5_売りWMAs14]
		,a.[Min1_Start]
		,a.[Min1_End]
		,a.[Min1_買いWMAs2]
		,a.[Min1_買いWMAs2角度]
		,a.[Min1_買いWMAs14]
		,a.[Min1_売りWMAs2]
		,a.[Min1_売りWMAs2角度]
		,a.[Min1_売りWMAs14]
		,a.[OpenOrderID]
		,a.[TradeID]
		,a.[CloseOrderID]
		,a.[Close日時]
		,a.[Oanda_TradeData_id]
		,a.[登録日時]
		,a.[更新日時]
	FROM [oder].[tOrderHistory2] as a LEFT JOIN [cmn].[t通貨ペアMst] as b ON a.[通貨ペアNo] = b.[No]
		LEFT JOIN [pfmc].[tExecLog] as c ON a.[日時] = c.[Order開始日時] AND a.[通貨ペアNo] = c.[通貨ペアNo]
	where a.口座No = @口座No AND @from <= a.[日時] and a.[日時] < @to
	order by a.[日時];

END
GO
/*
*/