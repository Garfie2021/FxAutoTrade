USE [RealA_FX]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[SP_Update利益_Monthly_出金済みフラグ]
	@年月				date,
	@出金済フラグ		tinyint
AS
BEGIN

	SET NOCOUNT ON;

	UPDATE [dbo].[T_利益_Monthly]
	SET [出金済フラグ] = @出金済フラグ
	WHERE [年月] = @年月

END

GO
