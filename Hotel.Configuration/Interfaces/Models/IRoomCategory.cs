namespace Hotel.Configuration.Interfaces.Models
{
    public interface IRoomCategory
    {
        Guid Id { get; }
        string CategoryName { get; }
        string Description { get; }
        double RoomPriceForNight { get; }
    }
}
