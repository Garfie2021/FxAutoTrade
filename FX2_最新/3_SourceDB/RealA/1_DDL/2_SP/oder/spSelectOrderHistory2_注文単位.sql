USE OANDA_DemoB
GO

DROP PROCEDURE [oder].[spSelectOrderHistory2_�����P��]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [oder].[spSelectOrderHistory2_�����P��]
    @����No	Int,
	@from	DateTime,
	@to		DateTime
AS
BEGIN
	/*
    declare @����No	Int = 1;
	declare @from	DateTime = '1900/01/01';
	declare @to		DateTime = '2100/01/01';
	*/

	SELECT
		 a.[�ʉ݃y�ANo]
		,b.[�y�A��] as �ʉ݃y�A��
		,a.[����]
		,a.[�����P��]
		,a.[�����P�ʂ�����l]
		,a.[���X�J�b�g�]���]
		,a.[���X�J�b�g�]��������l]
		,a.[����Rate]
		,a.[����Rate]
	FROM [oder].[tOrderHistory2] as a LEFT JOIN [cmn].[t�ʉ݃y�AMst] as b ON a.[�ʉ݃y�ANo] = b.[No]
	where a.����No = @����No AND @from <= a.[����] and a.[����] < @to
	order by a.[�ʉ݃y�ANo], a.[����] desc;

END
GO
/*
*/