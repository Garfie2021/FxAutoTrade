USE OANDA_DemoB
GO
/*
*/
DROP PROCEDURE [cmn].[spInsert通貨ペアMst]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [cmn].[spInsert通貨ペアMst]
	@通貨ペアNo		tinyint,
	@通貨ペア名		varchar(50)
AS
BEGIN

	SET NOCOUNT ON;

	INSERT INTO [cmn].[t通貨ペアMst] (
		[No],
		[ペア名]
	) VALUES (
		@通貨ペアNo,
		@通貨ペア名
	);

END
GO
/*
*/
