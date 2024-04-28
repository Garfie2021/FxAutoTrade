USE [RealB_2370741683_FX]
GO
/*
*/
DROP PROCEDURE [hltc].[SP_IncrementOrder�^�C�~���OCnt]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [hltc].[SP_IncrementOrder�^�C�~���OCnt]
AS
BEGIN

	DECLARE @now		Datetime = GETDATE();

	DECLARE @StartDate datetime;
	DECLARE @EndDate datetime;
	EXECUTE [cmn].[spGetThisHour1] @now, 0, @StartDate OUTPUT, @EndDate OUTPUT;

	DECLARE @cnt int;
	select @cnt = count(*)
	from [hltc].[T_����Cnt_Hourly]
	where ���� = @StartDate;

	if @cnt < 1
	begin
		Insert [hltc].[T_����Cnt_Hourly] ([����], Order�^�C�~���OCnt) Values (@StartDate, 0);
	end;

	Update [hltc].[T_����Cnt_Hourly]
	Set
		 [Order�^�C�~���OCnt] = Order�^�C�~���OCnt + 1
	where ���� = @StartDate;


END

GO
