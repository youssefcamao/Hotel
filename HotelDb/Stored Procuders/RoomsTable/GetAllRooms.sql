CREATE PROCEDURE [dbo].[GetAllRooms]
AS
	SELECT RoomNumber, IsRoomAvailable, CategoryId From dbo.RoomsTable;
RETURN 0
