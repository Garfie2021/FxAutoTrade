use FX_DemoA


-- Fill
SELECT            T_SortCloseTradeTmp.*
FROM              T_SortCloseTradeTmp


-- DeleteAll
DELETE FROM [T_SortCloseTradeTmp]

-- FillBy���v
SELECT            TOP (1) *
FROM              T_SortCloseTradeTmp
ORDER BY       ���v

-- FillByTime
SELECT             *
FROM              T_SortCloseTradeTmp
ORDER BY       [Time]

