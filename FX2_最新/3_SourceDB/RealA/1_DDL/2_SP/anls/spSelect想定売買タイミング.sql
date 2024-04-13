USE OANDA_RealA
GO

DROP PROCEDURE [anls].[spSelect想定売買タイミング]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [anls].[spSelect想定売買タイミング]
	@from	DateTime,
	@to		DateTime,
	@swap	float
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
		,a.[買いSwap]
		,a.[売りSwap]
		,a.[比較結果]
		,a.[登録日時]
		,a.[更新日時]
	FROM [anls].[t想定売買タイミング] as a LEFT JOIN [cmn].[t通貨ペアMst] as b ON a.[通貨ペアNo] = b.[No]
	where @from <= a.[StartDateMin1] and a.[StartDateMin1] < @to and 
		(a.[買いSwap] >= @swap or a.[売りSwap] >= @swap)
	order by a.[通貨ペアNo], a.[StartDateMin1];

END
GO
