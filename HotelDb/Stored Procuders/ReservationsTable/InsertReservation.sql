CREATE PROCEDURE [dbo].[InsertReservation]
	@Id uniqueidentifier,
	@FirstName nvarchar(20),
	@LastName nvarchar(20),
	@Email nvarchar(50),
	@StartDate Date ,
	@EndDate Date ,
	@ReservationCreationTime DateTime,
	@TotalPriceForNights float,
	@ReservationStatus NVARCHAR(30), 
    @RoomNumber INT, 
    @CreationUserId UNIQUEIDENTIFIER
AS
Begin
	Insert into dbo.ReservationsTable(Id, FirstName, LastName, Email, StartDate, EndDate, ReservationCreationTime, TotalPriceForNights, ReservationStatus, RoomNumber, CreationUserId)
	Values(@Id, @FirstName, @LastName, @Email, @StartDate, @EndDate, @ReservationCreationTime, @TotalPriceForNights, @ReservationStatus, @RoomNumber, @CreationUserId)
End
