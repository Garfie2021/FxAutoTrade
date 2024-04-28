USE [RealB_2370741683_FX]
GO

DROP PROCEDURE [hstr].[spDeleteHistory_Sec]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [hstr].[spDeleteHistory_Sec]
	@back int = -1	-- DemoA��-1�BRealA��-5�BRealB��-1�B
AS
BEGIN

	SET NOCOUNT ON;

	DECLARE @StartDate datetime = DATEADD(month, @back, getdate());

	declare @�ʉ݃y�ANo tinyint = 0;

	while @�ʉ݃y�ANo < 44
	begin
	
		DELETE FROM [hstr].[tSec]
		where [�ʉ݃y�ANo] = @�ʉ݃y�ANo and [StartDate] < @StartDate

		Set @�ʉ݃y�ANo = @�ʉ݃y�ANo + 1;
	end;

END

GO
