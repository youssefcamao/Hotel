using Hotel.Configuration.Interfaces.Models;

namespace Hotel.Configuration.Models.DapperModels
{
    internal class DapperCategory : IRoomCategory
    {
        public Guid Id { get; set; }

        public string CategoryName { get; set; }

        public string Description { get; set; }

        public double RoomPriceForNight { get; set; }
    }
}
