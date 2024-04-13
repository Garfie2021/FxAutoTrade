USE DemoA_FX
GO
/*
*/
DROP PROCEDURE [cmn].[spGetリミット_BS終了時]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [cmn].[spGetリミット_BS終了時]
	@通貨ペアNo		tinyint,
	@買いリミット	float	output,
	@売りリミット	float	output
AS
BEGIN

	SET NOCOUNT ON;

	SELECT 
		@買いリミット = [買いリミット_BS終了時],
		@売りリミット = [売りリミット_BS終了時]
	FROM [cmn].[t通貨ペアMst]
	WHERE [No] = @通貨ペアNo;

END
GO
/*
*/
