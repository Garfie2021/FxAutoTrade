USE DemoA_FX
GO

delete from [hstr].[tBonusStage];
go

INSERT INTO [hstr].[tBonusStage]
	([�ʉ݃y�ANo]
	,[�V�O�}臒l]
	,[����]
	,[����Rate]
	,[����Rate]
	,[WMA����_15m]
	,[BS�J�n�I��]
	,[�⑫])
SELECT
	 [�ʉ݃y�ANo]
	,[�V�O�}臒l]
	,[����]
	,[����Rate]
	,[����Rate]
	,[WMA����_15m]
	,[BS�J�n�I��]
	,[�⑫]
FROM [dbo].[T_BonusStageHistory];
go

delete from [cmn].[tSettings]
go

INSERT INTO [cmn].[tSettings]
	([No]
	,[�l]
	,[���l1]
	,[���l2])
SELECT
	 [No]
	,[�l]
	,[���l1]
	,[���l2]
FROM [dbo].[T_Settings];
go


delete from [cmn].[t�ʉ݃y�AMst]
go

INSERT INTO [cmn].[t�ʉ݃y�AMst]
	([No]
	,[�y�A��]
	,[SMLT_�V�O�}臒l]
	,[SMLT_����1�����̗��vSum]
	,[�������]
	,[Order�Ԋu�ŏ��l_����]
	,[Order�Ԋu�ŏ��l_����])
SELECT
	 [No]
	,[�y�A��]
	,[SMLT_�V�O�}臒l]
	,[SMLT_����1�����̗��vSum]
	,[�������]
	,[Order�Ԋu�ŏ��l_����]
	,[Order�Ԋu�ŏ��l_����]
FROM [dbo].[T_�ʉ݃y�AMst];
go


delete from [pfmc].[t���vMonthly]
go

INSERT INTO [pfmc].[t���vMonthly]
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
FROM [hstr].[t���vMonthly]
go
