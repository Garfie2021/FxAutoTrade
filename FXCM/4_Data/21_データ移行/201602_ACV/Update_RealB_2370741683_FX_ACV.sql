UPDATE [RealB_2370741683_FX_ACV].[hstr].tMin15
   SET [����WMAs2] = [WMA_����_WMA_S2]
      ,[����WMAs2�p�x] = [WMA_����_WMA�㏸�p�x_S2]
      ,[����WMAs14] = [WMA_����_WMA]
      ,[����WMAs14�p�x] = [WMA_����_WMA�㏸�p�x]
      ,[����WMAs14�p�x�V�O�}] = [WMA_����_WMA�㏸�p�x_�V�O�}]
      ,[����WMAs2] = [WMA_����_WMA_S2]
      ,[����WMAs2�p�x] = [WMA_����_WMA�㏸�p�x_S2]
      ,[����WMAs14] = [WMA_����_WMA]
      ,[����WMAs14�p�x] = [WMA_����_WMA�㏸�p�x]
      ,[����WMAs14�p�x�V�O�}] = [WMA_����_WMA�㏸�p�x_�V�O�}]
  FROM [RealB_2370741683_FX_ACV_old].acv.T_Indicator_15m_Past as b
 WHERE [RealB_2370741683_FX_ACV].[hstr].tMin15.[�ʉ݃y�ANo] = b.[�ʉ݃y�ANo] AND [RealB_2370741683_FX_ACV].hstr.tMin15.[StartDate] = b.[����]

/*
UPDATE [RealB_2370741683_FX_ACV].[hstr].tWeek1
   SET [����WMAs2] = [WMA_����_WMA_S2]
      ,[����WMAs2�p�x] = [WMA_����_WMA�㏸�p�x_S2]
      ,[����WMAs14] = [WMA_����_WMA]
      ,[����WMAs14�p�x] = [WMA_����_WMA�㏸�p�x]
      ,[����WMAs2] = [WMA_����_WMA_S2]
      ,[����WMAs2�p�x] = [WMA_����_WMA�㏸�p�x_S2]
      ,[����WMAs14] = [WMA_����_WMA]
      ,[����WMAs14�p�x] = [WMA_����_WMA�㏸�p�x]
  FROM [RealB_2370741683_FX_ACV_old].acv.T_Indicator_Weekly_Past as b
 WHERE [RealB_2370741683_FX_ACV].[hstr].tWeek1.[�ʉ݃y�ANo] = b.[�ʉ݃y�ANo] AND [RealB_2370741683_FX_ACV].hstr.tWeek1.[StartDate] = b.[����]


UPDATE [RealB_2370741683_FX_ACV].[hstr].tHour1
   SET [����WMAs2] = [WMA_����_WMA_S2]
      ,[����WMAs2�p�x] = [WMA_����_WMA�㏸�p�x_S2]
      ,[����WMAs14] = [WMA_����_WMA]
      ,[����WMAs14�p�x] = [WMA_����_WMA�㏸�p�x]
      ,[����WMAs2] = [WMA_����_WMA_S2]
      ,[����WMAs2�p�x] = [WMA_����_WMA�㏸�p�x_S2]
      ,[����WMAs14] = [WMA_����_WMA]
      ,[����WMAs14�p�x] = [WMA_����_WMA�㏸�p�x]
  FROM [RealB_2370741683_FX_ACV_old].acv.T_Indicator_1h_Past as b
 WHERE [RealB_2370741683_FX_ACV].[hstr].tHour1.[�ʉ݃y�ANo] = b.[�ʉ݃y�ANo] AND [RealB_2370741683_FX_ACV].hstr.tHour1.[StartDate] = b.[����]


UPDATE [RealB_2370741683_FX_ACV].[hstr].tWeek1
   SET [����WMAs2] = [WMA_����_WMA_S2]
      ,[����WMAs2�p�x] = [WMA_����_WMA�㏸�p�x_S2]
      ,[����WMAs14] = [WMA_����_WMA]
      ,[����WMAs14�p�x] = [WMA_����_WMA�㏸�p�x]
      ,[����WMAs2] = [WMA_����_WMA_S2]
      ,[����WMAs2�p�x] = [WMA_����_WMA�㏸�p�x_S2]
      ,[����WMAs14] = [WMA_����_WMA]
      ,[����WMAs14�p�x] = [WMA_����_WMA�㏸�p�x]
  FROM [RealB_2370741683_FX_ACV_old].[indi].T_Indicator_Weekly as b
 WHERE [RealB_2370741683_FX_ACV].[hstr].tWeek1.[�ʉ݃y�ANo] = b.[�ʉ݃y�ANo] AND [RealB_2370741683_FX_ACV].[hstr].tWeek1.[StartDate] = b.[����]

UPDATE [RealB_2370741683_FX_ACV].[hstr].tMonth1
   SET [����WMAs2] = [WMA_����_WMA_S2]
      ,[����WMAs2�p�x] = [WMA_����_WMA�㏸�p�x_S2]
      ,[����WMAs14] = [WMA_����_WMA]
      ,[����WMAs14�p�x] = [WMA_����_WMA�㏸�p�x]
      ,[����WMAs2] = [WMA_����_WMA_S2]
      ,[����WMAs2�p�x] = [WMA_����_WMA�㏸�p�x_S2]
      ,[����WMAs14] = [WMA_����_WMA]
      ,[����WMAs14�p�x] = [WMA_����_WMA�㏸�p�x]
  FROM [RealB_2370741683_FX_ACV_old].[indi].T_Indicator_Monthly as b
 WHERE [RealB_2370741683_FX_ACV].[hstr].tMonth1.[�ʉ݃y�ANo] = b.[�ʉ݃y�ANo] AND [RealB_2370741683_FX_ACV].[hstr].tMonth1.[StartDate] = b.[����]

UPDATE [RealB_2370741683_FX_ACV].[hstr].tDay1
   SET [����WMAs2] = [WMA_����_WMA_S2]
      ,[����WMAs2�p�x] = [WMA_����_WMA�㏸�p�x_S2]
      ,[����WMAs14] = [WMA_����_WMA]
      ,[����WMAs14�p�x] = [WMA_����_WMA�㏸�p�x]
      ,[����WMAs2] = [WMA_����_WMA_S2]
      ,[����WMAs2�p�x] = [WMA_����_WMA�㏸�p�x_S2]
      ,[����WMAs14] = [WMA_����_WMA]
      ,[����WMAs14�p�x] = [WMA_����_WMA�㏸�p�x]
  FROM [RealB_2370741683_FX_ACV_old].[indi].T_Indicator_Daily as b
 WHERE [RealB_2370741683_FX_ACV].[hstr].tDay1.[�ʉ݃y�ANo] = b.[�ʉ݃y�ANo] AND [RealB_2370741683_FX_ACV].[hstr].tDay1.[StartDate] = b.[����]

UPDATE [RealB_2370741683_FX_ACV].[hstr].tHour6
   SET [����WMAs2] = [WMA_����_WMA_S2]
      ,[����WMAs2�p�x] = [WMA_����_WMA�㏸�p�x_S2]
      ,[����WMAs14] = [WMA_����_WMA]
      ,[����WMAs14�p�x] = [WMA_����_WMA�㏸�p�x]
      ,[����WMAs2] = [WMA_����_WMA_S2]
      ,[����WMAs2�p�x] = [WMA_����_WMA�㏸�p�x_S2]
      ,[����WMAs14] = [WMA_����_WMA]
      ,[����WMAs14�p�x] = [WMA_����_WMA�㏸�p�x]
  FROM [RealB_2370741683_FX_ACV_old].[indi].T_Indicator_6h as b
 WHERE [RealB_2370741683_FX_ACV].[hstr].tHour6.[�ʉ݃y�ANo] = b.[�ʉ݃y�ANo] AND [RealB_2370741683_FX_ACV].[hstr].tHour6.[StartDate] = b.[����]


UPDATE [RealB_2370741683_FX_ACV].[hstr].tMin5
   SET [����WMAs2] = [WMA_����_WMA_S2]
      ,[����WMAs2�p�x] = [WMA_����_WMA�㏸�p�x_S2]
      ,[����WMAs14] = [WMA_����_WMA]
      ,[����WMAs14�p�x] = [WMA_����_WMA�㏸�p�x]
      ,[����WMAs2] = [WMA_����_WMA_S2]
      ,[����WMAs2�p�x] = [WMA_����_WMA�㏸�p�x_S2]
      ,[����WMAs14] = [WMA_����_WMA]
      ,[����WMAs14�p�x] = [WMA_����_WMA�㏸�p�x]
  FROM [RealB_2370741683_FX_ACV_old].[indi].T_Indicator_5m as b
 WHERE [RealB_2370741683_FX_ACV].[hstr].tMin5.[�ʉ݃y�ANo] = b.[�ʉ݃y�ANo] AND [RealB_2370741683_FX_ACV].[hstr].tMin5.[StartDate] = b.[����]

UPDATE [RealB_2370741683_FX_ACV].[hstr].tMin30
   SET [����WMAs2] = [WMA_����_WMA_S2]
      ,[����WMAs2�p�x] = [WMA_����_WMA�㏸�p�x_S2]
      ,[����WMAs14] = [WMA_����_WMA]
      ,[����WMAs14�p�x] = [WMA_����_WMA�㏸�p�x]
      ,[����WMAs2] = [WMA_����_WMA_S2]
      ,[����WMAs2�p�x] = [WMA_����_WMA�㏸�p�x_S2]
      ,[����WMAs14] = [WMA_����_WMA]
      ,[����WMAs14�p�x] = [WMA_����_WMA�㏸�p�x]
  FROM [RealB_2370741683_FX_ACV_old].[indi].T_Indicator_30m as b
 WHERE [RealB_2370741683_FX_ACV].[hstr].tMin30.[�ʉ݃y�ANo] = b.[�ʉ݃y�ANo] AND [RealB_2370741683_FX_ACV].[hstr].tMin30.[StartDate] = b.[����]

UPDATE [RealB_2370741683_FX_ACV].[hstr].tMin1
   SET [����WMAs2] = [WMA_����_WMA_S2]
      ,[����WMAs2�p�x] = [WMA_����_WMA�㏸�p�x_S2]
      ,[����WMAs14] = [WMA_����_WMA]
      ,[����WMAs14�p�x] = [WMA_����_WMA�㏸�p�x]
      ,[����WMAs2] = [WMA_����_WMA_S2]
      ,[����WMAs2�p�x] = [WMA_����_WMA�㏸�p�x_S2]
      ,[����WMAs14] = [WMA_����_WMA]
      ,[����WMAs14�p�x] = [WMA_����_WMA�㏸�p�x]
  FROM [RealB_2370741683_FX_ACV_old].[indi].T_Indicator_1m as b
 WHERE [RealB_2370741683_FX_ACV].[hstr].tMin1.[�ʉ݃y�ANo] = b.[�ʉ݃y�ANo] AND [RealB_2370741683_FX_ACV].[hstr].tMin1.[StartDate] = b.[����]

UPDATE [RealB_2370741683_FX_ACV].[hstr].tHour1 
   SET [����WMAs2] = [WMA_����_WMA_S2]
      ,[����WMAs2�p�x] = [WMA_����_WMA�㏸�p�x_S2]
      ,[����WMAs14] = [WMA_����_WMA]
      ,[����WMAs14�p�x] = [WMA_����_WMA�㏸�p�x]
      ,[����WMAs2] = [WMA_����_WMA_S2]
      ,[����WMAs2�p�x] = [WMA_����_WMA�㏸�p�x_S2]
      ,[����WMAs14] = [WMA_����_WMA]
      ,[����WMAs14�p�x] = [WMA_����_WMA�㏸�p�x]
  FROM [RealB_2370741683_FX_ACV_old].[indi].T_Indicator_1h as b
 WHERE [RealB_2370741683_FX_ACV].[hstr].tHour1.[�ʉ݃y�ANo] = b.[�ʉ݃y�ANo] AND [RealB_2370741683_FX_ACV].[hstr].tHour1.[StartDate] = b.[����]

UPDATE [RealB_2370741683_FX_ACV].[hstr].[tMin15] 
   SET [����WMAs2] = [WMA_����_WMA_S2]
      ,[����WMAs2�p�x] = [WMA_����_WMA�㏸�p�x_S2]
      ,[����WMAs14] = [WMA_����_WMA]
      ,[����WMAs14�p�x] = [WMA_����_WMA�㏸�p�x]
      ,[����WMAs14�p�x�V�O�}] = [WMA_����_WMA�㏸�p�x_�V�O�}]
      ,[����WMAs2] = [WMA_����_WMA_S2]
      ,[����WMAs2�p�x] = [WMA_����_WMA�㏸�p�x_S2]
      ,[����WMAs14] = [WMA_����_WMA]
      ,[����WMAs14�p�x] = [WMA_����_WMA�㏸�p�x]
      ,[����WMAs14�p�x�V�O�}] = [WMA_����_WMA�㏸�p�x_�V�O�}]
  FROM [RealB_2370741683_FX_ACV_old].[indi].[T_Indicator_15m] as b
 WHERE [RealB_2370741683_FX_ACV].[hstr].[tMin15].[�ʉ݃y�ANo] = b.[�ʉ݃y�ANo] AND [RealB_2370741683_FX_ACV].[hstr].[tMin15].[StartDate] = b.[����]


INSERT INTO [RealB_2370741683_FX_ACV].[hstr].tWeek1
           ([�ʉ݃y�ANo]
           ,[StartDate]
           ,[����Rate_�n�l]
           ,[����Rate_���l]
           ,[����Rate_���l]
           ,[����Rate_�I�l]
           ,[����Rate_�n�l]
           ,[����Rate_���l]
           ,[����Rate_���l]
           ,[����Rate_�I�l])
SELECT [�ʉ݃y�ANo]
      ,[����]
      ,[Rate_�n�l_����]
      ,[Rate_���l_����]
      ,[Rate_���l_����]
      ,[Rate_�I�l_����]
      ,[Rate_�n�l_����]
      ,[Rate_���l_����]
      ,[Rate_���l_����]
      ,[Rate_�I�l_����]
  FROM [RealB_2370741683_FX_ACV_old].[fxcm].T_Rate_Weekly
  where [����] < (select MIN([StartDate]) from [RealB_2370741683_FX_ACV].[hstr].tWeek1)

INSERT INTO [RealB_2370741683_FX_ACV].[hstr].[tMin1]
           ([�ʉ݃y�ANo]
           ,[StartDate]
           ,[����Rate_�n�l]
           ,[����Rate_���l]
           ,[����Rate_���l]
           ,[����Rate_�I�l]
           ,[����Rate_�n�l]
           ,[����Rate_���l]
           ,[����Rate_���l]
           ,[����Rate_�I�l])
SELECT [�ʉ݃y�ANo]
      ,[����]
      ,[Rate_�n�l_����]
      ,[Rate_���l_����]
      ,[Rate_���l_����]
      ,[Rate_�I�l_����]
      ,[Rate_�n�l_����]
      ,[Rate_���l_����]
      ,[Rate_���l_����]
      ,[Rate_�I�l_����]
  FROM [RealB_2370741683_FX_ACV_old].[fxcm].[T_Rate_1m]
  where [����] < (select MIN([StartDate]) from [RealB_2370741683_FX_ACV].[hstr].[tMin1])

INSERT INTO [RealB_2370741683_FX_ACV].[hstr].[tMin15]
           ([�ʉ݃y�ANo]
           ,[StartDate]
           ,[����Rate_�n�l]
           ,[����Rate_���l]
           ,[����Rate_���l]
           ,[����Rate_�I�l]
           ,[����Rate_�n�l]
           ,[����Rate_���l]
           ,[����Rate_���l]
           ,[����Rate_�I�l])
SELECT [�ʉ݃y�ANo]
      ,[����]
      ,[Rate_�n�l_����]
      ,[Rate_���l_����]
      ,[Rate_���l_����]
      ,[Rate_�I�l_����]
      ,[Rate_�n�l_����]
      ,[Rate_���l_����]
      ,[Rate_���l_����]
      ,[Rate_�I�l_����]
  FROM [RealB_2370741683_FX_ACV_old].[fxcm].[T_Rate_15m]
  where [����] < (select MIN([StartDate]) from [RealB_2370741683_FX_ACV].[hstr].[tMin15])

INSERT INTO [RealB_2370741683_FX_ACV].[hstr].tWeek1
           ([�ʉ݃y�ANo]
           ,[StartDate]
           ,[����Rate_�n�l]
           ,[����Rate_���l]
           ,[����Rate_���l]
           ,[����Rate_�I�l]
           ,[����Rate_�n�l]
           ,[����Rate_���l]
           ,[����Rate_���l]
           ,[����Rate_�I�l])
SELECT [�ʉ݃y�ANo]
      ,[����]
      ,[����_�n�l]
      ,[����_���l]
      ,[����_���l]
      ,[����_�I�l]
      ,[����_�n�l]
      ,[����_���l]
      ,[����_���l]
      ,[����_�I�l]
  FROM [RealB_2370741683_FX_ACV_old].[dbo].T_RateHistory_Weekly


INSERT INTO [RealB_2370741683_FX_ACV].[hstr].tMonth1
           ([�ʉ݃y�ANo]
           ,[StartDate]
           ,[����Rate_�n�l]
           ,[����Rate_���l]
           ,[����Rate_���l]
           ,[����Rate_�I�l]
           ,[����Rate_�n�l]
           ,[����Rate_���l]
           ,[����Rate_���l]
           ,[����Rate_�I�l])
SELECT [�ʉ݃y�ANo]
      ,[����]
      ,[����_�n�l]
      ,[����_���l]
      ,[����_���l]
      ,[����_�I�l]
      ,[����_�n�l]
      ,[����_���l]
      ,[����_���l]
      ,[����_�I�l]
  FROM [RealB_2370741683_FX_ACV_old].[dbo].T_RateHistory_Monthly


INSERT INTO [RealB_2370741683_FX_ACV].[hstr].tHour1
           ([�ʉ݃y�ANo]
           ,[StartDate]
           ,[����Rate_�n�l]
           ,[����Rate_���l]
           ,[����Rate_���l]
           ,[����Rate_�I�l]
           ,[����Rate_�n�l]
           ,[����Rate_���l]
           ,[����Rate_���l]
           ,[����Rate_�I�l])
SELECT [�ʉ݃y�ANo]
      ,[����]
      ,[����_�n�l]
      ,[����_���l]
      ,[����_���l]
      ,[����_�I�l]
      ,[����_�n�l]
      ,[����_���l]
      ,[����_���l]
      ,[����_�I�l]
  FROM [RealB_2370741683_FX_ACV_old].[dbo].T_RateHistory_Hourly
  where [����] < (select MIN([StartDate]) from [RealB_2370741683_FX_ACV].[hstr].tHour1)

INSERT INTO [RealB_2370741683_FX_ACV].[hstr].tDay1
           ([�ʉ݃y�ANo]
           ,[StartDate]
           ,[����Rate_�n�l]
           ,[����Rate_���l]
           ,[����Rate_���l]
           ,[����Rate_�I�l]
           ,[����Rate_�n�l]
           ,[����Rate_���l]
           ,[����Rate_���l]
           ,[����Rate_�I�l])
SELECT [�ʉ݃y�ANo]
      ,[����]
      ,[����_�n�l]
      ,[����_���l]
      ,[����_���l]
      ,[����_�I�l]
      ,[����_�n�l]
      ,[����_���l]
      ,[����_���l]
      ,[����_�I�l]
  FROM [RealB_2370741683_FX_ACV_old].[dbo].[T_RateHistory_Daily]

INSERT INTO [RealB_2370741683_FX_ACV].[hstr].tHour6
           ([�ʉ݃y�ANo]
           ,[StartDate]
           ,[����Rate_�n�l]
           ,[����Rate_���l]
           ,[����Rate_���l]
           ,[����Rate_�I�l]
           ,[����Rate_�n�l]
           ,[����Rate_���l]
           ,[����Rate_���l]
           ,[����Rate_�I�l])
SELECT [�ʉ݃y�ANo]
      ,[����]
      ,[����_�n�l]
      ,[����_���l]
      ,[����_���l]
      ,[����_�I�l]
      ,[����_�n�l]
      ,[����_���l]
      ,[����_���l]
      ,[����_�I�l]
  FROM [RealB_2370741683_FX_ACV_old].[dbo].[T_RateHistory_6h]

INSERT INTO [RealB_2370741683_FX_ACV].[hstr].[tMin30]
           ([�ʉ݃y�ANo]
           ,[StartDate]
           ,[����Rate_�n�l]
           ,[����Rate_���l]
           ,[����Rate_���l]
           ,[����Rate_�I�l]
           ,[����Rate_�n�l]
           ,[����Rate_���l]
           ,[����Rate_���l]
           ,[����Rate_�I�l])
SELECT [�ʉ݃y�ANo]
      ,[����]
      ,[����_�n�l]
      ,[����_���l]
      ,[����_���l]
      ,[����_�I�l]
      ,[����_�n�l]
      ,[����_���l]
      ,[����_���l]
      ,[����_�I�l]
  FROM [RealB_2370741683_FX_ACV_old].[dbo].[T_RateHistory_30m]


*/
