USE [RealB_2370741683_FX]
GO

DROP PROCEDURE [hstr].[spDeleteHistory_Day1]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [hstr].[spDeleteHistory_Day1]
	@back int = -1	-- DemoAは-1。RealAは-1。RealBは-1。
AS
BEGIN

	SET NOCOUNT ON;

	DECLARE @StartDate datetime = DATEADD(YEAR, @back, getdate());

	declare @通貨ペアNo tinyint = 0;

	while @通貨ペアNo < 44
	begin
	
		DELETE FROM [hstr].[tDay1]
		where [通貨ペアNo] = @通貨ペアNo and [StartDate] < @StartDate

		Set @通貨ペアNo = @通貨ペアNo + 1;
	end;

END

GO
