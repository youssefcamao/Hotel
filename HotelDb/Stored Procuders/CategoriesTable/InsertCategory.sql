CREATE PROCEDURE [dbo].[InsertCategory]
	@Id uniqueidentifier,
	@CategoryName nvarchar(20),
	@Description nvarchar(150),
	@RoomPriceForNight float
AS
	Begin 
	Insert Into dbo.CategoriesTable (Id, Description, CategoryName, RoomPriceForNight) 
	Values (@Id, @Description, @CategoryName, @RoomPriceForNight)

	End
