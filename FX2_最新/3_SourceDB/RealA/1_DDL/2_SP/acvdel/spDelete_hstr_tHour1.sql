USE OANDA_DemoB
GO

DROP PROCEDURE [acvdel].[spDelete_hstr_tHour1]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [acvdel].[spDelete_hstr_tHour1]
	@back int = -5	-- DemoA��-5�BRealA��-5�BRealB��-5�B
AS
BEGIN

	SET NOCOUNT ON;

	DECLARE @StartDate datetime = DATEADD(day, @back, getdate());

	declare @�ʉ݃y�ANo tinyint = 0;
	DECLARE @�ʉ݃y�ANoMax tinyint = (SELECT MAX(No) from [cmn].[t�ʉ݃y�AMst]);

	WHILE @�ʉ݃y�ANo <= @�ʉ݃y�ANoMax
	begin
	
		DELETE FROM [hstr].[tHour1]
		where [�ʉ݃y�ANo] = @�ʉ݃y�ANo and [StartDate] < @StartDate

		Set @�ʉ݃y�ANo = @�ʉ݃y�ANo + 1;
	end;

END

GO
