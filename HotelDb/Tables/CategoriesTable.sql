CREATE TABLE [dbo].[CategoriesTable]
(
	[Id] uniqueidentifier NOT NULL PRIMARY KEY, 
    [Description] NVARCHAR(150) NOT NULL, 
    [CategoryName] NVARCHAR(30) NOT NULL, 
    [RoomPriceForNight] FLOAT NOT NULL
)
