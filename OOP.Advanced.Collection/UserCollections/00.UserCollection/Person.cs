using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _00.UserCollection
{
    // Simple business object.
    public class Person
    {
        public Person(string fName, string lName)
        {
            this.firstName = fName;
            this.LastName = lName;
        }

        private string firstName;
        private string lastName;

        public string FirstName { get => firstName; set => firstName = value; }
        public string LastName { get => lastName; set => lastName = value; }
    }
}
