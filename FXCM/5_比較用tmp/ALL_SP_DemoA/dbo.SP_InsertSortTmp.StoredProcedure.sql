USE [RealA_FX]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[SP_InsertSortTmp]
	@通貨ペア	varchar(10),
	@値			float
AS
BEGIN

	SET NOCOUNT ON;


	INSERT INTO [dbo].[T_SortTmp]
		([通貨ペア]
		,[値])
	VALUES
		(@通貨ペア
		,@値);


END

GO
