USE [FX2_Demo]
GO

DROP PROCEDURE [oder].[spOrderSetting������]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [oder].[spOrderSetting������]
AS
BEGIN

	DECLARE @Cnt tinyint;
	
	SELECT @Cnt = COUNT(*)
	FROM [oder].[tOrderSettings]

	if @Cnt > 0
	begin
		-- ���ɏ������ς�
		return;
	end;

	declare @�ʉ݃y�ANo tinyint = 0;
	while @�ʉ݃y�ANo < 44
	begin

		INSERT INTO [oder].[tOrderSettings]
           ([�ʉ݃y�ANo]
           ,[�v�Z�Ώ�]
           ,[�����Ώ�])
	     VALUES
           (@�ʉ݃y�ANo
           ,1
           ,1)

		Set @�ʉ݃y�ANo = @�ʉ݃y�ANo + 1;
	end;

END
GO
/*
*/

