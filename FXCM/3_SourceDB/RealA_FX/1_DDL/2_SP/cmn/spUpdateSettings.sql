USE [RealB_2370741683_FX]
GO
/*
*/
DROP PROCEDURE [cmn].[spUpdateSettings]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [cmn].[spUpdateSettings]
	@No		tinyint,
	@備考1	varchar(100),
	@備考2	varchar(100),
	@値		float
AS
BEGIN
	/*
	DECLARE @通貨ペアNo		tinyint = 0;
	*/

	Update [cmn].[tSettings]
	Set
		 [値] = @値
		,[備考1] = @備考1
		,[備考2] = @備考2
	where [No] = @No

END
GO
/*
*/