CREATE PROCEDURE [dbo].[UpdateUsers]
	@Id uniqueidentifier,
	@FirstName nvarchar(30),
	@LastName nvarchar(30),
	@Email nvarchar(30),
	@Password nvarchar(50),
	@IsUserAdmin Bit
    
AS

BEGIN

Update dbo.UsersTable 
Set FirstName = @FirstName,
Lastname = @LastName,
Email = @Email,
UserPassword = HASHBYTES('SHA2_512', @Password),
IsUserAdmin = @IsUserAdmin
Where Id = @Id

End
