CREATE PROCEDURE SpCreateAddress
@Id UNIQUEIDENTIFIER,
@CustomerId UNIQUEIDENTIFIER ,
@Number VARCHAR(10) ,
@Complement VARCHAR(40) ,
@District VARCHAR(60) ,
@City VARCHAR(60) ,
@STATE VARCHAR(2) ,
@Country VARCHAR(2) ,
@ZipCode CHAR(8) ,
@Type INT

AS
	INSERT INTO [Address] (
	    [Id],
	    [CustomerId] ,
		[Number] ,
		[Complement] ,
		[District] ,
		[City] ,
		[STATE] ,
		[Country] ,
		[ZipCode] ,
		[Type] 
	
	
	) VALUES(
		@Id ,
		@CustomerId,
		@Number,
		@Complement,
		@District,
		@City,
		@STATE,
		@Country,
		@ZipCode,
		@Type
	)