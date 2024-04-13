USE OANDA_RealB
GO

DROP PROCEDURE [anls].[spSelect想定売買タイミング_Swap判定無し]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [anls].[spSelect想定売買タイミング_Swap判定無し]
	@from	DateTime,
	@to		DateTime
AS
BEGIN

	SET NOCOUNT ON;

	SELECT 
		 a.[通貨ペアNo]
		,b.[ペア名] as 通貨ペア名
		,a.[売買判定]
		,a.[StartDateMin1]
		,a.[StartDateMin5]
		,a.[StartDateMin15]
		,a.[StartDateHour1]
		,a.[StartDateDay1]
		,a.[StartDateWeek1]
		,a.[StartDateMonth1]
		,a.[比較結果]
		,a.[登録日時]
		,a.[更新日時]
	FROM [anls].[t想定売買タイミング_Swap判定無し] as a LEFT JOIN [cmn].[t通貨ペアMst] as b ON a.[通貨ペアNo] = b.[No]
	where @from <= a.[StartDateMin1] and a.[StartDateMin1] < @to
	order by a.[通貨ペアNo], a.[StartDateMin1];

END
GO
