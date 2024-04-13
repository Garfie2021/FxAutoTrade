USE OANDA_DemoB
GO

DROP PROCEDURE [hstr].[spDeleteHistory_Min15]
GO
DROP PROCEDURE [acvdel].[spDelete_hstr_tMin15]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [acvdel].[spDelete_hstr_tMin15]
	@back int = -5	-- DemoAは-5。RealAは-5。RealBは-5。
AS
BEGIN

	SET NOCOUNT ON;

	DECLARE @StartDate datetime = DATEADD(month, @back, getdate());

	declare @通貨ペアNo tinyint = 0;
	DECLARE @通貨ペアNoMax tinyint = (SELECT MAX(No) from [cmn].[t通貨ペアMst]);

	WHILE @通貨ペアNo <= @通貨ペアNoMax
	begin
	
		DELETE FROM [hstr].[tMin15]
		where [通貨ペアNo] = @通貨ペアNo and [StartDate] < @StartDate

		Set @通貨ペアNo = @通貨ペアNo + 1;
	end;

END

GO
