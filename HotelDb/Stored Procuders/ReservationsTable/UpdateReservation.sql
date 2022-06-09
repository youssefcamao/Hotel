CREATE PROCEDURE [dbo].[UpdateReservation]
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
Update dbo.ReservationsTable Set FirstName = @FirstName, 
LastName = @LastName, 
Email = @Email,
StartDate = @StartDate,
EndDate = @EndDate,
ReservationCreationTime = @ReservationCreationTime,
TotalPriceForNights = @TotalPriceForNights,
ReservationStatus = @ReservationStatus,
RoomNumber = @RoomNumber,
CreationUserId = @CreationUserId
Where Id = @Id;
End
