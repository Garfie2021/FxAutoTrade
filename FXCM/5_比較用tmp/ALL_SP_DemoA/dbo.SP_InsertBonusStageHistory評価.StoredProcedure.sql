USE [RealA_FX]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[SP_InsertBonusStageHistory評価]
	 @通貨ペアNo tinyint
	,@シグマ閾値 float
	,@年月日 datetime
	,@StartDate datetime
	,@EndDate datetime
AS
BEGIN

	SET NOCOUNT ON;
	/*
	declare @通貨ペアNo tinyint = 2;
	declare @シグマ閾値 float = 1;
	declare @年月日 datetime = '2014-05-15';
	declare @StartDate datetime = '2014-05-15 20:00:00';
	declare @EndDate datetime = '2014-05-16 00:00:00';
	*/
	delete from [dbo].[T_BonusStageHistory評価]
	where 通貨ペアNo = @通貨ペアNo and シグマ閾値 = @シグマ閾値 and [年月日] = @年月日;

	declare @Cnt int
	SELECT @Cnt = count(*)
	FROM [dbo].[T_BonusStageHistory]
	where 通貨ペアNo = @通貨ペアNo and シグマ閾値 = @シグマ閾値 and @StartDate <= [日時] and [日時] <= @EndDate

	if @Cnt < 1
	begin
		return;
	end;

	declare @Start日時 datetime
	declare @Start買いRate float
	declare @Start売りRate float
	declare @StartWMA判定_15m varchar(10)
	declare @StartBS開始終了 varchar(1)
	declare @End日時 datetime
	declare @End買いRate float
	declare @End売りRate float
	declare @EndWMA判定_15m varchar(10)
	declare @EndBS開始終了 varchar(1)
	declare @利益 float = 0;
	declare @利益Plus float = 0;
	declare @利益Minus float = 0;
	declare @利益Sum float = 0;
	declare @BS発生回数 int = 0;	
	declare @BS平均持続時間 int = 0;	

	DECLARE cursor_T_BonusStageHistory CURSOR FOR
	SELECT [日時], [買いRate], [売りRate], [WMA判定_15m], [BS開始終了]
	FROM [dbo].[T_BonusStageHistory]
	where 通貨ペアNo = @通貨ペアNo and シグマ閾値 = @シグマ閾値 and @StartDate <= [日時] and [日時] <= @EndDate and [BS開始終了] in ('S', 'E')
	order by [日時]

	open cursor_T_BonusStageHistory;

	FETCH NEXT FROM cursor_T_BonusStageHistory INTO @Start日時, @Start買いRate, @Start売りRate, @StartWMA判定_15m, @StartBS開始終了;
	FETCH NEXT FROM cursor_T_BonusStageHistory INTO @End日時, @End買いRate, @End売りRate, @EndWMA判定_15m, @EndBS開始終了;

	WHILE @@FETCH_STATUS = 0
	BEGIN
		if @StartWMA判定_15m = '買い'
		begin
			Set @利益 = (@End売りRate - @Start買いRate);
		end
		else
		begin
			Set @利益 = (@End買いRate - @Start売りRate);
		end;

		if @利益 < 0
		begin
			Set @利益Minus = @利益Minus + @利益;
		end
		else
		begin
			Set @利益Plus = @利益Plus + @利益;
		end;

		Set @BS発生回数 = @BS発生回数 + 1;

		Set @BS平均持続時間 = @BS平均持続時間 + DATEDIFF(second, @Start日時, @End日時);

		FETCH NEXT FROM cursor_T_BonusStageHistory INTO @Start日時, @Start買いRate, @Start売りRate, @StartWMA判定_15m, @StartBS開始終了;
		FETCH NEXT FROM cursor_T_BonusStageHistory INTO @End日時, @End買いRate, @End売りRate, @EndWMA判定_15m, @EndBS開始終了;
	END;

	CLOSE cursor_T_BonusStageHistory;
	DEALLOCATE cursor_T_BonusStageHistory;

	Set @利益Sum = @利益Plus + @利益Minus;
	Set @BS平均持続時間 = @BS平均持続時間 / @BS発生回数;

	select @利益Plus, @利益Minus, @利益Sum, @BS発生回数, @BS平均持続時間;

	INSERT INTO [dbo].[T_BonusStageHistory評価]
		([通貨ペアNo]
		,[シグマ閾値]
		,[年月日]
		,[利益Plus]
		,[利益Minus]
		,[利益Sum]
		,[BS発生回数]
		,[BS平均持続時間])
	VALUES
		(@通貨ペアNo
		,@シグマ閾値
		,@年月日
		,@利益Plus
		,@利益Minus
		,@利益Sum
		,@BS発生回数
		,@BS平均持続時間);



/*


	DECLARE @シグマ閾値tbl table( 値 float NOT NULL, primary key (値) );
	Insert into @シグマ閾値tbl(値)
	select [シグマ閾値]
	from [dbo].[T_BonusStageHistory]
	where 通貨ペアNo = @通貨ペアNo and @StartDate <= [日時] and [日時] <= @EndDate
	group by [シグマ閾値]

	--select 値 from @シグマ閾値tbl order by 値

*/

END

GO
