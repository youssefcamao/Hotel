using Hotel.Configuration.Interfaces.Models;

namespace Hotel.Configuration.Models.DapperModels
{
    internal class DapperRoom : IRoom
    {
        public Guid CategoryId { get; set; }

        public int RoomNumber { get; set; }
    }
}
