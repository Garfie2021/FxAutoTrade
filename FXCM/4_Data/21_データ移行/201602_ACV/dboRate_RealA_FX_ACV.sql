INSERT INTO [RealA_FX_ACV].[hstr].[tMin1]
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
FROM RealA_FX_ACV.dbo.T_RateHistory_1m as a
where not exists 
(
	SELECT *
	FROM [RealA_FX_ACV].[hstr].[tMin1] as b
	where (a.[通貨ペアNo] = b.[通貨ペアNo] and a.[日時] = b.[StartDate])
)

/*
INSERT INTO [RealA_FX_ACV].[hstr].[tMin5]
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
FROM RealA_FX_ACV.dbo.T_RateHistory_5m as a
where not exists 
(
	SELECT *
	FROM [RealA_FX_ACV].[hstr].[tMin5] as b
	where (a.[通貨ペアNo] = b.[通貨ペアNo] and a.[日時] = b.[StartDate])
)

INSERT INTO [RealA_FX_ACV].[hstr].[tMin15]
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
FROM RealA_FX_ACV.dbo.T_RateHistory_15m as a
where not exists 
(
	SELECT *
	FROM [RealA_FX_ACV].[hstr].[tMin15] as b
	where (a.[通貨ペアNo] = b.[通貨ペアNo] and a.[日時] = b.[StartDate])
)



INSERT INTO [RealA_FX_ACV].[hstr].[tSec]
           ([通貨ペアNo]
           ,[StartDate]
           ,[買いSwap]
           ,[買いRate]
           ,[売りSwap]
           ,[売りRate])
SELECT [通貨ペアNo]
      ,[日時]
      ,[Swap_買い]
      ,[Rate_買い]
      ,[Swap_売り]
      ,[Rate_売り]
FROM RealA_FX_ACV.dbo.T_RateHistory as a
where not exists 
(
	SELECT *
	FROM [RealA_FX_ACV].[hstr].[tSec] as b
	where (a.[通貨ペアNo] = b.[通貨ペアNo] and a.[日時] = b.[StartDate])
)

*/
