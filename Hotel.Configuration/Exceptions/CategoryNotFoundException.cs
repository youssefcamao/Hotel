using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Configuration.Exceptions
{
    public class CategoryNotFoundException : Exception
    {
        public CategoryNotFoundException(string category) : base($"{category} was not found!")
        {

        }
    }
}
