USE OANDA_DemoB
GO

DROP PROCEDURE [oanda].[spGetBS�|�W�V����Cnt]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [oanda].[spGetBS�|�W�V����Cnt]
    @����No			Int,
	@�ʉ݃y�ANo		TinyInt,
	@id				bigint,
	@Cnt			int		output
AS
BEGIN

	SELECT @Cnt = COUNT(*)
	FROM [oanda].[tOrderResponse]
	where ����No = @����No AND [�ʉ݃y�ANo] = @�ʉ݃y�ANo AND [BS�J�n] = 1 AND [Order_id] >= @id;

END
GO

