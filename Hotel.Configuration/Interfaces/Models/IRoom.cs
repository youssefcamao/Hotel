namespace Hotel.Configuration.Interfaces.Models
{
    public interface IRoom
    {
        Guid CategoryId { get; }
        int RoomNumber { get; }
    }
}
