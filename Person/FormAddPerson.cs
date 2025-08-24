using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Business;
using System.Windows.Forms.VisualStyles;
using DVLI.Properties;
using Presentation;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace DVLI
{

    public partial class FormAddPerson : Form
    {
        DataTable dt = new DataTable();
        DataRow row1;
        string imagePath;
        public FormAddPerson()
        {
            
            InitializeComponent();
            dt = ClsCountry.GetCountries();
            foreach (DataRow row in dt.Rows)
            {
                comboBox1.Items.Add(row[1].ToString());


            }
            comboBox1.SelectedIndex = 89;
        }

        private void personInfo1_Load(object sender, EventArgs e)
        {
        }

        private void personInfo1_Load_1(object sender, EventArgs e)
        {

        }

        private void radioButtonM_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonF.Checked)
            {
                pictureBox1.Image = Resources.girl;

            }
            else
            {
                if (radioButtonM.Checked)
                {
                    pictureBox1.Image = Resources.boy;

                }

            }
        }

        private void radioButtonF_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonF.Checked)
            {
                pictureBox1.Image = Resources.girl;

            }
            else
            {
                if (radioButtonM.Checked)
                {
                    pictureBox1.Image = Resources.boy;

                }

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (Person.SerchByNationalNumber(textBoxNational.Text))
            {
                MessageBox.Show("The National Number is already Exits");
                textBoxNational.Clear();

            }
            else
            {

                if (radioButtonF.Checked)
                {
                    if (Person.AddPerson(textBoxNational.Text, textBoxfname.Text, textBoxSname.Text,
                       textBoxTName.Text, textBoxLanem.Text, dateTimePicker2.Value,
              1, richTextBoxadrss.Text, textBoxPname.Text, textBoxEmail.Text,
                Convert.ToInt32(row1[0]), imagePath) == -1)
                    {
                        MessageBox.Show("Error");

                    }
                    else
                    {
                        MessageBox.Show("Saved Correctly");
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
                }
               
                    if (radioButtonM.Checked)
                    {
                        if (Person.AddPerson(textBoxNational.Text, textBoxfname.Text, textBoxSname.Text,
                           textBoxTName.Text, textBoxLanem.Text, dateTimePicker2.Value,
                  0, richTextBoxadrss.Text, textBoxPname.Text, textBoxEmail.Text,
                    Convert.ToInt32(row1[0]), imagePath) == -1)
                        {
                            MessageBox.Show("Error");

                        }
                        else
                        {
                            MessageBox.Show("Saved Correctly");
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


                    }

            }
        }

        private void Formsave_Load(object sender, EventArgs e)
        {

            
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    imagePath = openFileDialog.FileName;
                    pictureBox1.Image = Image.FromFile(openFileDialog.FileName);
                }
            }
            catch { }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            row1 = dt.Rows[comboBox1.SelectedIndex];
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBoxNational_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void textBoxPname_TextChanged(object sender, EventArgs e)
        {
            if (Person.SerchByNationalNumber(textBoxNational.Text))
            {
                ErrorProvider errorProvider1=new ErrorProvider();
                errorProvider1.SetError(textBoxNational, "This field cannot be empty!");
                


            }
        }
    }
}
