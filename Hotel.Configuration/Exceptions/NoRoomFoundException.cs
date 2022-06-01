using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Configuration.Exceptions
{
    public class NoRoomFoundException : Exception
    {
        public NoRoomFoundException() : base("No room was found under the given details!")
        {

        }
    }
}
