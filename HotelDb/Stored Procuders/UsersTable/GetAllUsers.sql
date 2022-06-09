CREATE PROCEDURE [dbo].[GetAllUsers]
AS
	select Id,FirstName,LastName,Email,IsUserAdmin from dbo.UsersTable;