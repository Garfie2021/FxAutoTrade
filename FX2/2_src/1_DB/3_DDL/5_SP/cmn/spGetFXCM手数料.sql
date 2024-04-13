USE [FX2_Demo]
GO

DROP PROCEDURE [cmn].[spGetFXCM手数料]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [cmn].[spGetFXCM手数料]
	@注文数	smallint,
	@手数料	int	output
AS
BEGIN

	-- 2015/10/03時点では、1注文10円固定。
	Set @手数料 = 10;

	Set @手数料 = @手数料 * @注文数;
END
GO

