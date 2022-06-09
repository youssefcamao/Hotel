CREATE PROCEDURE [dbo].[DeleteReservation]
@Id uniqueidentifier

As
Begin 
Delete From dbo.ReservationsTable Where Id = @Id;
End
