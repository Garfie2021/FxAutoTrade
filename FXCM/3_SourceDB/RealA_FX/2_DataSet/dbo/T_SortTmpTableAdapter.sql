use FX_RealA

-- Fill
SELECT            T_SortTmp.*
FROM              T_SortTmp

-- DeleteAll
DELETE FROM [T_SortTmp] 


-- FillBy
SELECT            �ʉ݃y�A, �l
FROM              T_SortTmp
ORDER BY       �l


-- FillByDESC
SELECT            �ʉ݃y�A, �l
FROM              T_SortTmp
ORDER BY       �l DESC


-- ScalarCnt
SELECT COUNT(*) FROM T_SortTmp