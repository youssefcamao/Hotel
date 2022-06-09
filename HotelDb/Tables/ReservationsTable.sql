CREATE TABLE [dbo].[ReservationsTable]
(
	[Id] uniqueidentifier NOT NULL PRIMARY KEY, 
    [FirstName] NVARCHAR(20) NOT NULL, 
    [LastName] NVARCHAR(20) NOT NULL, 
    [Email] NVARCHAR(50) NOT NULL, 
    [StartDate] DATE NOT NULL, 
    [EndDate] DATE NOT NULL, 
    [ReservationCreationTime] Datetime NOT NULL, 
    [TotalPriceForNights] FLOAT NOT NULL, 
    [ReservationStatus] NVARCHAR(30) NOT NULL, 
    [RoomNumber] INT NOT NULL, 
    [CreationUserId] UNIQUEIDENTIFIER NOT NULL, 
    CONSTRAINT [FK_ReservationsTable_ToRoomsTable] FOREIGN KEY (RoomNumber) REFERENCES dbo.RoomsTable([RoomNumber]), 
    CONSTRAINT [FK_ReservationsTable_ToUsersTable] FOREIGN KEY (CreationUserId) REFERENCES dbo.UsersTable(Id)
)
