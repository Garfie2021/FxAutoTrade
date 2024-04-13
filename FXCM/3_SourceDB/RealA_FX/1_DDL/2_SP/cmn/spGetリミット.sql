USE DemoA_FX
GO
/*
*/
DROP PROCEDURE [cmn].[spGetリミット]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [cmn].[spGetリミット]
	@通貨ペアNo		tinyint,
	@買いリミット	float	output,
	@売りリミット	float	output
AS
BEGIN

	SET NOCOUNT ON;

	SELECT 
		@買いリミット = [買いリミット],
		@売りリミット = [売りリミット]
	FROM [cmn].[t通貨ペアMst]
	WHERE [No] = @通貨ペアNo;

END
GO
/*
*/
