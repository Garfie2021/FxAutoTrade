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
      ,[����_�n�l]
      ,[����_���l]
      ,[����_���l]
      ,[����_�I�l]
      ,[����_�n�l]
      ,[����_���l]
      ,[����_���l]
      ,[����_�I�l]
FROM RealB_2370741683_FX_ACV.dbo.T_RateHistory_1m as a
where not exists 
(
	SELECT *
	FROM [RealB_2370741683_FX_ACV].[hstr].[tMin1] as b
	where (a.[�ʉ݃y�ANo] = b.[�ʉ݃y�ANo] and a.[����] = b.[StartDate])
)

/*
INSERT INTO [RealB_2370741683_FX_ACV].[hstr].[tMin5]
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
FROM RealB_2370741683_FX_ACV.dbo.T_RateHistory_5m as a
where not exists 
(
	SELECT *
	FROM [RealB_2370741683_FX_ACV].[hstr].[tMin5] as b
	where (a.[�ʉ݃y�ANo] = b.[�ʉ݃y�ANo] and a.[����] = b.[StartDate])
)

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
      ,[����_�n�l]
      ,[����_���l]
      ,[����_���l]
      ,[����_�I�l]
      ,[����_�n�l]
      ,[����_���l]
      ,[����_���l]
      ,[����_�I�l]
FROM RealB_2370741683_FX_ACV.dbo.T_RateHistory_15m as a
where not exists 
(
	SELECT *
	FROM [RealB_2370741683_FX_ACV].[hstr].[tMin15] as b
	where (a.[�ʉ݃y�ANo] = b.[�ʉ݃y�ANo] and a.[����] = b.[StartDate])
)

INSERT INTO [RealB_2370741683_FX_ACV].[hstr].[tSec]
           ([�ʉ݃y�ANo]
           ,[StartDate]
           ,[����Swap]
           ,[����Rate]
           ,[����Swap]
           ,[����Rate])
SELECT [�ʉ݃y�ANo]
      ,[����]
      ,[Swap_����]
      ,[Rate_����]
      ,[Swap_����]
      ,[Rate_����]
FROM RealB_2370741683_FX_ACV.dbo.T_RateHistory as a
where not exists 
(
	SELECT *
	FROM [RealB_2370741683_FX_ACV].[hstr].[tSec] as b
	where (a.[�ʉ݃y�ANo] = b.[�ʉ݃y�ANo] and a.[����] = b.[StartDate])
)

*/
