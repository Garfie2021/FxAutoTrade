USE [RealB_2370741683_FX]
GO
/*
*/
DROP PROCEDURE [hltc].[SP_IncrementOrderタイミングCnt]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [hltc].[SP_IncrementOrderタイミングCnt]
AS
BEGIN

	DECLARE @now		Datetime = GETDATE();

	DECLARE @StartDate datetime;
	DECLARE @EndDate datetime;
	EXECUTE [cmn].[spGetThisHour1] @now, 0, @StartDate OUTPUT, @EndDate OUTPUT;

	DECLARE @cnt int;
	select @cnt = count(*)
	from [hltc].[T_処理Cnt_Hourly]
	where 日時 = @StartDate;

	if @cnt < 1
	begin
		Insert [hltc].[T_処理Cnt_Hourly] ([日時], OrderタイミングCnt) Values (@StartDate, 0);
	end;

	Update [hltc].[T_処理Cnt_Hourly]
	Set
		 [OrderタイミングCnt] = OrderタイミングCnt + 1
	where 日時 = @StartDate;


END

GO
