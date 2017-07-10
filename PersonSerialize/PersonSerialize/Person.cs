using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonSerialize
{
    [Serializable]
    class Person
    {
        public string Name { get; protected set; }

        public string Address { get; protected set; }

        public string PhoneNumber { get; protected set; }

        public int SerialNumber { get; protected set; }

        private static int CounterForSerialNumber;

        public Person()
        {

        }

        public Person(string name, string address, string phoneNumber)
        {
            Name = name;
            Address = address;
            PhoneNumber = phoneNumber;
            SerialNumber = CounterForSerialNumber++;
        }        

        public override string ToString()
        {
            return string.Format("This instance of my object has the following: Name = {0}, Address = {1}, Phone Number = {2}, Serial Number = {3}", Name, Address, PhoneNumber, SerialNumber);
        }
    }
}
