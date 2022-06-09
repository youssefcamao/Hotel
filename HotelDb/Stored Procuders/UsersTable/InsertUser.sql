CREATE PROCEDURE [dbo].[InsertUser]
	@Id uniqueidentifier,
	@FirstName nvarchar(30),
	@LastName nvarchar(30),
	@Email nvarchar(50),
	@Password nvarchar(50),
	@IsUserAdmin Bit,
	@ResponseMessage bit output
AS
Begin
SET NOCOUNT ON
BEGIN TRY 
Insert into dbo.UsersTable (Id, FirstName, LastName, Email, UserPassword, IsUserAdmin)
Values (@Id, @FirstName, @LastName, @Email, HASHBYTES('SHA2_512', @Password), @IsUserAdmin);

Set @ResponseMessage = 1;

End Try
Begin Catch
Set @ResponseMessage = 0;
End Catch

End
