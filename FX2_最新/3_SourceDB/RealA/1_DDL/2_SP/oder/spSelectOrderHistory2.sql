USE OANDA_DemoB
GO
/*
*/
DROP PROCEDURE [oder].[spSelectOrderHistory2]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [oder].[spSelectOrderHistory2]
    @����No	Int,
	@from	DateTime,
	@to		DateTime
AS
BEGIN

	SELECT
		 c.[�����]
		,a.[�Ó���]
		,a.[�ʉ݃y�ANo]
		,b.[�y�A��] as �ʉ݃y�A��
		,a.[����]
		,a.[����Swap]
		,a.[����Swap]
		,a.[Swap����]
		,a.[����Rate]
		,a.[����Rate]
		,a.[��������]
		,a.[����]
		,a.[�ێ��|�W�V����]
		,a.[BS_Min15_����WMAs14]
		,a.[BS_Min15_����WMAs14�p�x]
		,a.[BS_Min15_����WMAs14�p�x�V�O�}]
		,a.[BS_Min15_����WMAs14]
		,a.[BS_Min15_����WMAs14�p�x]
		,a.[BS_Min15_����WMAs14�p�x�V�O�}]
		,a.[BS_WMA����_15m]
		,a.[BS����_15m]
		,a.[BS�J�n]
		,a.[BS����_�O]
		,a.[BS����_��]
		,a.[�������~�b�g�ʏ�]
		,a.[�������~�b�gBS]
		,a.[�|�W�V�����ǉ�_���s_�X�g�b�v]
		,a.[�|�W�V�����ǉ�_���s_���~�b�g]
		,a.[�|�W�V�����ǉ����̃��~�b�g]
		,a.[�����P��]
		,a.[�����P�ʂ�����l]
		,a.[���X�J�b�g�]���]
		,a.[���X�J�b�g�]��������l]
		,a.[Month1_Start]
		,a.[Month1_End]
		,a.[Month1_����WMAs2]
		,a.[Month1_����WMAs2�p�x]
		,a.[Month1_����WMAs14]
		,a.[Month1_����WMAs2]
		,a.[Month1_����WMAs2�p�x]
		,a.[Month1_����WMAs14]
		,a.[Week1_Start]
		,a.[Week1_End]
		,a.[Week1_����WMAs2]
		,a.[Week1_����WMAs2�p�x]
		,a.[Week1_����WMAs14]
		,a.[Week1_����WMAs2]
		,a.[Week1_����WMAs2�p�x]
		,a.[Week1_����WMAs14]
		,a.[Day1_Start]
		,a.[Day1_End]
		,a.[Day1_����WMAs2]
		,a.[Day1_����WMAs14]
		,a.[Day1_����WMAs2�p�x]
		,a.[Day1_����WMAs2]
		,a.[Day1_����WMAs14]
		,a.[Day1_����WMAs2�p�x]
		,a.[Hour1_Start]
		,a.[Hour1_End]
		,a.[Hour1_����WMAs2]
		,a.[Hour1_����WMAs2�p�x]
		,a.[Hour1_����WMAs14]
		,a.[Hour1_����WMAs2]
		,a.[Hour1_����WMAs2�p�x]
		,a.[Hour1_����WMAs14]
		,a.[Min15_Start]
		,a.[Min15_End]
		,a.[Min15_����WMAs2]
		,a.[Min15_����WMAs2�p�x]
		,a.[Min15_����WMAs14]
		,a.[Min15_����WMAs2]
		,a.[Min15_����WMAs2�p�x]
		,a.[Min15_����WMAs14]
		,a.[Min5_Start]
		,a.[Min5_End]
		,a.[Min5_����WMAs2]
		,a.[Min5_����WMAs2�p�x]
		,a.[Min5_����WMAs14]
		,a.[Min5_����WMAs2]
		,a.[Min5_����WMAs2�p�x]
		,a.[Min5_����WMAs14]
		,a.[Min1_Start]
		,a.[Min1_End]
		,a.[Min1_����WMAs2]
		,a.[Min1_����WMAs2�p�x]
		,a.[Min1_����WMAs14]
		,a.[Min1_����WMAs2]
		,a.[Min1_����WMAs2�p�x]
		,a.[Min1_����WMAs14]
		,a.[OpenOrderID]
		,a.[TradeID]
		,a.[CloseOrderID]
		,a.[Close����]
		,a.[Oanda_TradeData_id]
		,a.[�o�^����]
		,a.[�X�V����]
	FROM [oder].[tOrderHistory2] as a LEFT JOIN [cmn].[t�ʉ݃y�AMst] as b ON a.[�ʉ݃y�ANo] = b.[No]
		LEFT JOIN [pfmc].[tExecLog] as c ON a.[����] = c.[Order�J�n����] AND a.[�ʉ݃y�ANo] = c.[�ʉ݃y�ANo]
	where a.����No = @����No AND @from <= a.[����] and a.[����] < @to
	order by a.[����];

END
GO
/*
*/