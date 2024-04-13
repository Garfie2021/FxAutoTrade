UPDATE [RealA_FX_ACV].[hstr].tWeek1
   SET [’WMAs2] = [WMA_’_WMA_S2]
      ,[’WMAs2px] = [WMA_’_WMAγΈpx_S2]
      ,[’WMAs14] = [WMA_’_WMA]
      ,[’WMAs14px] = [WMA_’_WMAγΈpx]
      ,[θWMAs2] = [WMA_θ_WMA_S2]
      ,[θWMAs2px] = [WMA_θ_WMAγΈpx_S2]
      ,[θWMAs14] = [WMA_θ_WMA]
      ,[θWMAs14px] = [WMA_θ_WMAγΈpx]
  FROM [RealA_FX_ACV_old].[indi].T_Indicator_Weekly as b
 WHERE [RealA_FX_ACV].[hstr].tWeek1.[ΚέyANo] = b.[ΚέyANo] AND [RealA_FX_ACV].[hstr].tWeek1.[StartDate] = b.[ϊ]

/*
UPDATE [RealA_FX_ACV].[hstr].tMonth1
   SET [’WMAs2] = [WMA_’_WMA_S2]
      ,[’WMAs2px] = [WMA_’_WMAγΈpx_S2]
      ,[’WMAs14] = [WMA_’_WMA]
      ,[’WMAs14px] = [WMA_’_WMAγΈpx]
      ,[θWMAs2] = [WMA_θ_WMA_S2]
      ,[θWMAs2px] = [WMA_θ_WMAγΈpx_S2]
      ,[θWMAs14] = [WMA_θ_WMA]
      ,[θWMAs14px] = [WMA_θ_WMAγΈpx]
  FROM [RealA_FX_ACV_old].[indi].T_Indicator_Monthly as b
 WHERE [RealA_FX_ACV].[hstr].tMonth1.[ΚέyANo] = b.[ΚέyANo] AND [RealA_FX_ACV].[hstr].tMonth1.[StartDate] = b.[ϊ]

UPDATE [RealA_FX_ACV].[hstr].tDay1
   SET [’WMAs2] = [WMA_’_WMA_S2]
      ,[’WMAs2px] = [WMA_’_WMAγΈpx_S2]
      ,[’WMAs14] = [WMA_’_WMA]
      ,[’WMAs14px] = [WMA_’_WMAγΈpx]
      ,[θWMAs2] = [WMA_θ_WMA_S2]
      ,[θWMAs2px] = [WMA_θ_WMAγΈpx_S2]
      ,[θWMAs14] = [WMA_θ_WMA]
      ,[θWMAs14px] = [WMA_θ_WMAγΈpx]
  FROM [RealA_FX_ACV_old].[indi].T_Indicator_Daily as b
 WHERE [RealA_FX_ACV].[hstr].tDay1.[ΚέyANo] = b.[ΚέyANo] AND [RealA_FX_ACV].[hstr].tDay1.[StartDate] = b.[ϊ]

UPDATE [RealA_FX_ACV].[hstr].tHour6
   SET [’WMAs2] = [WMA_’_WMA_S2]
      ,[’WMAs2px] = [WMA_’_WMAγΈpx_S2]
      ,[’WMAs14] = [WMA_’_WMA]
      ,[’WMAs14px] = [WMA_’_WMAγΈpx]
      ,[θWMAs2] = [WMA_θ_WMA_S2]
      ,[θWMAs2px] = [WMA_θ_WMAγΈpx_S2]
      ,[θWMAs14] = [WMA_θ_WMA]
      ,[θWMAs14px] = [WMA_θ_WMAγΈpx]
  FROM [RealA_FX_ACV_old].[indi].T_Indicator_6h as b
 WHERE [RealA_FX_ACV].[hstr].tHour6.[ΚέyANo] = b.[ΚέyANo] AND [RealA_FX_ACV].[hstr].tHour6.[StartDate] = b.[ϊ]

UPDATE [RealA_FX_ACV].[hstr].tMin30
   SET [’WMAs2] = [WMA_’_WMA_S2]
      ,[’WMAs2px] = [WMA_’_WMAγΈpx_S2]
      ,[’WMAs14] = [WMA_’_WMA]
      ,[’WMAs14px] = [WMA_’_WMAγΈpx]
      ,[θWMAs2] = [WMA_θ_WMA_S2]
      ,[θWMAs2px] = [WMA_θ_WMAγΈpx_S2]
      ,[θWMAs14] = [WMA_θ_WMA]
      ,[θWMAs14px] = [WMA_θ_WMAγΈpx]
  FROM [RealA_FX_ACV_old].[indi].T_Indicator_30m as b
 WHERE [RealA_FX_ACV].[hstr].tMin30.[ΚέyANo] = b.[ΚέyANo] AND [RealA_FX_ACV].[hstr].tMin30.[StartDate] = b.[ϊ]

UPDATE [RealA_FX_ACV].[hstr].tMin1
   SET [’WMAs2] = [WMA_’_WMA_S2]
      ,[’WMAs2px] = [WMA_’_WMAγΈpx_S2]
      ,[’WMAs14] = [WMA_’_WMA]
      ,[’WMAs14px] = [WMA_’_WMAγΈpx]
      ,[θWMAs2] = [WMA_θ_WMA_S2]
      ,[θWMAs2px] = [WMA_θ_WMAγΈpx_S2]
      ,[θWMAs14] = [WMA_θ_WMA]
      ,[θWMAs14px] = [WMA_θ_WMAγΈpx]
  FROM [RealA_FX_ACV_old].[indi].T_Indicator_1m as b
 WHERE [RealA_FX_ACV].[hstr].tMin1.[ΚέyANo] = b.[ΚέyANo] AND [RealA_FX_ACV].[hstr].tMin1.[StartDate] = b.[ϊ]

UPDATE [RealA_FX_ACV].[hstr].tHour1 
   SET [’WMAs2] = [WMA_’_WMA_S2]
      ,[’WMAs2px] = [WMA_’_WMAγΈpx_S2]
      ,[’WMAs14] = [WMA_’_WMA]
      ,[’WMAs14px] = [WMA_’_WMAγΈpx]
      ,[θWMAs2] = [WMA_θ_WMA_S2]
      ,[θWMAs2px] = [WMA_θ_WMAγΈpx_S2]
      ,[θWMAs14] = [WMA_θ_WMA]
      ,[θWMAs14px] = [WMA_θ_WMAγΈpx]
  FROM [RealA_FX_ACV_old].[indi].T_Indicator_1h as b
 WHERE [RealA_FX_ACV].[hstr].tHour1.[ΚέyANo] = b.[ΚέyANo] AND [RealA_FX_ACV].[hstr].tHour1.[StartDate] = b.[ϊ]


UPDATE [RealA_FX_ACV].[hstr].[tMin15] 
   SET [’WMAs2] = [WMA_’_WMA_S2]
      ,[’WMAs2px] = [WMA_’_WMAγΈpx_S2]
      ,[’WMAs14] = [WMA_’_WMA]
      ,[’WMAs14px] = [WMA_’_WMAγΈpx]
      ,[’WMAs14pxVO}] = [WMA_’_WMAγΈpx_VO}]
      ,[θWMAs2] = [WMA_θ_WMA_S2]
      ,[θWMAs2px] = [WMA_θ_WMAγΈpx_S2]
      ,[θWMAs14] = [WMA_θ_WMA]
      ,[θWMAs14px] = [WMA_θ_WMAγΈpx]
      ,[θWMAs14pxVO}] = [WMA_θ_WMAγΈpx_VO}]
  FROM [RealA_FX_ACV_old].[indi].[T_Indicator_15m] as b
 WHERE [RealA_FX_ACV].[hstr].[tMin15].[ΚέyANo] = b.[ΚέyANo] AND [RealA_FX_ACV].[hstr].[tMin15].[StartDate] = b.[ϊ]




INSERT INTO [RealA_FX_ACV].[hstr].tWeek1
           ([ΚέyANo]
           ,[StartDate]
           ,[’Rate_nl]
           ,[’Rate_l]
           ,[’Rate_ΐl]
           ,[’Rate_Il]
           ,[θRate_nl]
           ,[θRate_l]
           ,[θRate_ΐl]
           ,[θRate_Il])
SELECT [ΚέyANo]
      ,[ϊ]
      ,[Rate_nl_’]
      ,[Rate_l_’]
      ,[Rate_ΐl_’]
      ,[Rate_Il_’]
      ,[Rate_nl_θ]
      ,[Rate_l_θ]
      ,[Rate_ΐl_θ]
      ,[Rate_Il_θ]
  FROM [RealA_FX_ACV_old].[fxcm].T_Rate_Weekly
  where [ϊ] < (select MIN([StartDate]) from [RealA_FX_ACV].[hstr].tWeek1)

INSERT INTO [RealA_FX_ACV].[hstr].[tMin15]
           ([ΚέyANo]
           ,[StartDate]
           ,[’Rate_nl]
           ,[’Rate_l]
           ,[’Rate_ΐl]
           ,[’Rate_Il]
           ,[θRate_nl]
           ,[θRate_l]
           ,[θRate_ΐl]
           ,[θRate_Il])
SELECT [ΚέyANo]
      ,[ϊ]
      ,[Rate_nl_’]
      ,[Rate_l_’]
      ,[Rate_ΐl_’]
      ,[Rate_Il_’]
      ,[Rate_nl_θ]
      ,[Rate_l_θ]
      ,[Rate_ΐl_θ]
      ,[Rate_Il_θ]
  FROM [RealA_FX_ACV_old].[fxcm].[T_Rate_15m]
  where [ϊ] < (select MIN([StartDate]) from [RealA_FX_ACV].[hstr].[tMin15])

INSERT INTO [RealA_FX_ACV].[hstr].tWeek1
           ([ΚέyANo]
           ,[StartDate]
           ,[’Rate_nl]
           ,[’Rate_l]
           ,[’Rate_ΐl]
           ,[’Rate_Il]
           ,[θRate_nl]
           ,[θRate_l]
           ,[θRate_ΐl]
           ,[θRate_Il])
SELECT [ΚέyANo]
      ,[ϊ]
      ,[’_nl]
      ,[’_l]
      ,[’_ΐl]
      ,[’_Il]
      ,[θ_nl]
      ,[θ_l]
      ,[θ_ΐl]
      ,[θ_Il]
  FROM [RealA_FX_ACV_old].[dbo].T_RateHistory_Weekly
  where [ϊ] < (select MIN([StartDate]) from [RealA_FX_ACV].[hstr].tWeek1)

INSERT INTO [RealA_FX_ACV].[hstr].tMonth1
           ([ΚέyANo]
           ,[StartDate]
           ,[’Rate_nl]
           ,[’Rate_l]
           ,[’Rate_ΐl]
           ,[’Rate_Il]
           ,[θRate_nl]
           ,[θRate_l]
           ,[θRate_ΐl]
           ,[θRate_Il])
SELECT [ΚέyANo]
      ,[ϊ]
      ,[’_nl]
      ,[’_l]
      ,[’_ΐl]
      ,[’_Il]
      ,[θ_nl]
      ,[θ_l]
      ,[θ_ΐl]
      ,[θ_Il]
  FROM [RealA_FX_ACV_old].[dbo].T_RateHistory_Monthly
  where [ϊ] < (select MIN([StartDate]) from [RealA_FX_ACV].[hstr].tMonth1)

INSERT INTO [RealA_FX_ACV].[hstr].tHour1
           ([ΚέyANo]
           ,[StartDate]
           ,[’Rate_nl]
           ,[’Rate_l]
           ,[’Rate_ΐl]
           ,[’Rate_Il]
           ,[θRate_nl]
           ,[θRate_l]
           ,[θRate_ΐl]
           ,[θRate_Il])
SELECT [ΚέyANo]
      ,[ϊ]
      ,[’_nl]
      ,[’_l]
      ,[’_ΐl]
      ,[’_Il]
      ,[θ_nl]
      ,[θ_l]
      ,[θ_ΐl]
      ,[θ_Il]
  FROM [RealA_FX_ACV_old].[dbo].T_RateHistory_Hourly
  where [ϊ] < (select MIN([StartDate]) from [RealA_FX_ACV].[hstr].tHour1)

INSERT INTO [RealA_FX_ACV].[hstr].tDay1
           ([ΚέyANo]
           ,[StartDate]
           ,[’Rate_nl]
           ,[’Rate_l]
           ,[’Rate_ΐl]
           ,[’Rate_Il]
           ,[θRate_nl]
           ,[θRate_l]
           ,[θRate_ΐl]
           ,[θRate_Il])
SELECT [ΚέyANo]
      ,[ϊ]
      ,[’_nl]
      ,[’_l]
      ,[’_ΐl]
      ,[’_Il]
      ,[θ_nl]
      ,[θ_l]
      ,[θ_ΐl]
      ,[θ_Il]
  FROM [RealA_FX_ACV_old].[dbo].[T_RateHistory_Daily]
  where [ϊ] < (select MIN([StartDate]) from [RealA_FX_ACV].[hstr].tDay1)
order by [ϊ]




INSERT INTO [RealA_FX_ACV].[hstr].tHour6
           ([ΚέyANo]
           ,[StartDate]
           ,[’Rate_nl]
           ,[’Rate_l]
           ,[’Rate_ΐl]
           ,[’Rate_Il]
           ,[θRate_nl]
           ,[θRate_l]
           ,[θRate_ΐl]
           ,[θRate_Il])
SELECT [ΚέyANo]
      ,[ϊ]
      ,[’_nl]
      ,[’_l]
      ,[’_ΐl]
      ,[’_Il]
      ,[θ_nl]
      ,[θ_l]
      ,[θ_ΐl]
      ,[θ_Il]
  FROM [RealA_FX_ACV_old].[dbo].[T_RateHistory_6h]


INSERT INTO [RealA_FX_ACV].[hstr].[tMin30]
           ([ΚέyANo]
           ,[StartDate]
           ,[’Rate_nl]
           ,[’Rate_l]
           ,[’Rate_ΐl]
           ,[’Rate_Il]
           ,[θRate_nl]
           ,[θRate_l]
           ,[θRate_ΐl]
           ,[θRate_Il])
SELECT [ΚέyANo]
      ,[ϊ]
      ,[’_nl]
      ,[’_l]
      ,[’_ΐl]
      ,[’_Il]
      ,[θ_nl]
      ,[θ_l]
      ,[θ_ΐl]
      ,[θ_Il]
  FROM [RealA_FX_ACV_old].[dbo].[T_RateHistory_30m]
*/
