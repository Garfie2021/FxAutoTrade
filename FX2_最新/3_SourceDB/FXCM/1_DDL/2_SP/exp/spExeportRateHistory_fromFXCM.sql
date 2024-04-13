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
	このSQLを動的に生成する

	INSERT INTO FXCM_DemoA.hstr.tMin1(
		[通貨ペアNo],
		[StartDate],
		[買いRate_始値],
		[買いRate_高値],
		[買いRate_安値],
		[買いRate_終値],
		[売りRate_始値],
		[売りRate_高値],
		[売りRate_安値],
		[売りRate_終値]
	)
	SELECT
		[通貨ペアNo],
		[日時],
		[Rate_始値_買い],
		[Rate_高値_買い],
		[Rate_安値_買い],
		[Rate_終値_買い],
		[Rate_始値_売り],
		[Rate_高値_売り],
		[Rate_安値_売り],
		[Rate_終値_売り]
	FROM FXCM.rate.Min1 as a
	where not exists 
	(
		SELECT *
		FROM FXCM_DemoA.hstr.tMin1 as b
		where (a.通貨ペアNo = b.通貨ペアNo and a.日時 = b.StartDate)
	)
	*/

	SET @SQL = 'INSERT INTO ' + @ExportDbName + '.hstr.t' + @TargetTblName + '(
			[通貨ペアNo],
			[StartDate],
			[買いRate_始値],
			[買いRate_高値],
			[買いRate_安値],
			[買いRate_終値],
			[売りRate_始値],
			[売りRate_高値],
			[売りRate_安値],
			[売りRate_終値]
		)
		SELECT
			[通貨ペアNo],
			[日時],
			[Rate_始値_買い],
			[Rate_高値_買い],
			[Rate_安値_買い],
			[Rate_終値_買い],
			[Rate_始値_売り],
			[Rate_高値_売り],
			[Rate_安値_売り],
			[Rate_終値_売り]
		FROM FXCM.rate.' + @TargetTblName + ' as a
		where not exists 
		(
			SELECT *
			FROM ' + @ExportDbName + '.hstr.t' + @TargetTblName + ' as b
			where (a.通貨ペアNo = b.通貨ペアNo and a.日時 = b.StartDate)
		);';

	--print(@SQL);
	EXECUTE (@SQL);

END
GO
/*
*/
