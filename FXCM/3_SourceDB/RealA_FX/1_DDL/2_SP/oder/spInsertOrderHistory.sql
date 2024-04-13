USE RealA_FX
GO

DROP PROCEDURE [oder].[spInsertOrderHistory]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [oder].[spInsertOrderHistory]
	@通貨ペアNo	tinyint,
	@日時		datetime,
	@売買判定	bit,
	@買いSwap	float,
	@売りSwap	float,
	@買いRate	float,
	@売りRate	float,
	@リミット	float,
	@注文単位	int,
	@BB開始		bit
AS
BEGIN

	SET NOCOUNT ON;

	INSERT INTO [oder].[tOrderHistory] (
		[通貨ペアNo],
		[日時],
		[売買判定],
		[買いSwap],
		[売りSwap],
		[買いRate],
		[売りRate],
		[リミット],
		[注文単位],
		[BB開始]
	) VALUES (
		@通貨ペアNo,
		@日時,
		@売買判定,
		@買いSwap,
		@売りSwap,
		@買いRate,
		@売りRate,
		@リミット,
		@注文単位,
		@BB開始
	);

END
GO
