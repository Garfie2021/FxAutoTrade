USE [OANDA_DemoB]
GO

DROP PROCEDURE [acv].[spSave_hstr_tBonusStage]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [acv].[spSave_hstr_tBonusStage]
AS
BEGIN

	SET NOCOUNT ON;


	INSERT INTO [OANDA_DemoB_ACV].hstr.tBonusStage(
		[日時],
		[通貨ペアNo],
		[買いRate],
		[買いWMAs14],
		[買いWMAs14上昇角度],
		[買いWMAs14上昇角度シグマ],
		[売りRate],
		[売りWMAs14],
		[売りWMAs14上昇角度],
		[売りWMAs14上昇角度シグマ],
		[BS_WMA判定_15m],
		[保持ポジション],
		[BS判定_前],
		[BS判定_今],
		[買いSwap],
		[売りSwap],
		[Swap判定],
		[登録日時],
		[更新日時])
	SELECT 
		[日時],
		[通貨ペアNo],
		[買いRate],
		[買いWMAs14],
		[買いWMAs14上昇角度],
		[買いWMAs14上昇角度シグマ],
		[売りRate],
		[売りWMAs14],
		[売りWMAs14上昇角度],
		[売りWMAs14上昇角度シグマ],
		[BS_WMA判定_15m],
		[保持ポジション],
		[BS判定_前],
		[BS判定_今],
		[買いSwap],
		[売りSwap],
		[Swap判定],
		[登録日時],
		[更新日時]
	FROM [OANDA_DemoB].hstr.tBonusStage as a
	WHERE not exists 
		(
			SELECT *
			FROM [OANDA_DemoB_ACV].hstr.tBonusStage as b
			WHERE a.[通貨ペアNo] = b.[通貨ペアNo] AND a.[日時] = b.[日時]
		);

END
GO

