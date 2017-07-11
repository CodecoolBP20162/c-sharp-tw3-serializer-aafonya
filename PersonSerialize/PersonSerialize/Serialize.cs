using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace PersonSerialize
{
    class Serialize
    {
        public static string serialize(Person person)
        {

            // Create file to save the data 
            // Create and use a BinaryFormatter object to perform the serialization 
            // Close the file
            Random rnd = new Random(1000000);

            string serialNumberFormatted;

            if (person.SerialNumber <= 9)
            {
                serialNumberFormatted = String.Format("0{0}", person.SerialNumber);
            } else
            {
                serialNumberFormatted = person.SerialNumber.ToString();
            }

            string formattedFileName = "person" + serialNumberFormatted +  person.Name + rnd.Next() + ".dat";
            IFormatter formatter = new BinaryFormatter();
            Stream stream = new FileStream(formattedFileName, FileMode.Create, FileAccess.Write, FileShare.None);
            formatter.Serialize(stream, person);
            stream.Close();

            return formattedFileName;
        }

        public static Person Deserialize(FileInfo fileToDeserialize)
        {
            // Declare the object reference.
            Person deserializedObj;
            
            // Open the file containing the data that want to deserialize.
            FileStream fs = new FileStream(fileToDeserialize.FullName, FileMode.Open);
            try
            {
                BinaryFormatter formatter = new BinaryFormatter();

                // Deserialize the object from the file and 
                // assign the reference to the local variable.
                deserializedObj = (Person)formatter.Deserialize(fs);
                int serialnumber;
                string temp = fileToDeserialize.Name.Substring(6, 2);
                bool result = int.TryParse(temp, out serialnumber);
                //if(result == false)
                //{
                //    throw ParseFailedException();
                //}
                deserializedObj.SerialNumber = serialnumber;
            }
            catch (SerializationException e)
            {
                Console.WriteLine("Failed to deserialize. Reason: " + e.Message);
                throw;
            }
            finally
            {
                fs.Close();
            }
            return deserializedObj;
        }
    }
}
