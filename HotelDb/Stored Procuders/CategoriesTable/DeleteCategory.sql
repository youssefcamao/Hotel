CREATE PROCEDURE [dbo].[DeleteCategory]
	@Id uniqueidentifier
AS
	Begin
	Delete From dbo.CategoriesTable Where Id = @Id;	
	End
