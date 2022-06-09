CREATE PROCEDURE [dbo].[GetAllReservations]
AS
	SELECT Id, FirstName, LastName, Email, StartDate, EndDate, ReservationCreationTime, TotalPriceForNights, ReservationStatus, RoomNumber, CreationUserId From dbo.ReservationsTable;
