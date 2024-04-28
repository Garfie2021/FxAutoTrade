USE [FXCM]
GO

DROP PROCEDURE [fxcm].[SP_InsertRateHistory_1m_fromFXCM]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [fxcm].[SP_InsertRateHistory_1m_fromFXCM]
AS
BEGIN

	INSERT INTO [DemoA_FX].[hstr].tMonth1
		  ([�ʉ݃y�ANo]
		  ,[StartDate]
		  ,[����Swap]
		  ,[����Rate_�n�l]
		  ,[����Rate_���l]
		  ,[����Rate_���l]
		  ,[����Rate_�I�l]
		  ,[����WMAs2]
		  ,[����WMAs2�p�x]
		  ,[����WMAs2�p�x�V�O�}]
		  ,[����WMAs2�p�x��������]
		  ,[����WMAs2�p�x����Rate]
		  ,[����WMAs14]
		  ,[����WMAs14�p�x]
		  ,[����WMAs14�p�x�V�O�}]
		  ,[����WMAs14�p�x��������]
		  ,[����WMAs14�p�x����Rate]
		  ,[����Swap]
		  ,[����Rate_�n�l]
		  ,[����Rate_���l]
		  ,[����Rate_���l]
		  ,[����Rate_�I�l]
		  ,[����WMAs2]
		  ,[����WMAs2�p�x]
		  ,[����WMAs2�p�x�V�O�}]
		  ,[����WMAs2�p�x��������]
		  ,[����WMAs2�p�x����Rate]
		  ,[����WMAs14]
		  ,[����WMAs14�p�x]
		  ,[����WMAs14�p�x�V�O�}]
		  ,[����WMAs14�p�x��������]
		  ,[����WMAs14�p�x����Rate]
		  ,[�o�^����]
		  ,[�X�V����])
	SELECT [�ʉ݃y�ANo]
		  ,[StartDate]
		  ,[����Swap]
		  ,[����Rate_�n�l]
		  ,[����Rate_���l]
		  ,[����Rate_���l]
		  ,[����Rate_�I�l]
		  ,[����WMAs2]
		  ,[����WMAs2�p�x]
		  ,[����WMAs2�p�x�V�O�}]
		  ,[����WMAs2�p�x��������]
		  ,[����WMAs2�p�x����Rate]
		  ,[����WMAs14]
		  ,[����WMAs14�p�x]
		  ,[����WMAs14�p�x�V�O�}]
		  ,[����WMAs14�p�x��������]
		  ,[����WMAs14�p�x����Rate]
		  ,[����Swap]
		  ,[����Rate_�n�l]
		  ,[����Rate_���l]
		  ,[����Rate_���l]
		  ,[����Rate_�I�l]
		  ,[����WMAs2]
		  ,[����WMAs2�p�x]
		  ,[����WMAs2�p�x�V�O�}]
		  ,[����WMAs2�p�x��������]
		  ,[����WMAs2�p�x����Rate]
		  ,[����WMAs14]
		  ,[����WMAs14�p�x]
		  ,[����WMAs14�p�x�V�O�}]
		  ,[����WMAs14�p�x��������]
		  ,[����WMAs14�p�x����Rate]
		  ,[�o�^����]
		  ,[�X�V����]
	FROM [RealA_FX].[hstr].tMonth1 as b
	where not exists 
	(
		SELECT *
		FROM [DemoA_FX].[hstr].tMonth1 as a
		where (a.[�ʉ݃y�ANo] = b.[�ʉ݃y�ANo] and a.[StartDate] = b.[StartDate])
	)
	go


END
GO
