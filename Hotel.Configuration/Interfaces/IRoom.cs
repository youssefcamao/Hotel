using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Configuration.Interfaces
{
    public interface IRoom
    {
        IRoomCategory Category { get; }
        int RoomNumber { get; }
    }
}
