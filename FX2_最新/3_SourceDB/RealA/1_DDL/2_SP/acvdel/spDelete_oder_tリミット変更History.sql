USE OANDA_DemoB
GO

DROP PROCEDURE [acvdel].[spDelete_oder_t���~�b�g�ύXHistory]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [acvdel].[spDelete_oder_t���~�b�g�ύXHistory]
	@back int = -1	-- DemoA��-1�BRealA��-1�BRealB��-1�B
AS
BEGIN

	SET NOCOUNT ON;

	DECLARE @StartDate datetime = DATEADD(day, @back, getdate());
	
	DELETE FROM oder.t���~�b�g�ύXHistory
	where [����] < @StartDate;

END
GO
