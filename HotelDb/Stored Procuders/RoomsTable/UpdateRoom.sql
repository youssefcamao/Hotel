CREATE PROCEDURE [dbo].[UpdateRoom]
	@OldRoomNumber int,
	@RoomNumber int,
	@IsRoomAvailable bit,
	@CategoryId uniqueidentifier,
	@IsOperationSuccessful bit output

AS
	Begin
	If Exists (select * From dbo.RoomsTable Where RoomNumber = @RoomNumber)
	set @IsOperationSuccessful = 0;

	Else
	Update dbo.RoomsTable 
	Set CategoryId = @CategoryId, IsRoomAvailable = @IsRoomAvailable, RoomNumber = @RoomNumber Where RoomNumber = @OldRoomNumber;
	set @IsOperationSuccessful = 1;
	End
