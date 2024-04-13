USE DemoA_FX
GO
/*
*/
DROP PROCEDURE [cmn].[spGet差分リミット]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [cmn].[spGet差分リミット]
	@通貨ペアNo		tinyint,
	@差分リミット	float	output
AS
BEGIN

	SET NOCOUNT ON;

	SELECT 
		@差分リミット = [差分リミット]
	FROM [cmn].[t通貨ペアMst]
	WHERE [No] = @通貨ペアNo;

END
GO
/*
*/
