CREATE PROCEDURE SpGetCustomerOrderCount

@Document CHAR(11)	
AS
SELECT
		C.[Id],
		CONCAT(C.[FirstName],' ',C.[LastNAME]) as Name,
		C.[Document],
		COUNT(O.ID)
	FROM
	[Customer] C
	INNER JOIN [Order] O ON O.[CustomerId] = C.[Id]
	where [Document] = @Document
	GROUP BY 
	C.[Id],
	CONCAT(C.[FirstName],' ',C.[LastNAME]) ,
	C.[Document],
	O.Id