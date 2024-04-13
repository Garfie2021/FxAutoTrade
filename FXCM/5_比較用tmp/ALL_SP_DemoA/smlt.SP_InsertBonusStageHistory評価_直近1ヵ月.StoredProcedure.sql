USE [RealA_FX]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [smlt].[SP_InsertBonusStageHistory評価_直近1ヵ月]
AS
BEGIN

	SET NOCOUNT ON;
	/*
	declare @年月日 datetime = '2014-05-15';
	declare @StartDate datetime = '2014-05-15 20:00:00';
	declare @EndDate datetime = '2014-05-16 00:00:00';
	*/

	--print convert(varchar, @通貨ペアNo) + '	' + convert(varchar, @シグマ閾値) + '	' + convert(varchar, @年月日);

	delete from [smlt].[T_BonusStageHistory評価_直近1ヵ月]

	INSERT INTO [smlt].[T_BonusStageHistory評価_直近1ヵ月]
		([通貨ペアNo]
		,[シグマ閾値]
		,[利益Sum])
	SELECT [通貨ペアNo], [シグマ閾値], SUM([利益Sum])
	FROM [smlt].[T_BonusStageHistory評価]
	WHERE DATEADD(MONTH, -1, GETDATE()) < [年月日] AND [年月日] < GETDATE()
	GROUP BY [通貨ペアNo], [シグマ閾値]
	
END

GO
