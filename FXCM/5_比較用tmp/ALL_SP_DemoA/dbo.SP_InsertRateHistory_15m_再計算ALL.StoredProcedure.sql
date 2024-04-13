USE [RealA_FX]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[SP_InsertRateHistory_15m_再計算ALL]
AS
BEGIN

	declare @ALL通貨ペア tinyint = 1;	-- 1：全通貨ペアを再計算する　0：1通貨ペアのみ再計算する


	declare @通貨ペアNo tinyint = 1;
	declare @now datetime = getdate();
	declare @StartDate datetime = '2014-03-01 00:00:00';
	declare @EndDate datetime;	
	declare @MaxMinuts bigint = 0;
	declare @diff bigint = 0;

	if @ALL通貨ペア = 0
	begin

		while @StartDate < GETDATE()
		begin

			EXEC [dbo].[SP_InsertRateHistory_15m] @通貨ペアNo = @通貨ペアNo, @StartDate = @StartDate;

			Set @StartDate = DATEADD(minute, 15, @StartDate);
		end;

	end
	else
	begin

		Set @通貨ペアNo = 0;

		while @通貨ペアNo < 44
		begin

			set @StartDate = '2014-03-01 00:00:00';

			while @StartDate < GETDATE()
			begin

				EXEC [dbo].[SP_InsertRateHistory_15m] @通貨ペアNo = @通貨ペアNo, @StartDate = @StartDate;

				Set @StartDate = DATEADD(minute, 15, @StartDate);
			end;

			Set @通貨ペアNo = @通貨ペアNo + 1;
		end;

	end;

END


GO
