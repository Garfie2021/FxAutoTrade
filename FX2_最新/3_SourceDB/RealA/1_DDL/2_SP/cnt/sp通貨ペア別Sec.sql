USE OANDA_RealA
GO
/*
*/
DROP PROCEDURE [cnt].[sp�ʉ݃y�A��Sec]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [cnt].[sp�ʉ݃y�A��Sec]
AS
BEGIN

	SELECT [cmn].[t�ʉ݃y�AMst].[No] as �ʉ݃y�ANo, [cmn].[t�ʉ݃y�AMst].�y�A�� as �ʉ݃y�A��, count(*) as cnt 
	FROM hstr.tSec INNER JOIN [cmn].[t�ʉ݃y�AMst] ON hstr.tSec.�ʉ݃y�ANo = [cmn].[t�ʉ݃y�AMst].[No]
	GROUP BY [cmn].[t�ʉ݃y�AMst].[No], [cmn].[t�ʉ݃y�AMst].�y�A��
	ORDER BY [cmn].[t�ʉ݃y�AMst].�y�A��;

END
GO
/*
*/