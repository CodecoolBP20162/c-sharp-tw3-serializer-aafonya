using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;
using System.IO;

namespace PersonSerialize 
{
    [Serializable]
    class Person 
    {
        public string Name { get; protected set; }

        public string Address { get; protected set; }

        public string PhoneNumber { get; protected set; }

        [NonSerialized] public int SerialNumber;


        public Person()
        {

        }

        public Person(string name, string address, string phoneNumber, int serialnumber)
        {
            Name = name;
            Address = address;
            PhoneNumber = phoneNumber;
            SerialNumber = serialnumber;
        }        

        public override string ToString()
        {
            return string.Format("This instance of my object has the following: Name = {0}, Address = {1}, Phone Number = {2}, Serial Number = {3}", Name, Address, PhoneNumber, SerialNumber);
        }

        
    }
}
