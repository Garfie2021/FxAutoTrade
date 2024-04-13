USE [RealA_FX]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[SP_週別Order残_Increment]
	@Time Datetime
AS
BEGIN
	SET NOCOUNT ON;
	
	declare @year_wk varchar(10);

	SELECT top 1 @year_wk = [year_wk]
	FROM [dbo].[T_year_wk]
	where [StartDate] < @Time and @Time < [EndDate]

	declare @cnt int;

	SELECT @cnt = COUNT(*)
	FROM [dbo].[T_分析SortTmp]
	where [キー] = @year_wk

	IF @cnt = 0
	BEGIN
		INSERT INTO [dbo].[T_分析SortTmp]
		([キー],[値])
		VALUES
		(@year_wk, 1)
	END
	ELSE
	BEGIN
		UPDATE [dbo].[T_分析SortTmp]
		SET [値] = [値] + 1
		WHERE [キー] = @year_wk
	END

END

GO
