CREATE PROCEDURE SpCheckDocument
		@Document CHAR(11)
AS 
	SELECT CASE WHEN EXISTS(
		SELECT [ID]
		FROM [Customer]
		where [Document] = @Document
	)
	THEN CAST(1 AS BIT)
	ELSE CAST(0 AS BIT) END 
