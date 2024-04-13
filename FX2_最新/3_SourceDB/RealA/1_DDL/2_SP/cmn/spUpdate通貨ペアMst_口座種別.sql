USE OANDA_DemoB
GO
/*
*/
DROP PROCEDURE [cmn].[spUpdate通貨ペアMst_口座種別]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [cmn].[spUpdate通貨ペアMst_口座種別]
AS
BEGIN

	SET NOCOUNT ON;

	Declare @通貨ペアNo tinyint = 0;

	WHILE @通貨ペアNo < 39
	BEGIN
		UPDATE [cmn].[t通貨ペアMst]	SET [口座種別] = 'FX'	WHERE [No] = @通貨ペアNo;

		SET @通貨ペアNo = @通貨ペアNo + 1;
	END;

	UPDATE [cmn].[t通貨ペアMst]	SET [口座種別] = 'XAU'	WHERE [No] = 39;
	UPDATE [cmn].[t通貨ペアMst]	SET [口座種別] = 'Kabu'	WHERE [No] = 40;
	UPDATE [cmn].[t通貨ペアMst]	SET [口座種別] = 'Kabu'	WHERE [No] = 41;		
	UPDATE [cmn].[t通貨ペアMst]	SET [口座種別] = 'FX'	WHERE [No] = 42;
	UPDATE [cmn].[t通貨ペアMst]	SET [口座種別] = 'XAU'	WHERE [No] = 43;

END
GO
/*
*/
