use FX_RealA


DECLARE @通貨ペア int
DECLARE @Date datetime
SET @Date = CONVERT(datetime, '2013/08/26 06:00:00')
SET @通貨ペア = 0

SELECT GrossPL_ポジション数割
FROM T_差損益History
where 通貨ペア = @通貨ペア
--and Date < @Date
order by Date desc

--Fill
SELECT            T_差損益History.*
FROM              T_差損益History

--Scalar差損益差分
SELECT (SELECT top 1 GrossPL_ポジション数割
FROM T_差損益History
where 通貨ペア = @通貨ペア
order by Date desc)
-
(SELECT top 1 GrossPL_ポジション数割
FROM T_差損益History
where 通貨ペア = @通貨ペア
and Date < @Date
order by Date desc)
