USE [FX2_Demo]
GO

DROP PROCEDURE [cmn].[spGet������]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [cmn].[spGet������]
	@�p�x�V�O�}	float,
	@������		int	output
AS
BEGIN

	-- ���������V�O�}�Ŕ{�����āA�L���Ȏ��ɗ��v���o���Ղ�����B
	-- ������́A�L���؋����ɍ��킹��10�ȏ���\�ɂ���B
	
	--declare @�{��	int = ROUND(@�p�x�V�O�}, 0);

	--if @�{�� < 1
	--begin
	--	Set @������ = 1;
	--end
	--else if @�{�� > 10
	--begin
	--	Set @������ = 10;
	--end
	--else
	--begin
	--	Set @������ = @�{��;
	--end
	Set @������ = 1;

END
GO

