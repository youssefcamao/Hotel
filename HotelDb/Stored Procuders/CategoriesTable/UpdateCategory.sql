CREATE PROCEDURE [dbo].[UpdateCategory]
	@Id uniqueidentifier,
	@CategoryName nvarchar(20),
	@Description nvarchar(150),
	@RoomPriceForNight float
AS
	Begin
	Update dbo.CategoriesTable 
	Set CategoryName = @CategoryName,
	Description = @Description,
	RoomPriceForNight = @RoomPriceForNight
	Where Id = @Id;
	End
