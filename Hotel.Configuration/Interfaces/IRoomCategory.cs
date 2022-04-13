using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Configuration.Interfaces
{
    public interface IRoomCategory
    {
        Guid CategoryId { get; }
        string CategoryName { get; }
        string Description { get; }
        int MaximunAllowedPeople { get; }
        double RoomPrice { get; }
    }
}
