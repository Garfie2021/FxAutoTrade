USE [RealA_FX]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[SP_GetSMLT結果]
	@通貨ペアNo					tinyint,
	@SMLT_シグマ閾値			float	output,
	@SMLT_直近1ヵ月の利益Sum	float	output
AS
BEGIN

	SELECT @SMLT_シグマ閾値 = [SMLT_シグマ閾値], @SMLT_直近1ヵ月の利益Sum = [SMLT_直近1ヵ月の利益Sum]
	FROM [dbo].[T_通貨ペアMst]
	Where [No] = @通貨ペアNo

END

GO
