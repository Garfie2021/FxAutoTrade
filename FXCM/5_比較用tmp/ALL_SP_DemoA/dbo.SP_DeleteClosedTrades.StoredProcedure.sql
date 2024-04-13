USE [RealA_FX]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[SP_DeleteClosedTrades]
AS
BEGIN

	SET NOCOUNT ON;

	DECLARE @StartDate datetime = DATEADD(month, -3, getdate());
	
	delete
	FROM [dbo].T_ClosedTrades
	where [CloseTime] < @StartDate

END


GO
