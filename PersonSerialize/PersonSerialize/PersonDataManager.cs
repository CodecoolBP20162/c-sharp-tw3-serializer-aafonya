using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Specialized;
using System.Collections;

namespace PersonSerialize
{
    class PersonDataManager
    {
        public static OrderedDictionary personList = new OrderedDictionary();
        public static OrderedDictionary deserializedPersonList = new OrderedDictionary();

        public static void ProcessingSavedData(string name, string address, string phoneNumber)
        {
            Person newPerson = new Person(name, address, phoneNumber);
            string outputFileName = Serialize.serialize(newPerson);
            personList.Add(newPerson, outputFileName);
        }

        public static Person ProcessingDeserialization(int index)
        {    
            string actualItem = personList[index].ToString();
            Person deserializedObject = Serialize.Deserialize(actualItem);
            //deserializedPersonList.Add(deserializedObject, null);
            return deserializedObject;
        }
    }
}
