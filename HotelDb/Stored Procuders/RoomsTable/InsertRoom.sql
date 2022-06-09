CREATE PROCEDURE [dbo].[InsertRoom]
	@RoomNumber int,
	@IsRoomAvailable bit,
	@CategoryId uniqueidentifier

AS
	Begin 
	Insert Into dbo.RoomsTable (RoomNumber, IsRoomAvailable, CategoryId)
	Values(@RoomNumber, @IsRoomAvailable, @CategoryId);
	End
