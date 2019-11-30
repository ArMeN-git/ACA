using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company
{
    interface IPerson
    {
        string FirstName { get; }
        string LastName { get; }
        int ID { get; }
    }
    class Person : IPerson
    {
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public int ID { get; private set; }

        public Person(int id, string firstname, string lastname)
        {
            this.ID = id;
            this.FirstName = firstname;
            this.LastName = lastname;
        }

        public override string ToString()
        {
            return $"ID: {ID}, Name: {FirstName} {LastName}";
        }
    }
}
