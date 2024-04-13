USE [RealA_FX]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [indi].[SP_InsertIndicator_Daily_WMA]
	@通貨ペアNo		tinyint = 12,
	@日時			datetime,
	@買い_WMA		float,
	@売り_WMA		float,
	@買い_WMA_S2	float,
	@売り_WMA_S2	float
AS
BEGIN

	declare @Cnt int = 0;


	-- 初期レコードを、事前にInsertしておく

	SELECT @Cnt = count(*)
	FROM [indi].[T_Indicator_Daily]
	where 通貨ペアNo = @通貨ペアNo and 日時 = @日時

	if @Cnt = 0
	begin
		INSERT INTO [indi].[T_Indicator_Daily] ([通貨ペアNo], [日時]) VALUES (@通貨ペアNo, @日時);
	end


	-- WMAの角度を計算する

	Declare @WMA_買い_WMA_1日前 float = 0;
	Declare @WMA_買い_WMA_1日前_S2 float = 0;

	select top 1 @WMA_買い_WMA_1日前 = WMA_買い_WMA, @WMA_買い_WMA_1日前_S2 = WMA_買い_WMA_S2
	from [indi].[T_Indicator_Daily]
	where 通貨ペアNo = @通貨ペアNo and 日時 < @日時	
	order by [日時] desc

	Declare @底辺x_日 float = 1;
	Declare @高さy_上昇値 float = @買い_WMA - @WMA_買い_WMA_1日前;
	Declare @高さy_上昇値_S2 float = @買い_WMA_S2 - @WMA_買い_WMA_1日前_S2;

	Declare @上昇角度 float;
	EXECUTE [cmn].[SP_Get上昇角度] @底辺x_日, @高さy_上昇値, @上昇角度 OUTPUT

	Declare @上昇角度_S2 float;
	EXECUTE [cmn].[SP_Get上昇角度] @底辺x_日, @高さy_上昇値_S2, @上昇角度_S2 OUTPUT

	-- 結果をUpdate

	UPDATE [indi].[T_Indicator_Daily]
	SET
		WMA_買い_WMA = @買い_WMA,
		WMA_買い_WMA上昇角度 = @上昇角度,
		WMA_買い_WMA_S2 = @買い_WMA_S2,
		WMA_買い_WMA上昇角度_S2 = @上昇角度_S2
	where 通貨ペアNo = @通貨ペアNo and 日時 = @日時	

END


GO
