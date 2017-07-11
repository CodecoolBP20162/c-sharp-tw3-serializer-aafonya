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
            if (fileinfo == null)
            {
                throw new NullReferenceException();
            }
            
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

        //public static Person SearchingNotDeletedFile(int index, string direction)
        //{
        //    Person deserializedPerson;
        //    bool getPersonData = false;
        //    if (direction.Equals("previous"))
        //    {
        //        while(getPersonData != false || index > 0)
        //        {
        //            try
        //            {
        //                deserializedPerson = ProcessingDeserialization(index);
        //                index--;
        //                getPersonData = true;
        //                return deserializedPerson;
        //            }

        //            catch (Exception e)
        //            {
        //                Console.WriteLine(" Exception caught.");
                        
        //            }
        //        }
        //    } else if (direction.Equals("previous"))
        //    {
        //        while (getPersonData != false || index < personList.Count)
        //        {
        //            try
        //            {
        //                deserializedPerson = ProcessingDeserialization(index);
        //                index++;
        //                getPersonData = true;
        //                return deserializedPerson;
        //            }

        //            catch (Exception e)
        //            {
        //                Console.WriteLine(" Exception caught.");
        //                                    }
        //        }
                
            
        //}
    }
}
