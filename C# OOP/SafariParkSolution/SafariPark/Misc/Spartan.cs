using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SafariPark
{
    class Spartan
    {
        public string FirstName { get; init; }
        public string LastName { get; init; }
        public int Age { get; init; }

        public Spartan(string fName, string lName, int age)
        {
            FirstName = fName;
            LastName = lName;
            Age = age;
        }
    }
}
