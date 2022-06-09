using Hotel.Configuration.Interfaces.Models;

namespace Hotel.Configuration.Models
{
    public class RoomCategory : IRoomCategory
    {
        public RoomCategory(string categoryName, string description, double roomPrice)
        {
            CategoryName = categoryName;
            Description = description;
            RoomPriceForNight = roomPrice;
            Id = Guid.NewGuid();
        }
        public Guid Id { get; }

        public string CategoryName { get; }


        public string Description { get; }

        public double RoomPriceForNight { get; }

    }
}
