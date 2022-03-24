using Hotel.Configuration.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Configuration.RoomCategories
{
    public class SingleRoom : IRoomCategory
    {

        public string CategoryName { get; } = nameof(SingleRoom);


        public string Description { get; } = "a room for single people no lovers allowed";

        public int MaximunAllowedPeople { get; } = 1;

        public double RoomPrice { get; } = 45;
    }
}
