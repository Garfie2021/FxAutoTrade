USE OANDA_DemoB
GO

DROP PROCEDURE [temp].[spInsertSortTmp]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [temp].[spInsertSortTmp]
    @口座No		Int,
	@通貨ペア	varchar(10),
	@値			float
AS
BEGIN

	SET NOCOUNT ON;

	INSERT INTO [temp].[tSortTmp] (
		口座No,
		[通貨ペア],
		[値]
	) VALUES (
		@口座No,
		@通貨ペア
		,@値
	);

END
GO
