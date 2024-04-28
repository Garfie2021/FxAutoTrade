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
	@���l1	varchar(100),
	@���l2	varchar(100),
	@�l		float
AS
BEGIN
	/*
	DECLARE @�ʉ݃y�ANo		tinyint = 0;
	*/

	Update [cmn].[tSettings]
	Set
		 [�l] = @�l
		,[���l1] = @���l1
		,[���l2] = @���l2
	where [No] = @No

END
GO
/*
*/