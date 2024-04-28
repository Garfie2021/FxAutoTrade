USE [FXCM]
GO
/*
*/
DROP PROCEDURE [exp].[spExeportRateHistory_fromFXCM]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [exp].[spExeportRateHistory_fromFXCM]
	@ExportDbName	VARCHAR(50),
	@TargetTblName	VARCHAR(50)
AS
BEGIN

	--DECLARE @ExportDbName	VARCHAR(50);
	--DECLARE @TargetTblName	VARCHAR(50);
	----SET @ExportDB = 'FXCM_DemoA';
	--SET @ExportDbName = 'OANDA_DemoB';
	--SET @TargetTblName = 'Day1';

	DECLARE @SQL	VARCHAR(1000);

	/*
	����SQL�𓮓I�ɐ�������

	INSERT INTO FXCM_DemoA.hstr.tMin1(
		[�ʉ݃y�ANo],
		[StartDate],
		[����Rate_�n�l],
		[����Rate_���l],
		[����Rate_���l],
		[����Rate_�I�l],
		[����Rate_�n�l],
		[����Rate_���l],
		[����Rate_���l],
		[����Rate_�I�l]
	)
	SELECT
		[�ʉ݃y�ANo],
		[����],
		[Rate_�n�l_����],
		[Rate_���l_����],
		[Rate_���l_����],
		[Rate_�I�l_����],
		[Rate_�n�l_����],
		[Rate_���l_����],
		[Rate_���l_����],
		[Rate_�I�l_����]
	FROM FXCM.rate.Min1 as a
	where not exists 
	(
		SELECT *
		FROM FXCM_DemoA.hstr.tMin1 as b
		where (a.�ʉ݃y�ANo = b.�ʉ݃y�ANo and a.���� = b.StartDate)
	)
	*/

	SET @SQL = 'INSERT INTO ' + @ExportDbName + '.hstr.t' + @TargetTblName + '(
			[�ʉ݃y�ANo],
			[StartDate],
			[����Rate_�n�l],
			[����Rate_���l],
			[����Rate_���l],
			[����Rate_�I�l],
			[����Rate_�n�l],
			[����Rate_���l],
			[����Rate_���l],
			[����Rate_�I�l]
		)
		SELECT
			[�ʉ݃y�ANo],
			[����],
			[Rate_�n�l_����],
			[Rate_���l_����],
			[Rate_���l_����],
			[Rate_�I�l_����],
			[Rate_�n�l_����],
			[Rate_���l_����],
			[Rate_���l_����],
			[Rate_�I�l_����]
		FROM FXCM.rate.' + @TargetTblName + ' as a
		where not exists 
		(
			SELECT *
			FROM ' + @ExportDbName + '.hstr.t' + @TargetTblName + ' as b
			where (a.�ʉ݃y�ANo = b.�ʉ݃y�ANo and a.���� = b.StartDate)
		);';

	--print(@SQL);
	EXECUTE (@SQL);

END
GO
/*
*/
