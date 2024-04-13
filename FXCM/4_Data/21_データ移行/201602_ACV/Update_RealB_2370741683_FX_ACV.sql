UPDATE [RealB_2370741683_FX_ACV].[hstr].tMin15
   SET [買いWMAs2] = [WMA_買い_WMA_S2]
      ,[買いWMAs2角度] = [WMA_買い_WMA上昇角度_S2]
      ,[買いWMAs14] = [WMA_買い_WMA]
      ,[買いWMAs14角度] = [WMA_買い_WMA上昇角度]
      ,[買いWMAs14角度シグマ] = [WMA_買い_WMA上昇角度_シグマ]
      ,[売りWMAs2] = [WMA_売り_WMA_S2]
      ,[売りWMAs2角度] = [WMA_売り_WMA上昇角度_S2]
      ,[売りWMAs14] = [WMA_売り_WMA]
      ,[売りWMAs14角度] = [WMA_売り_WMA上昇角度]
      ,[売りWMAs14角度シグマ] = [WMA_売り_WMA上昇角度_シグマ]
  FROM [RealB_2370741683_FX_ACV_old].acv.T_Indicator_15m_Past as b
 WHERE [RealB_2370741683_FX_ACV].[hstr].tMin15.[通貨ペアNo] = b.[通貨ペアNo] AND [RealB_2370741683_FX_ACV].hstr.tMin15.[StartDate] = b.[日時]

/*
UPDATE [RealB_2370741683_FX_ACV].[hstr].tWeek1
   SET [買いWMAs2] = [WMA_買い_WMA_S2]
      ,[買いWMAs2角度] = [WMA_買い_WMA上昇角度_S2]
      ,[買いWMAs14] = [WMA_買い_WMA]
      ,[買いWMAs14角度] = [WMA_買い_WMA上昇角度]
      ,[売りWMAs2] = [WMA_売り_WMA_S2]
      ,[売りWMAs2角度] = [WMA_売り_WMA上昇角度_S2]
      ,[売りWMAs14] = [WMA_売り_WMA]
      ,[売りWMAs14角度] = [WMA_売り_WMA上昇角度]
  FROM [RealB_2370741683_FX_ACV_old].acv.T_Indicator_Weekly_Past as b
 WHERE [RealB_2370741683_FX_ACV].[hstr].tWeek1.[通貨ペアNo] = b.[通貨ペアNo] AND [RealB_2370741683_FX_ACV].hstr.tWeek1.[StartDate] = b.[日時]


UPDATE [RealB_2370741683_FX_ACV].[hstr].tHour1
   SET [買いWMAs2] = [WMA_買い_WMA_S2]
      ,[買いWMAs2角度] = [WMA_買い_WMA上昇角度_S2]
      ,[買いWMAs14] = [WMA_買い_WMA]
      ,[買いWMAs14角度] = [WMA_買い_WMA上昇角度]
      ,[売りWMAs2] = [WMA_売り_WMA_S2]
      ,[売りWMAs2角度] = [WMA_売り_WMA上昇角度_S2]
      ,[売りWMAs14] = [WMA_売り_WMA]
      ,[売りWMAs14角度] = [WMA_売り_WMA上昇角度]
  FROM [RealB_2370741683_FX_ACV_old].acv.T_Indicator_1h_Past as b
 WHERE [RealB_2370741683_FX_ACV].[hstr].tHour1.[通貨ペアNo] = b.[通貨ペアNo] AND [RealB_2370741683_FX_ACV].hstr.tHour1.[StartDate] = b.[日時]


UPDATE [RealB_2370741683_FX_ACV].[hstr].tWeek1
   SET [買いWMAs2] = [WMA_買い_WMA_S2]
      ,[買いWMAs2角度] = [WMA_買い_WMA上昇角度_S2]
      ,[買いWMAs14] = [WMA_買い_WMA]
      ,[買いWMAs14角度] = [WMA_買い_WMA上昇角度]
      ,[売りWMAs2] = [WMA_売り_WMA_S2]
      ,[売りWMAs2角度] = [WMA_売り_WMA上昇角度_S2]
      ,[売りWMAs14] = [WMA_売り_WMA]
      ,[売りWMAs14角度] = [WMA_売り_WMA上昇角度]
  FROM [RealB_2370741683_FX_ACV_old].[indi].T_Indicator_Weekly as b
 WHERE [RealB_2370741683_FX_ACV].[hstr].tWeek1.[通貨ペアNo] = b.[通貨ペアNo] AND [RealB_2370741683_FX_ACV].[hstr].tWeek1.[StartDate] = b.[日時]

UPDATE [RealB_2370741683_FX_ACV].[hstr].tMonth1
   SET [買いWMAs2] = [WMA_買い_WMA_S2]
      ,[買いWMAs2角度] = [WMA_買い_WMA上昇角度_S2]
      ,[買いWMAs14] = [WMA_買い_WMA]
      ,[買いWMAs14角度] = [WMA_買い_WMA上昇角度]
      ,[売りWMAs2] = [WMA_売り_WMA_S2]
      ,[売りWMAs2角度] = [WMA_売り_WMA上昇角度_S2]
      ,[売りWMAs14] = [WMA_売り_WMA]
      ,[売りWMAs14角度] = [WMA_売り_WMA上昇角度]
  FROM [RealB_2370741683_FX_ACV_old].[indi].T_Indicator_Monthly as b
 WHERE [RealB_2370741683_FX_ACV].[hstr].tMonth1.[通貨ペアNo] = b.[通貨ペアNo] AND [RealB_2370741683_FX_ACV].[hstr].tMonth1.[StartDate] = b.[日時]

UPDATE [RealB_2370741683_FX_ACV].[hstr].tDay1
   SET [買いWMAs2] = [WMA_買い_WMA_S2]
      ,[買いWMAs2角度] = [WMA_買い_WMA上昇角度_S2]
      ,[買いWMAs14] = [WMA_買い_WMA]
      ,[買いWMAs14角度] = [WMA_買い_WMA上昇角度]
      ,[売りWMAs2] = [WMA_売り_WMA_S2]
      ,[売りWMAs2角度] = [WMA_売り_WMA上昇角度_S2]
      ,[売りWMAs14] = [WMA_売り_WMA]
      ,[売りWMAs14角度] = [WMA_売り_WMA上昇角度]
  FROM [RealB_2370741683_FX_ACV_old].[indi].T_Indicator_Daily as b
 WHERE [RealB_2370741683_FX_ACV].[hstr].tDay1.[通貨ペアNo] = b.[通貨ペアNo] AND [RealB_2370741683_FX_ACV].[hstr].tDay1.[StartDate] = b.[日時]

UPDATE [RealB_2370741683_FX_ACV].[hstr].tHour6
   SET [買いWMAs2] = [WMA_買い_WMA_S2]
      ,[買いWMAs2角度] = [WMA_買い_WMA上昇角度_S2]
      ,[買いWMAs14] = [WMA_買い_WMA]
      ,[買いWMAs14角度] = [WMA_買い_WMA上昇角度]
      ,[売りWMAs2] = [WMA_売り_WMA_S2]
      ,[売りWMAs2角度] = [WMA_売り_WMA上昇角度_S2]
      ,[売りWMAs14] = [WMA_売り_WMA]
      ,[売りWMAs14角度] = [WMA_売り_WMA上昇角度]
  FROM [RealB_2370741683_FX_ACV_old].[indi].T_Indicator_6h as b
 WHERE [RealB_2370741683_FX_ACV].[hstr].tHour6.[通貨ペアNo] = b.[通貨ペアNo] AND [RealB_2370741683_FX_ACV].[hstr].tHour6.[StartDate] = b.[日時]


UPDATE [RealB_2370741683_FX_ACV].[hstr].tMin5
   SET [買いWMAs2] = [WMA_買い_WMA_S2]
      ,[買いWMAs2角度] = [WMA_買い_WMA上昇角度_S2]
      ,[買いWMAs14] = [WMA_買い_WMA]
      ,[買いWMAs14角度] = [WMA_買い_WMA上昇角度]
      ,[売りWMAs2] = [WMA_売り_WMA_S2]
      ,[売りWMAs2角度] = [WMA_売り_WMA上昇角度_S2]
      ,[売りWMAs14] = [WMA_売り_WMA]
      ,[売りWMAs14角度] = [WMA_売り_WMA上昇角度]
  FROM [RealB_2370741683_FX_ACV_old].[indi].T_Indicator_5m as b
 WHERE [RealB_2370741683_FX_ACV].[hstr].tMin5.[通貨ペアNo] = b.[通貨ペアNo] AND [RealB_2370741683_FX_ACV].[hstr].tMin5.[StartDate] = b.[日時]

UPDATE [RealB_2370741683_FX_ACV].[hstr].tMin30
   SET [買いWMAs2] = [WMA_買い_WMA_S2]
      ,[買いWMAs2角度] = [WMA_買い_WMA上昇角度_S2]
      ,[買いWMAs14] = [WMA_買い_WMA]
      ,[買いWMAs14角度] = [WMA_買い_WMA上昇角度]
      ,[売りWMAs2] = [WMA_売り_WMA_S2]
      ,[売りWMAs2角度] = [WMA_売り_WMA上昇角度_S2]
      ,[売りWMAs14] = [WMA_売り_WMA]
      ,[売りWMAs14角度] = [WMA_売り_WMA上昇角度]
  FROM [RealB_2370741683_FX_ACV_old].[indi].T_Indicator_30m as b
 WHERE [RealB_2370741683_FX_ACV].[hstr].tMin30.[通貨ペアNo] = b.[通貨ペアNo] AND [RealB_2370741683_FX_ACV].[hstr].tMin30.[StartDate] = b.[日時]

UPDATE [RealB_2370741683_FX_ACV].[hstr].tMin1
   SET [買いWMAs2] = [WMA_買い_WMA_S2]
      ,[買いWMAs2角度] = [WMA_買い_WMA上昇角度_S2]
      ,[買いWMAs14] = [WMA_買い_WMA]
      ,[買いWMAs14角度] = [WMA_買い_WMA上昇角度]
      ,[売りWMAs2] = [WMA_売り_WMA_S2]
      ,[売りWMAs2角度] = [WMA_売り_WMA上昇角度_S2]
      ,[売りWMAs14] = [WMA_売り_WMA]
      ,[売りWMAs14角度] = [WMA_売り_WMA上昇角度]
  FROM [RealB_2370741683_FX_ACV_old].[indi].T_Indicator_1m as b
 WHERE [RealB_2370741683_FX_ACV].[hstr].tMin1.[通貨ペアNo] = b.[通貨ペアNo] AND [RealB_2370741683_FX_ACV].[hstr].tMin1.[StartDate] = b.[日時]

UPDATE [RealB_2370741683_FX_ACV].[hstr].tHour1 
   SET [買いWMAs2] = [WMA_買い_WMA_S2]
      ,[買いWMAs2角度] = [WMA_買い_WMA上昇角度_S2]
      ,[買いWMAs14] = [WMA_買い_WMA]
      ,[買いWMAs14角度] = [WMA_買い_WMA上昇角度]
      ,[売りWMAs2] = [WMA_売り_WMA_S2]
      ,[売りWMAs2角度] = [WMA_売り_WMA上昇角度_S2]
      ,[売りWMAs14] = [WMA_売り_WMA]
      ,[売りWMAs14角度] = [WMA_売り_WMA上昇角度]
  FROM [RealB_2370741683_FX_ACV_old].[indi].T_Indicator_1h as b
 WHERE [RealB_2370741683_FX_ACV].[hstr].tHour1.[通貨ペアNo] = b.[通貨ペアNo] AND [RealB_2370741683_FX_ACV].[hstr].tHour1.[StartDate] = b.[日時]

UPDATE [RealB_2370741683_FX_ACV].[hstr].[tMin15] 
   SET [買いWMAs2] = [WMA_買い_WMA_S2]
      ,[買いWMAs2角度] = [WMA_買い_WMA上昇角度_S2]
      ,[買いWMAs14] = [WMA_買い_WMA]
      ,[買いWMAs14角度] = [WMA_買い_WMA上昇角度]
      ,[買いWMAs14角度シグマ] = [WMA_買い_WMA上昇角度_シグマ]
      ,[売りWMAs2] = [WMA_売り_WMA_S2]
      ,[売りWMAs2角度] = [WMA_売り_WMA上昇角度_S2]
      ,[売りWMAs14] = [WMA_売り_WMA]
      ,[売りWMAs14角度] = [WMA_売り_WMA上昇角度]
      ,[売りWMAs14角度シグマ] = [WMA_売り_WMA上昇角度_シグマ]
  FROM [RealB_2370741683_FX_ACV_old].[indi].[T_Indicator_15m] as b
 WHERE [RealB_2370741683_FX_ACV].[hstr].[tMin15].[通貨ペアNo] = b.[通貨ペアNo] AND [RealB_2370741683_FX_ACV].[hstr].[tMin15].[StartDate] = b.[日時]


INSERT INTO [RealB_2370741683_FX_ACV].[hstr].tWeek1
           ([通貨ペアNo]
           ,[StartDate]
           ,[買いRate_始値]
           ,[買いRate_高値]
           ,[買いRate_安値]
           ,[買いRate_終値]
           ,[売りRate_始値]
           ,[売りRate_高値]
           ,[売りRate_安値]
           ,[売りRate_終値])
SELECT [通貨ペアNo]
      ,[日時]
      ,[Rate_始値_買い]
      ,[Rate_高値_買い]
      ,[Rate_安値_買い]
      ,[Rate_終値_買い]
      ,[Rate_始値_売り]
      ,[Rate_高値_売り]
      ,[Rate_安値_売り]
      ,[Rate_終値_売り]
  FROM [RealB_2370741683_FX_ACV_old].[fxcm].T_Rate_Weekly
  where [日時] < (select MIN([StartDate]) from [RealB_2370741683_FX_ACV].[hstr].tWeek1)

INSERT INTO [RealB_2370741683_FX_ACV].[hstr].[tMin1]
           ([通貨ペアNo]
           ,[StartDate]
           ,[買いRate_始値]
           ,[買いRate_高値]
           ,[買いRate_安値]
           ,[買いRate_終値]
           ,[売りRate_始値]
           ,[売りRate_高値]
           ,[売りRate_安値]
           ,[売りRate_終値])
SELECT [通貨ペアNo]
      ,[日時]
      ,[Rate_始値_買い]
      ,[Rate_高値_買い]
      ,[Rate_安値_買い]
      ,[Rate_終値_買い]
      ,[Rate_始値_売り]
      ,[Rate_高値_売り]
      ,[Rate_安値_売り]
      ,[Rate_終値_売り]
  FROM [RealB_2370741683_FX_ACV_old].[fxcm].[T_Rate_1m]
  where [日時] < (select MIN([StartDate]) from [RealB_2370741683_FX_ACV].[hstr].[tMin1])

INSERT INTO [RealB_2370741683_FX_ACV].[hstr].[tMin15]
           ([通貨ペアNo]
           ,[StartDate]
           ,[買いRate_始値]
           ,[買いRate_高値]
           ,[買いRate_安値]
           ,[買いRate_終値]
           ,[売りRate_始値]
           ,[売りRate_高値]
           ,[売りRate_安値]
           ,[売りRate_終値])
SELECT [通貨ペアNo]
      ,[日時]
      ,[Rate_始値_買い]
      ,[Rate_高値_買い]
      ,[Rate_安値_買い]
      ,[Rate_終値_買い]
      ,[Rate_始値_売り]
      ,[Rate_高値_売り]
      ,[Rate_安値_売り]
      ,[Rate_終値_売り]
  FROM [RealB_2370741683_FX_ACV_old].[fxcm].[T_Rate_15m]
  where [日時] < (select MIN([StartDate]) from [RealB_2370741683_FX_ACV].[hstr].[tMin15])

INSERT INTO [RealB_2370741683_FX_ACV].[hstr].tWeek1
           ([通貨ペアNo]
           ,[StartDate]
           ,[買いRate_始値]
           ,[買いRate_高値]
           ,[買いRate_安値]
           ,[買いRate_終値]
           ,[売りRate_始値]
           ,[売りRate_高値]
           ,[売りRate_安値]
           ,[売りRate_終値])
SELECT [通貨ペアNo]
      ,[日時]
      ,[買い_始値]
      ,[買い_高値]
      ,[買い_安値]
      ,[買い_終値]
      ,[売り_始値]
      ,[売り_高値]
      ,[売り_安値]
      ,[売り_終値]
  FROM [RealB_2370741683_FX_ACV_old].[dbo].T_RateHistory_Weekly


INSERT INTO [RealB_2370741683_FX_ACV].[hstr].tMonth1
           ([通貨ペアNo]
           ,[StartDate]
           ,[買いRate_始値]
           ,[買いRate_高値]
           ,[買いRate_安値]
           ,[買いRate_終値]
           ,[売りRate_始値]
           ,[売りRate_高値]
           ,[売りRate_安値]
           ,[売りRate_終値])
SELECT [通貨ペアNo]
      ,[日時]
      ,[買い_始値]
      ,[買い_高値]
      ,[買い_安値]
      ,[買い_終値]
      ,[売り_始値]
      ,[売り_高値]
      ,[売り_安値]
      ,[売り_終値]
  FROM [RealB_2370741683_FX_ACV_old].[dbo].T_RateHistory_Monthly


INSERT INTO [RealB_2370741683_FX_ACV].[hstr].tHour1
           ([通貨ペアNo]
           ,[StartDate]
           ,[買いRate_始値]
           ,[買いRate_高値]
           ,[買いRate_安値]
           ,[買いRate_終値]
           ,[売りRate_始値]
           ,[売りRate_高値]
           ,[売りRate_安値]
           ,[売りRate_終値])
SELECT [通貨ペアNo]
      ,[日時]
      ,[買い_始値]
      ,[買い_高値]
      ,[買い_安値]
      ,[買い_終値]
      ,[売り_始値]
      ,[売り_高値]
      ,[売り_安値]
      ,[売り_終値]
  FROM [RealB_2370741683_FX_ACV_old].[dbo].T_RateHistory_Hourly
  where [日時] < (select MIN([StartDate]) from [RealB_2370741683_FX_ACV].[hstr].tHour1)

INSERT INTO [RealB_2370741683_FX_ACV].[hstr].tDay1
           ([通貨ペアNo]
           ,[StartDate]
           ,[買いRate_始値]
           ,[買いRate_高値]
           ,[買いRate_安値]
           ,[買いRate_終値]
           ,[売りRate_始値]
           ,[売りRate_高値]
           ,[売りRate_安値]
           ,[売りRate_終値])
SELECT [通貨ペアNo]
      ,[日時]
      ,[買い_始値]
      ,[買い_高値]
      ,[買い_安値]
      ,[買い_終値]
      ,[売り_始値]
      ,[売り_高値]
      ,[売り_安値]
      ,[売り_終値]
  FROM [RealB_2370741683_FX_ACV_old].[dbo].[T_RateHistory_Daily]

INSERT INTO [RealB_2370741683_FX_ACV].[hstr].tHour6
           ([通貨ペアNo]
           ,[StartDate]
           ,[買いRate_始値]
           ,[買いRate_高値]
           ,[買いRate_安値]
           ,[買いRate_終値]
           ,[売りRate_始値]
           ,[売りRate_高値]
           ,[売りRate_安値]
           ,[売りRate_終値])
SELECT [通貨ペアNo]
      ,[日時]
      ,[買い_始値]
      ,[買い_高値]
      ,[買い_安値]
      ,[買い_終値]
      ,[売り_始値]
      ,[売り_高値]
      ,[売り_安値]
      ,[売り_終値]
  FROM [RealB_2370741683_FX_ACV_old].[dbo].[T_RateHistory_6h]

INSERT INTO [RealB_2370741683_FX_ACV].[hstr].[tMin30]
           ([通貨ペアNo]
           ,[StartDate]
           ,[買いRate_始値]
           ,[買いRate_高値]
           ,[買いRate_安値]
           ,[買いRate_終値]
           ,[売りRate_始値]
           ,[売りRate_高値]
           ,[売りRate_安値]
           ,[売りRate_終値])
SELECT [通貨ペアNo]
      ,[日時]
      ,[買い_始値]
      ,[買い_高値]
      ,[買い_安値]
      ,[買い_終値]
      ,[売り_始値]
      ,[売り_高値]
      ,[売り_安値]
      ,[売り_終値]
  FROM [RealB_2370741683_FX_ACV_old].[dbo].[T_RateHistory_30m]


*/
