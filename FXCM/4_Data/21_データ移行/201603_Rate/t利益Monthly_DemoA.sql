USE DemoA_FX
GO

delete from [hstr].[t���vMonthly];

INSERT INTO [hstr].[t���vMonthly]
           ([�N��]
           ,[���v]
           ,[���vPlus]
           ,[���vMinus]
           ,[���v�m��J�n�ȍ~�̗��v]
           ,[�o���\Percent]
           ,[�o���\�z]
           ,[�o���σt���O]
           ,[�o�����莞_1���ԑO�̎���؋���]
           ,[�o�����莞_���݂̎���؋���]
           ,[�o�����莞_�挎���v])
SELECT [�N��]
      ,[���v]
      ,[���vPlus]
      ,[���vMinus]
      ,[���v�m��J�n�ȍ~�̗��v]
      ,[�o���\Percent]
      ,[�o���\�z]
      ,[�o���σt���O]
      ,[�o�����莞_1���ԑO�̎���؋���]
      ,[�o�����莞_���݂̎���؋���]
      ,[�o�����莞_�挎���v]
FROM [dbo].[T_���v_Monthly];



