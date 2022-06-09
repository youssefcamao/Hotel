CREATE TABLE [dbo].[RoomsTable]
(
    [RoomNumber] int NOT NULL PRIMARY KEY, 
    [IsRoomAvailable] BIT NOT NULL, 
    [CategoryId] UNIQUEIDENTIFIER NOT NULL, 
    CONSTRAINT [FK_RoomsTable_ToCategoriesTable] FOREIGN KEY (CategoryId) REFERENCES dbo.CategoriesTable(Id)
)
