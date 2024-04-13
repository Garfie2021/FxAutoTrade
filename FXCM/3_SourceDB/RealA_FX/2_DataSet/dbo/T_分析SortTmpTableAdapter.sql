use FX_RealA

-- Fill
SELECT            T_分析SortTmp.*
FROM              T_分析SortTmp

-- DeleteAll
DELETE FROM [T_分析SortTmp] 


-- FillBy
SELECT            キー, 値
FROM              T_分析SortTmp
ORDER BY       値


-- FillByDESC
SELECT            キー, 値
FROM              T_分析SortTmp
ORDER BY       キー DESC


-- ScalarCnt
SELECT COUNT(*) FROM T_分析SortTmp
