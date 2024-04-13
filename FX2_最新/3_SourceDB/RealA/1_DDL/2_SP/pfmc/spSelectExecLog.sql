USE OANDA_RealA
GO
/*
*/
DROP PROCEDURE [pfmc].[spSelectExecLog]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [pfmc].[spSelectExecLog]
	@口座No int,
	@from	DateTime,
	@to		DateTime
AS
BEGIN

	SELECT 
		 a.[通貨ペアNo]
		,b.[ペア名] as 通貨ペア名
		,a.[取引状況]
		,COUNT(a.[通貨ペアNo]) as Count
	FROM [pfmc].[tExecLog] as a LEFT JOIN [cmn].[t通貨ペアMst] as b ON a.[通貨ペアNo] = b.[No]
	where [口座No] = @口座No AND @from <= a.[ExecDate] and a.[ExecDate] < @to
	group by a.[通貨ペアNo],b.[ペア名], a.[取引状況]
	order by a.[通貨ペアNo] --, [ExecDate]

END
GO
/*
*/