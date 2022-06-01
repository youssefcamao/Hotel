using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Core
{
    public static class NamingHelper
    {
        public static string FixNameFormat(string name)
        {
            if (name.Count() > 1)
            {
                name = char.ToUpper(name[0]) + name.Substring(1).ToLower();
            }

            return name;
        }
    }
}
