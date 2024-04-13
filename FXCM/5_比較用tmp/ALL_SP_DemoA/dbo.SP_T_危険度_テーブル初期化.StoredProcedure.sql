USE [RealA_FX]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[SP_T_危険度_テーブル初期化]
AS
BEGIN

	declare cursor通貨ペアMst cursor for
	SELECT [No]
	FROM [dbo].[T_通貨ペアMst]
  	;

	open cursor通貨ペアMst;

	declare @通貨ペアNo tinyint = 0;
	FETCH NEXT FROM cursor通貨ペアMst INTO @通貨ペアNo;

	WHILE @@FETCH_STATUS = 0
	BEGIN

		INSERT INTO [dbo].[T_危険度] ([通貨ペアNo]) VALUES (@通貨ペアNo);

		FETCH NEXT FROM cursor通貨ペアMst INTO @通貨ペアNo;
	END

	CLOSE cursor通貨ペアMst;
	DEALLOCATE cursor通貨ペアMst;


END


GO
