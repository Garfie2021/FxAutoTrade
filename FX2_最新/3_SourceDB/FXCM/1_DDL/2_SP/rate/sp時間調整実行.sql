USE [FXCM]
GO

DROP PROCEDURE [rate].[sp���Ԓ������s]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [rate].[sp���Ԓ������s]
AS
BEGIN

	UPDATE rate.Min15 SET ���� = DATEADD(hour,14,����);
	
	UPDATE rate.Day1 SET ���� = DATEADD(hour,-11,����)


END
GO
