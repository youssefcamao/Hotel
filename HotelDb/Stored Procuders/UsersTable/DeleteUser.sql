CREATE PROCEDURE [dbo].[DeleteUser]
	@UserId uniqueidentifier
AS
	Begin
	Delete From dbo.UsersTable Where Id = @UserId;
	End
