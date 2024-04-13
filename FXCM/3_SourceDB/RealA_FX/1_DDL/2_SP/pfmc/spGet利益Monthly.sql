USE RealB_2370741683_FX
GO
/*
*/
DROP PROCEDURE [pfmc].[spGet利益Monthly]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [pfmc].[spGet利益Monthly]
	@年月					date,
	@利益確定開始以降の利益	int		output,
	@出金可能額				int		output
AS
BEGIN

	--declare @年月					date = '2016/03/01 00:00:00'
	--declare @利益確定開始以降の利益	int
	--declare @出金可能額				int

	SELECT
		@利益確定開始以降の利益 = 利益確定開始以降の利益, 
		@出金可能額 = 出金可能額
	FROM [pfmc].[t利益Monthly]
	WHERE 年月 = @年月;

	--select @利益確定開始以降の利益, @出金可能額

END
GO
/*
*/