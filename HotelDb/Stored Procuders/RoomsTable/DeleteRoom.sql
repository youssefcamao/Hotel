CREATE PROCEDURE [dbo].[DeleteRoom]
	@RoomNumber int

AS
	Begin
	Delete From dbo.RoomsTable Where RoomNumber = @RoomNumber; 
	End
