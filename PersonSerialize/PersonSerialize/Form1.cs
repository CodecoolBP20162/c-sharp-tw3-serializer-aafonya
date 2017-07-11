using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace PersonSerialize
{
    public partial class Form1 : Form
    {
        public static int IndexOfShowedPerson;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            PersonDataManager.FullFillPersonlistByLoadForm();

            if (PersonDataManager.personList.Count > 0)
            {
                IndexOfShowedPerson = 0;
                int index = 0;
                Person deserializedPerson = PersonDataManager.ProcessingDeserialization(0);
                WriteLabelTexts(deserializedPerson, index);
            } else
            {
                MessageBox.Show("You haven't serialzed any data yet.");
            }           
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            string inputName = NametextBox.Text;
            string inputAddress = AddresstextBox.Text;
            string inputPhoneNumber = PhoneNumbertextBox.Text;
            PersonDataManager.ProcessingSavedData(inputName, inputAddress, inputPhoneNumber);

            MessageBox.Show("Data Saved");

            NametextBox.Clear();
            AddresstextBox.Clear();
            PhoneNumbertextBox.Clear();

            int index = PersonDataManager.personList.Count - 1;
            Person deserializedPerson = PersonDataManager.ProcessingDeserialization(index);
            WriteLabelTexts(deserializedPerson, index);
            IndexOfShowedPerson = index;

        }

        private void PreviousbButton_Click(object sender, EventArgs e)
        {
            int index = IndexOfShowedPerson - 1;
            if(index < 0)
            {
                MessageBox.Show("This is the first person");
            } else
            {
                try
                {
                    Person deserializedPersontried = PersonDataManager.ProcessingDeserialization(index);
                    
                }

                catch (Exception ex)
                {
                    Form1 form1 = new Form1();
                    MessageBox.Show("It looks like you've lost some data");
                    //PersonDataManager.searchingNotDeletedFile(index);??
                }


                IndexOfShowedPerson++;
                Person deserializedPerson = PersonDataManager.ProcessingDeserialization(index);
                WriteLabelTexts(deserializedPerson, index);
            }
           
        }

        private void NextButton_Click(object sender, EventArgs e)
        {
            int index = IndexOfShowedPerson + 1;
            if (index > PersonDataManager.personList.Count - 1)
            {
                MessageBox.Show("This is the last person");
            }
            else
            {
                IndexOfShowedPerson++;
                Person deserializedPerson = PersonDataManager.ProcessingDeserialization(index);
                WriteLabelTexts(deserializedPerson, index);
            }

        }

        private void WriteLabelTexts(Person deserializedPerson, int index)
        {
            NametextBox.Text = deserializedPerson.Name;
            AddresstextBox.Text = deserializedPerson.Address;
            PhoneNumbertextBox.Text = deserializedPerson.PhoneNumber;

            SerialNumberLabel.Text = deserializedPerson.SerialNumber.ToString();
            CounterLabel.Text = String.Format("You can see the {0}. persons data.", index + 1);
            SumLabel.Text = String.Format("You already have serialize {0} persons data.", PersonDataManager.personList.Count);
        }

        
    }
}
