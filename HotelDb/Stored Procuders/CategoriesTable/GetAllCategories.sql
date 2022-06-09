CREATE PROCEDURE [dbo].[GetAllCategories]
AS
	SELECT Id, Description, CategoryName, RoomPriceForNight From dbo.CategoriesTable;
