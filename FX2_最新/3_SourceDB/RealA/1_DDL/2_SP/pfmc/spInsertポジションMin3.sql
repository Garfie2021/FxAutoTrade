USE OANDA_DemoB
GO

DROP PROCEDURE [pfmc].[spInsertポジションMin3]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [pfmc].[spInsertポジションMin3]
	@口座No		int,
	@Order数	int,
	@Trade数	int,
	@当日注文数	int
AS
BEGIN

	SET NOCOUNT ON;

	INSERT INTO [pfmc].[tポジションMin3] (
		[口座No],
		[StartDate],
		[Order数],
		[Trade数],
		[当日注文数]
	) VALUES (
		@口座No,
		GETDATE(),
		@Order数,
		@Trade数,
		@当日注文数
	);

END
GO
