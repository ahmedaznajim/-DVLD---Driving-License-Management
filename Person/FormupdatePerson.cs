using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Business;

namespace DVLI
{
    public partial class FormupdatePerson : Form
    {
        public FormupdatePerson(int ID,string NationalNo, string FirstName, string SecondName, string ThirdName, string LastName, DateTime DateOfBirth,
          int Gendor, string Address, string Phone, string Email,
             int NationalityCountryID, string ImagePath)
        {
            InitializeComponent();
            labelId.Text=Convert.ToString(ID);
            textBoxNational.Text = NationalNo;
            textBoxfname.Text = FirstName;
            textBoxSname.Text = SecondName;
            textBoxTName.Text = ThirdName;
            textBoxLanem.Text = LastName;
            textBoxPname.Text = Phone;
            textBoxEmail.Text = Email;
            textBoxCountry.Text = Convert.ToString(NationalityCountryID);



        }

        private void update_Load(object sender, EventArgs e)
        {

        }

        private void personInfo1_Load(object sender, EventArgs e)
        {

        }

        private void textBoxNational_TextChanged(object sender, EventArgs e)
        {



        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            if (Person.UpdatePerson2(Convert.ToInt32(labelId.Text), textBoxNational.Text, textBoxfname.Text, textBoxSname.Text,
                   textBoxTName.Text, textBoxLanem.Text, dateTimePicker2.Value,
           richTextBoxadrss.Text, textBoxPname.Text, textBoxEmail.Text,
             1, " "))
            {
                MessageBox.Show("Updated");
                textBoxNational.Clear();
                textBoxfname.Clear();
                textBoxSname.Clear();
                textBoxTName.Clear();
                textBoxLanem.Clear();
                dateTimePicker2.Value = DateTime.Now;
                richTextBoxadrss.Clear();
                textBoxPname.Clear();
                textBoxEmail.Clear();



            }
            else
            {
                MessageBox.Show("Faild");


            }
        }
    }
}
