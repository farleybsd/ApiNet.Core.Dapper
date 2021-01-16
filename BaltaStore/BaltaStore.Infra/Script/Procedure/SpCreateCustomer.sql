CREATE PROCEDURE SpCreateCustomer
@Id        UNIQUEIDENTIFIER ,
@FirstName VARCHAR(40),
@LastNAME  VARCHAR(40),
@Document  CHAR(11),
@Email     VARCHAR(160),
@Phone     VARCHAR(13)

AS
	INSERT INTO [Customer] 
	(
	[Id],
	[FirstName],
	[LastNAME],	
	[Document],
	[Email],
	[Phone]
	) VALUES (
	@Id,
	@FirstName,
	@LastNAME,
	@Document,
	@Email,
	@Phone
	
	)