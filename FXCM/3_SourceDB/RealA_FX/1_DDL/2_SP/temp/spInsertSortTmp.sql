USE RealB_2370741683_FX
GO

DROP PROCEDURE [temp].[spInsertSortTmp]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [temp].[spInsertSortTmp]
	@通貨ペア	varchar(10),
	@値			float
AS
BEGIN

	SET NOCOUNT ON;

	INSERT INTO [temp].[tSortTmp]
		([通貨ペア]
		,[値])
	VALUES
		(@通貨ペア
		,@値);

END
GO
