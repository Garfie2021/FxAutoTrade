USE OANDA_DemoB
GO


CREATE NONCLUSTERED INDEX [_dta_index_tSec_5_819534003__K2] ON [hstr].[tSec]
(
	[StartDate] ASC
)WITH (SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, DATA_COMPRESSION = PAGE) ON [PRIMARY]
GO

CREATE NONCLUSTERED INDEX [_dta_index_tDay1_5_3531096__K2] ON [hstr].[tDay1]
(
	[StartDate] ASC
)WITH (SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, DATA_COMPRESSION = PAGE) ON [PRIMARY]
GO

CREATE NONCLUSTERED INDEX [_dta_index_tHour1_5_947534459__K2_K1] ON [hstr].[tHour1]
(
	[StartDate] ASC,
	[�ʉ݃y�ANo] ASC
)WITH (SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, DATA_COMPRESSION = PAGE) ON [PRIMARY]
GO

CREATE NONCLUSTERED INDEX [_dta_index_tHour1_5_947534459__K2_1] ON [hstr].[tHour1]
(
	[StartDate] ASC
)
INCLUDE (
 	[�ʉ݃y�ANo]
) WITH (SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, DATA_COMPRESSION = PAGE) ON [PRIMARY]
GO

CREATE NONCLUSTERED INDEX [_dta_index_tHour1_5_947534459__K1_K2] ON [hstr].[tHour1]
(
	[�ʉ݃y�ANo] ASC,
	[StartDate] ASC
)WITH (SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, DATA_COMPRESSION = PAGE) ON [PRIMARY]
GO

CREATE NONCLUSTERED INDEX [_dta_index_tMin1_5_851534117__K1] ON [hstr].[tMin1]
(
	[�ʉ݃y�ANo] ASC
)WITH (SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, DATA_COMPRESSION = PAGE) ON [PRIMARY]
GO

CREATE NONCLUSTERED INDEX [_dta_index_tMin1_5_851534117__K2_K1_7_22] ON [hstr].[tMin1]
(
	[StartDate] ASC,
	[�ʉ݃y�ANo] ASC
)
INCLUDE (
 	[����Rate_�I�l],
	[����Rate_�I�l]
) WITH (SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, DATA_COMPRESSION = PAGE) ON [PRIMARY]
GO

CREATE NONCLUSTERED INDEX [_dta_index_tMin1_5_851534117__K2D_K1_7_22] ON [hstr].[tMin1]
(
	[StartDate] DESC,
	[�ʉ݃y�ANo] ASC
)
INCLUDE (
 	[����Rate_�I�l],
	[����Rate_�I�l]
) WITH (SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, DATA_COMPRESSION = PAGE) ON [PRIMARY]
GO

CREATE NONCLUSTERED INDEX [_dta_index_tMin1_5_851534117__K2_K1_3_4_18_19] ON [hstr].[tMin1]
(
	[StartDate] ASC,
	[�ʉ݃y�ANo] ASC
)
INCLUDE (
 	[����Swap],
	[����Rate_�n�l],
	[����Swap],
	[����Rate_�n�l]
) WITH (SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, DATA_COMPRESSION = PAGE) ON [PRIMARY]
GO

CREATE NONCLUSTERED INDEX [_dta_index_tMin15_5_915534345__K2] ON [hstr].[tMin15]
(
	[StartDate] ASC
)WITH (SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, DATA_COMPRESSION = PAGE) ON [PRIMARY]
GO

CREATE NONCLUSTERED INDEX [_dta_index_tMin15_5_915534345__K2_K1_7_22] ON [hstr].[tMin15]
(
	[StartDate] ASC,
	[�ʉ݃y�ANo] ASC
)
INCLUDE (
 	[����Rate_�I�l],
	[����Rate_�I�l]
) WITH (SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, DATA_COMPRESSION = PAGE) ON [PRIMARY]
GO

CREATE NONCLUSTERED INDEX [_dta_index_tMin15_5_915534345__K1_K2_3_4_18_19] ON [hstr].[tMin15]
(
	[�ʉ݃y�ANo] ASC,
	[StartDate] ASC
)
INCLUDE (
 	[����Swap],
	[����Rate_�n�l],
	[����Swap],
	[����Rate_�n�l]
) WITH (SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, DATA_COMPRESSION = PAGE) ON [PRIMARY]
GO

CREATE NONCLUSTERED INDEX [_dta_index_tMin5_5_883534231__K1] ON [hstr].[tMin5]
(
	[�ʉ݃y�ANo] ASC
)WITH (SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, DATA_COMPRESSION = PAGE) ON [PRIMARY]
GO

CREATE NONCLUSTERED INDEX [_dta_index_tMin5_5_883534231__K2D_K1_7_22] ON [hstr].[tMin5]
(
	[StartDate] DESC,
	[�ʉ݃y�ANo] ASC
)
INCLUDE (
 	[����Rate_�I�l],
	[����Rate_�I�l]
) WITH (SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, DATA_COMPRESSION = PAGE) ON [PRIMARY]
GO

CREATE NONCLUSTERED INDEX [_dta_index_tMin5_5_883534231__K2_1_3_4_18_19] ON [hstr].[tMin5]
(
	[StartDate] ASC
)
INCLUDE (
 	[�ʉ݃y�ANo],
	[����Swap],
	[����Rate_�n�l],
	[����Swap],
	[����Rate_�n�l]
) WITH (SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, DATA_COMPRESSION = PAGE) ON [PRIMARY]
GO

CREATE NONCLUSTERED INDEX [_dta_index_tMin5_5_883534231__K2_K1_5_6_20_21] ON [hstr].[tMin5]
(
	[StartDate] ASC,
	[�ʉ݃y�ANo] ASC
)
INCLUDE (
 	[����Rate_���l],
	[����Rate_���l],
	[����Rate_���l],
	[����Rate_���l]
) WITH (SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, DATA_COMPRESSION = PAGE) ON [PRIMARY]
GO

CREATE NONCLUSTERED INDEX [_dta_index_tMin5_5_883534231__K2_K1_3_4_18_19] ON [hstr].[tMin5]
(
	[StartDate] ASC,
	[�ʉ݃y�ANo] ASC
)
INCLUDE (
 	[����Swap],
	[����Rate_�n�l],
	[����Swap],
	[����Rate_�n�l]
) WITH (SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, DATA_COMPRESSION = PAGE) ON [PRIMARY]
GO

CREATE NONCLUSTERED INDEX [_dta_index_tMonth1_5_67531324__K2_K1] ON [hstr].[tMonth1]
(
	[StartDate] ASC,
	[�ʉ݃y�ANo] ASC
)WITH (SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, DATA_COMPRESSION = PAGE) ON [PRIMARY]
GO

CREATE NONCLUSTERED INDEX [_dta_index_tSec_5_819534003__K2_K1_4_6] ON [hstr].[tSec]
(
	[StartDate] ASC,
	[�ʉ݃y�ANo] ASC
)
INCLUDE (
 	[����Rate],
	[����Rate]
) WITH (SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, DATA_COMPRESSION = PAGE) ON [PRIMARY]
GO

CREATE NONCLUSTERED INDEX [_dta_index_tWeek1_5_35531210__K2_K1_7_22] ON [hstr].[tWeek1]
(
	[StartDate] ASC,
	[�ʉ݃y�ANo] ASC
)
INCLUDE (
 	[����Rate_�I�l],
	[����Rate_�I�l]
) WITH (SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, DATA_COMPRESSION = PAGE) ON [PRIMARY]
GO

CREATE NONCLUSTERED INDEX [_dta_index_tWeek1_5_35531210__K2_K1_5_6_20_21] ON [hstr].[tWeek1]
(
	[StartDate] ASC,
	[�ʉ݃y�ANo] ASC
)
INCLUDE (
 	[����Rate_���l],
	[����Rate_���l],
	[����Rate_���l],
	[����Rate_���l]
) WITH (SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, DATA_COMPRESSION = PAGE) ON [PRIMARY]
GO

CREATE NONCLUSTERED INDEX [_dta_index_tWeek1_5_35531210__K2_K1_3_4_18_19] ON [hstr].[tWeek1]
(
	[StartDate] ASC,
	[�ʉ݃y�ANo] ASC
)
INCLUDE (
 	[����Swap],
	[����Rate_�n�l],
	[����Swap],
	[����Rate_�n�l]
) WITH (SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, DATA_COMPRESSION = PAGE) ON [PRIMARY]
GO

CREATE NONCLUSTERED INDEX [_dta_index_tWeek1_5_35531210__K2_K1_3_4_5_6_18_19_20_21] ON [hstr].[tWeek1]
(
	[StartDate] ASC,
	[�ʉ݃y�ANo] ASC
)
INCLUDE (
 	[����Swap],
	[����Rate_�n�l],
	[����Rate_���l],
	[����Rate_���l],
	[����Swap],
	[����Rate_�n�l],
	[����Rate_���l],
	[����Rate_���l]
) WITH (SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, DATA_COMPRESSION = PAGE) ON [PRIMARY]
GO



CREATE NONCLUSTERED INDEX [_dta_index_tHour1_5_947534459__K2_K1_7_22] ON [hstr].[tHour1]
(
	[StartDate] ASC,
	[�ʉ݃y�ANo] ASC
)
INCLUDE (
 	[����Rate_�I�l],
	[����Rate_�I�l]
) WITH (SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, DATA_COMPRESSION = PAGE) ON [PRIMARY]
GO

CREATE NONCLUSTERED INDEX [_dta_index_tHour1_5_947534459__K2_K1_5_6_20_21] ON [hstr].[tHour1]
(
	[StartDate] ASC,
	[�ʉ݃y�ANo] ASC
)
INCLUDE (
 	[����Rate_���l],
	[����Rate_���l],
	[����Rate_���l],
	[����Rate_���l]
) WITH (SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, DATA_COMPRESSION = PAGE) ON [PRIMARY]
GO

CREATE NONCLUSTERED INDEX [_dta_index_tHour1_5_947534459__K2_K1_3_4_5_6_18_19_20_21] ON [hstr].[tHour1]
(
	[StartDate] ASC,
	[�ʉ݃y�ANo] ASC
)
INCLUDE (
 	[����Swap],
	[����Rate_�n�l],
	[����Rate_���l],
	[����Rate_���l],
	[����Swap],
	[����Rate_�n�l],
	[����Rate_���l],
	[����Rate_���l]
) WITH (SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, DATA_COMPRESSION = PAGE) ON [PRIMARY]
GO

CREATE NONCLUSTERED INDEX [_dta_index_tMin15_5_915534345__K2_K1_3_4_18_19] ON [hstr].[tMin15]
(
	[StartDate] ASC,
	[�ʉ݃y�ANo] ASC
)
INCLUDE (
 	[����Swap],
	[����Rate_�n�l],
	[����Swap],
	[����Rate_�n�l]
) WITH (SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, DATA_COMPRESSION = PAGE) ON [PRIMARY]
GO

CREATE NONCLUSTERED INDEX [_dta_index_tMin5_5_883534231__K2] ON [hstr].[tMin5]
(
	[StartDate] ASC
)WITH (SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, DATA_COMPRESSION = PAGE) ON [PRIMARY]

CREATE NONCLUSTERED INDEX [_dta_index_tSec_5_819534003__K2_K1_3_4_5_6] ON [hstr].[tSec]
(
	[StartDate] ASC,
	[�ʉ݃y�ANo] ASC
)
INCLUDE (
 	[����Swap],
	[����Rate],
	[����Swap],
	[����Rate]
) WITH (SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, DATA_COMPRESSION = PAGE) ON [PRIMARY]
GO




CREATE NONCLUSTERED INDEX [_dta_index_tHour1_5_947534459__K2_K1_3_4_18_19] ON [hstr].[tHour1]
(
	[StartDate] ASC,
	[�ʉ݃y�ANo] ASC
)
INCLUDE (
 	[����Swap],
	[����Rate_�n�l],
	[����Swap],
	[����Rate_�n�l]
) WITH (SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, DATA_COMPRESSION = PAGE) ON [PRIMARY]
GO

CREATE NONCLUSTERED INDEX [_dta_index_tMin15_5_915534345__K2_K1] ON [hstr].[tMin15]
(
	[StartDate] ASC,
	[�ʉ݃y�ANo] ASC
)WITH (SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, DATA_COMPRESSION = PAGE) ON [PRIMARY]
GO

