CREATE TABLE [dbo].[UsersTable]
(
	[Id] uniqueidentifier NOT NULL PRIMARY KEY, 
    [FirstName] NVARCHAR(30) NOT NULL, 
    [LastName] NVARCHAR(30) NOT NULL, 
    [Email] NVARCHAR(30) NOT NULL, 
    [UserPassword] BINARY(64) NOT NULL, 
    [IsUserAdmin] BIT NOT NULL
)
