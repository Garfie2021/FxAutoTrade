USE [DemoA_FX]
GO

DROP PROCEDURE [cmn].[spGetWMA�p�x]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [cmn].[spGetWMA�p�x]
	@����WMAs2			float,
	@����WMAs2_1�O	float,
	@����WMAs2�p�x		float	output,
	@����WMAs2			float,
	@����WMAs2_1�O	float,
	@����WMAs2�p�x		float	output
AS
BEGIN

	Declare @����y_�㏸�l_����_S2 float = @����WMAs2 - @����WMAs2_1�O;
	EXECUTE [cmn].[spGet�p�x] @����y_�㏸�l_����_S2, @����WMAs2�p�x OUTPUT;

	Declare @����y_�㏸�l_����Rate_S2 float = @����WMAs2 - @����WMAs2_1�O;
	EXECUTE [cmn].[spGet�p�x] @����y_�㏸�l_����Rate_S2, @����WMAs2�p�x OUTPUT;

END
GO

