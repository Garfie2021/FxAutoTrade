USE [RealA_FX]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[SP_Get今朝の取引証拠金]
	@now			datetime,
	@取引証拠金		int	output
AS
BEGIN
	/*
	Declare @now			datetime = '2014/04/29 12:22:37'
	Declare @取引証拠金		int
	*/

	Declare @今朝 datetime = convert(varchar, YEAR(@now)) + '/' + convert(varchar, MONTH(@now)) + '/' + convert(varchar, DAY(@now)) + ' 07:00:00';

	SELECT TOP 1
		@取引証拠金 = [Balance]
	FROM
		[dbo].[T_AccountsHistory]
	WHERE
		日時 < @今朝
	ORDER BY
		日時 DESC

	if @取引証拠金 is NULL
	begin
		Set @取引証拠金 = 0;
	end;

END

GO
