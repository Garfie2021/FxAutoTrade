USE OANDA_DemoB
GO

DROP PROCEDURE [report].[spSelectDBìùåv]
GO
DROP PROCEDURE [system].[spSelectDBìùåv]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [system].[spSelectDBìùåv]
AS
BEGIN

	select schemaname, tblname, rowcnt
	from (
		select
			schema_name(SYSOBJ.schema_id) as schemaname, 
			SYSOBJ.name as tblname,
			SYSINDEXES.rows as rowcnt
		from sys.objects as SYSOBJ inner join sys.sysindexes as SYSINDEXES on
			SYSOBJ.object_id = SYSINDEXES.id and
			SYSINDEXES.indid < 2
		where SYSOBJ.type = 'U'
	) as t
	order by schemaname, tblname;

END
GO

