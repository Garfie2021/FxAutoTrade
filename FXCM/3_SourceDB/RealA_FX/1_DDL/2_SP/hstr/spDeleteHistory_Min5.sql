USE [RealB_2370741683_FX]
GO

DROP PROCEDURE [hstr].[spDeleteHistory_Min5]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [hstr].[spDeleteHistory_Min5]
	@back int = -1	-- DemoAは-1。RealAは-5。RealBは-3。
AS
BEGIN

	SET NOCOUNT ON;

	DECLARE @StartDate datetime = DATEADD(month, @back, getdate());

	declare @通貨ペアNo tinyint = 0;

	while @通貨ペアNo < 44
	begin
	
		DELETE FROM [hstr].[tMin5]
		where [通貨ペアNo] = @通貨ペアNo and [StartDate] < @StartDate

		Set @通貨ペアNo = @通貨ペアNo + 1;
	end;

END

GO
