USE [FX2_Demo]
GO

DROP PROCEDURE [cmn].[spGet�O�p��]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [cmn].[spGet�O�p��]
	@�l			int,	-- �����݂̂ɑΉ����Ă���
	@�O�p��		int	output
AS
BEGIN

	Set @�O�p�� = 0;

	while @�l > 0
	begin

		Set @�O�p�� = @�O�p�� + @�l;

		set @�l = @�l - 1;
	end;

END

GO

