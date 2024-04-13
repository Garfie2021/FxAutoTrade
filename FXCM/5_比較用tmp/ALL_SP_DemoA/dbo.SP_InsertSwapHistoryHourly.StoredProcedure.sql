USE [RealA_FX]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[SP_InsertSwapHistoryHourly]
	@back_1h	int = -2
AS
BEGIN
	/*
	declare @back_1h	int = -168;
	*/

	declare @now datetime = GETDATE();

	declare @Cnt int = 0;
	DECLARE @Start1h datetime;
	DECLARE @End1h datetime;
	declare @通貨ペアNo	tinyint = 0;
	declare @Swap_買い	float = 0;
	declare @Swap_売り	float = 0;

	while @back_1h < 1
	begin

		EXECUTE [cmn].[SP_GetThis1h] @now, @back_1h, @Start1h OUTPUT, @End1h OUTPUT;

		Set @通貨ペアNo = 0;
		while @通貨ペアNo < 44
		begin

			--select @back_1h, @通貨ペアNo, @Start1h, @End1h;

			SELECT @Cnt = Count(*)
			FROM [dbo].[T_RateHistory]
			WHERE [通貨ペア] = @通貨ペアNo AND @Start1h <= [date] AND [date] < @End1h;

			if @Cnt < 1
			begin
				Set @通貨ペアNo = @通貨ペアNo + 1;
				Continue;
			end;

			SELECT @Cnt = Count(*)
			From [dbo].[T_SwapHistory_Hourly] 
			WHERE [通貨ペアNo] = @通貨ペアNo AND [日時] = @Start1h;

			if @Cnt < 1
			begin
				INSERT INTO [dbo].[T_SwapHistory_Hourly] ([通貨ペアNo], [日時])	Values (@通貨ペアNo, @Start1h);
			end;

			SELECT TOP 1 @Swap_買い = [Swap_買い], @Swap_売り = [Swap_売り]
			FROM [dbo].[T_RateHistory]
			WHERE [通貨ペア] = @通貨ペアNo AND [date] < @End1h
			ORDER BY [date] desc;

			Update [dbo].[T_SwapHistory_Hourly]
			Set [Swap_買い] = @Swap_買い, [Swap_売り] = @Swap_売り
			WHERE [通貨ペアNo] = @通貨ペアNo AND [日時] = @Start1h;

			Set @通貨ペアNo = @通貨ペアNo + 1;
		end;

		--select '1';

		Set @back_1h = @back_1h + 1;
	end;

END

GO
