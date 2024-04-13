USE OANDA_DemoB
GO

DROP PROCEDURE [oanda].[spGetTransactionCnt]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [oanda].[spGetTransactionCnt]
    @口座No		Int,
    @id			bigint,
    @accountId	int,
    @time		DateTime,
    @cnt		int			OUTPUT
AS
BEGIN

	SET NOCOUNT ON;

	SELECT @cnt = COUNT([id]) 
	FROM [oanda].[tTransaction] 
	WHERE 口座No = @口座No AND [id] = @id AND [accountId] = @accountId AND [time] = @time;
	
END
GO
