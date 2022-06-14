CREATE PROCEDURE [dbo].[LoginAuth]
	@Email varchar(30),
	@Password varchar(50)
AS
       SELECT Id,FirstName,LastName,Email,IsUserAdmin  FROM [dbo].[UsersTable] WHERE Lower(Email) = Lower(@Email) And UserPassword=HASHBYTES('SHA2_512', @Password)
       