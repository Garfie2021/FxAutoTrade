USE [RealA_FX]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[SP_Update通貨ペアMst_シグマ閾値]
AS
BEGIN

	SET NOCOUNT ON;

	declare @通貨ペアNo tinyint = 2;
	declare @シグマ閾値 float;
	declare @利益SUM float;

	WHILE @通貨ペアNo < 44
	BEGIN

		SELECT TOP 1 @シグマ閾値 = [シグマ閾値], @利益SUM = [利益SUM]
		FROM [smlt].[T_BonusStageHistory評価_直近1ヵ月]
		WHERE  [通貨ペアNo] = @通貨ペアNo
		ORDER BY [利益Sum] DESC

		--select @シグマ閾値

		UPDATE [dbo].[T_通貨ペアMst]
		SET [SMLT_シグマ閾値] = @シグマ閾値, [SMLT_直近1ヵ月の利益Sum] = @利益Sum
		WHERE [No] = @通貨ペアNo

		SET @通貨ペアNo = @通貨ペアNo + 1;
	END;

END

GO
