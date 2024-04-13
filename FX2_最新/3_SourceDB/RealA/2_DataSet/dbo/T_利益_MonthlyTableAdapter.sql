USE [FX_DemoA]
GO

-- Fill
SELECT
	年月, 利益, 利益確定開始以降の利益, 出金可能Percent, 出金可能額, 出金済フラグ
FROM
	T_利益_Monthly


-- FillBy年月
SELECT
	年月, 利益, 利益確定開始以降の利益, 出金可能Percent, 出金可能額, 出金済フラグ
FROM
	T_利益_Monthly
WHERE
	年月 = @年月
