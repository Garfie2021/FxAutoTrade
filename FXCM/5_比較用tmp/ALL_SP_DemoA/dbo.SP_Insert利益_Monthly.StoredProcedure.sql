USE [RealA_FX]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[SP_Insert利益_Monthly]
	@年月				date,
	@利益確定開始日時	datetime,
	@出金可能Percent	tinyint
AS
BEGIN

	SET NOCOUNT ON;

	/*
	Declare @年					smallint = 2014
	Declare @月					tinyint = 3
	Declare @利益確定開始日時	datetime = '2014/04/21 00:00:00'
	Declare @出金可能Percent	tinyint = 80
	*/

	Declare @出金済フラグ tinyint
	select @出金済フラグ = [出金済フラグ]
	from [dbo].[T_利益_Monthly]
	WHERE [年月] = @年月

	if @出金済フラグ = 1
	begin
		-- [出金済フラグ] = 1　だったら何もせず終了
		return;
	end;


	DELETE FROM [dbo].[T_利益_Monthly]
	WHERE [年月] = @年月 and [出金済フラグ] = 0


	Declare @利益	int;
	SELECT
		@利益 = SUM(GrossPL) + SUM([Int])
	FROM
		T_ClosedTrades
	WHERE
		YEAR(CloseTime) = YEAR(@年月) AND MONTH(CloseTime) = MONTH (@年月)

	Declare @利益確定開始以降の利益	int;
	SELECT
		@利益確定開始以降の利益 = SUM(GrossPL) + SUM([Int])
	FROM
		T_ClosedTrades
	WHERE
		YEAR(CloseTime) = YEAR(@年月) AND MONTH(CloseTime) = MONTH (@年月) AND @利益確定開始日時 < CloseTime

	if @利益 is null
	begin
		INSERT INTO [dbo].[T_利益_Monthly](
			 [年月]
			,[利益]
			,[利益確定開始以降の利益]
			,[出金可能Percent]
			,[出金可能額]
			,[出金済フラグ]
		)VALUES(
			 @年月
			,0
			,0
			,@出金可能Percent
			,0
			,0);
	end
	else if @利益確定開始以降の利益 is null
	begin
		INSERT INTO [dbo].[T_利益_Monthly](
			 [年月]
			,[利益]
			,[利益確定開始以降の利益]
			,[出金可能Percent]
			,[出金可能額]
			,[出金済フラグ]
		)VALUES(
			 @年月
			,@利益
			,0
			,@出金可能Percent
			,0
			,0);
	end
	else
	begin
		INSERT INTO [dbo].[T_利益_Monthly](
			 [年月]
			,[利益]
			,[利益確定開始以降の利益]
			,[出金可能Percent]
			,[出金可能額]
			,[出金済フラグ]
		)VALUES(
			 @年月
			,@利益
			,@利益確定開始以降の利益
			,@出金可能Percent
			,@利益確定開始以降の利益 * @出金可能Percent / 100
			,0);
	end

END

GO
