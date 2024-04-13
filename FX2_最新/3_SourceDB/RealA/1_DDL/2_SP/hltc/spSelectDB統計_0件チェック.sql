USE OANDA_DemoB
GO

DROP PROCEDURE [hltc].[spSelectDB統計_0件チェック]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [hltc].[spSelectDB統計_0件チェック]
AS
BEGIN

[anls].[tデルタRate]
[anls].[t想定売買タイミング]
[anls].[t想定売買タイミング_Swap判定無し]
[anls].[t注文単位を割る値]
[cmn].[t環境設定]
[cmn].[t口座マスタ]
[cmn].[t通貨ペアMst]
[hstr].[tBonusStage]
[hstr].[tDay1]
[hstr].[tHour1]
[hstr].[tMin1]
[hstr].[tMin15]
[hstr].[tMin5]
[hstr].[tMonth1]
[hstr].[tSec]





END
GO

