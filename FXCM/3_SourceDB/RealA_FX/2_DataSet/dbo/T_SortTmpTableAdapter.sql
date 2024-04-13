use FX_RealA

-- Fill
SELECT            T_SortTmp.*
FROM              T_SortTmp

-- DeleteAll
DELETE FROM [T_SortTmp] 


-- FillBy
SELECT            通貨ペア, 値
FROM              T_SortTmp
ORDER BY       値


-- FillByDESC
SELECT            通貨ペア, 値
FROM              T_SortTmp
ORDER BY       値 DESC


-- ScalarCnt
SELECT COUNT(*) FROM T_SortTmp