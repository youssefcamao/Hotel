CREATE PROCEDURE [dbo].[InsertUser]
	@Id uniqueidentifier,
	@FirstName nvarchar(30),
	@LastName nvarchar(30),
	@Email nvarchar(50),
	@Password nvarchar(50),
	@IsUserAdmin Bit
AS
Begin
SET NOCOUNT ON
Insert into dbo.UsersTable (Id, FirstName, LastName, Email, UserPassword, IsUserAdmin)
Values (@Id, @FirstName, @LastName, @Email, HASHBYTES('SHA2_512', @Password), @IsUserAdmin);
End
