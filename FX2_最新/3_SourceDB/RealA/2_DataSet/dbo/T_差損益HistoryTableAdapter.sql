use FX_RealA


DECLARE @�ʉ݃y�A int
DECLARE @Date datetime
SET @Date = CONVERT(datetime, '2013/08/26 06:00:00')
SET @�ʉ݃y�A = 0

SELECT GrossPL_�|�W�V��������
FROM T_�����vHistory
where �ʉ݃y�A = @�ʉ݃y�A
--and Date < @Date
order by Date desc

--Fill
SELECT            T_�����vHistory.*
FROM              T_�����vHistory

--Scalar�����v����
SELECT (SELECT top 1 GrossPL_�|�W�V��������
FROM T_�����vHistory
where �ʉ݃y�A = @�ʉ݃y�A
order by Date desc)
-
(SELECT top 1 GrossPL_�|�W�V��������
FROM T_�����vHistory
where �ʉ݃y�A = @�ʉ݃y�A
and Date < @Date
order by Date desc)
