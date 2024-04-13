USE [RealA_FX]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[SP_Chk当月出金可能額は出金済みか]
	@年月			date,
	@出金済フラグ	tinyint	output
AS
BEGIN
	/*
	DECLARE @通貨ペアNo		tinyint = 29
	*/


	select @出金済フラグ = [出金済フラグ]
	from [dbo].[T_利益_Monthly]
	WHERE [年月] = @年月


END

GO
