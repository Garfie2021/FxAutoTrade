USE OANDA_DemoB
GO

DROP PROCEDURE [acvdel].[spDelete_hstr_tSec]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [acvdel].[spDelete_hstr_tSec]
	@back int = -1	-- DemoA��-1�BRealA��-5�BRealB��-1�B
AS
BEGIN

	SET NOCOUNT ON;

	DECLARE @StartDate datetime = DATEADD(day, @back, getdate());

	declare @�ʉ݃y�ANo tinyint = 0;
	DECLARE @�ʉ݃y�ANoMax tinyint = (SELECT MAX(No) from [cmn].[t�ʉ݃y�AMst]);

	WHILE @�ʉ݃y�ANo <= @�ʉ݃y�ANoMax
	begin
	
		DELETE FROM [hstr].[tSec]
		where [�ʉ݃y�ANo] = @�ʉ݃y�ANo and [StartDate] < @StartDate

		Set @�ʉ݃y�ANo = @�ʉ݃y�ANo + 1;
	end;

END

GO
