USE [RealA_FX]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[SP_InsertRateHistory_30m_計算]
AS
BEGIN

	declare @ALL通貨ペア tinyint = 0;	-- 1：全通貨ペアを再計算する　2：1通貨ペアのみ再計算する


	declare @通貨ペアNo tinyint = 0;
	declare @now datetime = getdate();
	declare @StartDate datetime;
	declare @EndDate datetime;	
	declare @diff bigint = 0;

	Set @通貨ペアNo = 0;

	while @通貨ペアNo < 44
	begin

		EXECUTE [dbo].[SP_InsertRateHistory_30m] @通貨ペアNo, @now, 0
		EXECUTE [dbo].[SP_InsertRateHistory_30m] @通貨ペアNo, @now, -30

		Set @通貨ペアNo = @通貨ペアNo + 1;
	end;


END


GO
