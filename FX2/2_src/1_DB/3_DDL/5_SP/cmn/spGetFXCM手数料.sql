USE [FX2_Demo]
GO

DROP PROCEDURE [cmn].[spGetFXCMŽè”—¿]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [cmn].[spGetFXCMŽè”—¿]
	@’•¶”	smallint,
	@Žè”—¿	int	output
AS
BEGIN

	-- 2015/10/03Žž“_‚Å‚ÍA1’•¶10‰~ŒÅ’èB
	Set @Žè”—¿ = 10;

	Set @Žè”—¿ = @Žè”—¿ * @’•¶”;
END
GO

