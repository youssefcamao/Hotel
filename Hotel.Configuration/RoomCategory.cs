using Hotel.Configuration.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Configuration
{
    public class RoomCategory : IRoomCategory
    {
        public RoomCategory(string categoryName, string description, int maximunAllowedPeople, double roomPrice)
        {
            CategoryName = categoryName;
            Description = description;
            MaximunAllowedPeople = maximunAllowedPeople;
            RoomPriceForNight = roomPrice;
            CategoryId = Guid.NewGuid();
        }

        public string CategoryName { get; }


        public string Description { get; }

        public int MaximunAllowedPeople { get; }

        public double RoomPriceForNight { get; }

        public Guid CategoryId { get; }
    }
}
