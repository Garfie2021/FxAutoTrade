USE DemoA_FX
GO

DROP PROCEDURE [oder].[spInsert注文対象通貨ペアDaily]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [oder].[spInsert注文対象通貨ペアDaily]
	@StartDate	datetime,
	@通貨ペアNo	tinyint
AS
BEGIN
	/*
	DECLARE @StartDate datetime = '2016/05/02 6:00:00'
	DECLARE @通貨ペアNo tinyint = 10
	*/

	DECLARE @通貨ペアNo数	tinyint;

	select @通貨ペアNo数 = count(*)
	from [oder].[t注文対象通貨ペアDaily]
	where [StartDate] = @StartDate and 通貨ペアNo = @通貨ペアNo;

	if @通貨ペアNo数 < 1
	begin
		INSERT INTO [oder].[t注文対象通貨ペアDaily] ([StartDate], [通貨ペアNo])
		VALUES (@StartDate, @通貨ペアNo);
	end;

END
GO
/*
*/

