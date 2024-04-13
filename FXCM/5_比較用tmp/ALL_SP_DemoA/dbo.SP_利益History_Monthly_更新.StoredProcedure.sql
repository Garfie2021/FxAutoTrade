USE [RealA_FX]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[SP_利益History_Monthly_更新]
	@back_month	int = 0	 --  0:最新月、-n:n月前 ※マイナス値にしか対応していない。
AS
BEGIN

	--declare @back_month	int = 0;	 --  0:最新月、-n:n月前 ※マイナス値にしか対応していない。

	--declare @Today datetime =  '2014/2/2 6:30:00';
	declare @Today datetime = GETDATE();

	--declare @StartDate datetime = '2014/1/1 00:00:00';
	declare @StartDate datetime;
	--declare @EndDate datetime = '2014/2/1 00:00:00';
	declare @EndDate datetime;
	
	Set @StartDate = DATEADD(month, @back_month, @Today);
	Set @StartDate = CONVERT(varchar, YEAR(@StartDate)) + '/' + CONVERT(varchar, MONTH(@StartDate)) + '/1 00:00:00';
	Set @EndDate = DATEADD(month, @back_month + 1, @Today);
	Set @EndDate = CONVERT(varchar, YEAR(@EndDate)) + '/' + CONVERT(varchar, MONTH(@EndDate)) + '/1 00:00:00';

	select @StartDate as StartDate, @EndDate as EndDate

	DELETE FROM [dbo].[T_利益History_Monthly]
	WHERE [日時] = @StartDate;

	INSERT INTO [dbo].[T_利益History_Monthly] (
		 [日時]
		,[利益]
		,[Order数]
		,[Close数]
		,[損切りClose数]
		,[損切り金額]
	) VALUES (
		@StartDate,
		0,	-- 利益
		(SELECT COUNT(*) FROM [dbo].[T_Trades] WHERE @StartDate < [Time] and [Time] < @EndDate),									-- Order数
		(SELECT COUNT(*) FROM [dbo].[T_ClosedTrades] WHERE @StartDate < [CloseTime] and [CloseTime] < @EndDate),					-- Close数
		(SELECT COUNT(*) FROM [dbo].[T_ClosedTrades] WHERE @StartDate < [CloseTime] and [CloseTime] < @EndDate and [GrossPL] < 0),	-- 損切りClose数
		0	-- 損切り金額
	);


	-- 利益
	declare @Cnt int = 0;
	SELECT @Cnt = COUNT(*) FROM [dbo].[T_ClosedTrades] WHERE @StartDate < [CloseTime] and [CloseTime] < @EndDate;

	if @Cnt > 0
	begin
		UPDATE [dbo].[T_利益History_Monthly]
		SET [利益] = (SELECT SUM([GrossPL]) FROM [dbo].[T_ClosedTrades] WHERE @StartDate < [CloseTime] and [CloseTime] < @EndDate)
		WHERE [日時] = @StartDate;
	end;


	-- 損切り金額
	SELECT @Cnt = COUNT(*) FROM [dbo].[T_ClosedTrades] WHERE @StartDate < [CloseTime] and [CloseTime] < @EndDate and [GrossPL] < 0;

	if @Cnt > 0
	begin
		UPDATE [dbo].[T_利益History_Monthly]
		SET [損切り金額] = (SELECT SUM([GrossPL]) FROM [dbo].[T_ClosedTrades] WHERE @StartDate < [CloseTime] and [CloseTime] < @EndDate and [GrossPL] < 0)
		WHERE [日時] = @StartDate;		
	end;


END

GO
