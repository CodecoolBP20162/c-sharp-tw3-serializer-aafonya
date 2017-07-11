using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Specialized;
using System.Collections;
using System.IO;
using System.Text.RegularExpressions;

namespace PersonSerialize
{
    class PersonDataManager
    {
        public static OrderedDictionary personList = new OrderedDictionary();
        
        public static void ProcessingSavedData(string name, string address, string phoneNumber)
        {
            int serialnumber = personList.Count;
            Person newPerson = new Person(name, address, phoneNumber, serialnumber);
            string outputFileName = Serialize.serialize(newPerson);
            personList.Add(newPerson, outputFileName);
        }

        public static Person ProcessingDeserialization(int index)
        {    
            string actualItem = personList[index].ToString();

            FileInfo fileinfo = new FileInfo(actualItem);
            Person deserializedObject = Serialize.Deserialize(fileinfo);
            
            return deserializedObject;
        }

        public static void FullFillPersonlistByLoadForm()
        {
            string path = @"C:\Users\Judit\Source\Repos\c-sharp-tw3-serializer-aafonya\PersonSerialize\PersonSerialize\bin\Debug";
            DirectoryInfo directory = new DirectoryInfo(path);
            FileInfo[] fileinfos = directory.GetFiles();

            foreach (FileInfo file in fileinfos)
            {
                if(file.Name.Substring(0,6).Equals("person"))
                {
                    Person deserializedObject = Serialize.Deserialize(file);
                    personList.Add(deserializedObject, file.FullName);
                }               
            }
        }
    }
}
