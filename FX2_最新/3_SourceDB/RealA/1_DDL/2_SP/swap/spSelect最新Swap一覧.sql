USE OANDA_RealA
GO

DROP PROCEDURE [swap].[spSelect最新Swap一覧]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [swap].[spSelect最新Swap一覧]
AS
BEGIN

	select
		b.ペア名 as 通貨ペア名,
		[買いSwap],
		[売りSwap]
	from
	(
		SELECT
			rank() over(partition by [通貨ペアNo] order by [StartDate] desc) as rk,
			[通貨ペアNo]
			,[StartDate],
			[買いSwap],[売りSwap]
		FROM OANDA_RealA.[swap].[tSwap手動登録_Day1]
	) as a LEFT JOIN OANDA_RealA.[cmn].[t通貨ペアMst] as b ON a.通貨ペアNo = b.[No]
	where rk=1 
	order by b.ペア名

END
GO

