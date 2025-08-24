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
using DVLI.Properties;
using Presentation;

namespace DVLI
{
    public partial class FormNewLocalDrivingLicience : Form
    {
       
        DataTable dt = new DataTable();
        DataRow row1;
        DataTable dt1 = new DataTable();
        DataRow row2;
        DataTable dt3 = new DataTable();
        DataRow row3;
        public FormNewLocalDrivingLicience(string UserName)
        {
            InitializeComponent();
            tabControl2.SelectedIndex = 0;
            labeluserName.Text = UserName;
            labelFees.Text = 15.ToString();

            try
            {
                
                dt = ClsCountry.GetCountries();
                comboBox1.Enabled = false;

                foreach (DataRow row in dt.Rows)
                {
                    comboBox1.Items.Add(row[1].ToString());


                }
                dt3 = ClsLicense.getLicensesClasses();


                foreach (DataRow row3 in dt3.Rows)
                {
                    comboBox3.Items.Add(row3[1].ToString());


                }

                labelApplicationDate.Text = DateTime.Now.ToString();
              
            }
            catch { }

        }

        private void FormNewLocalDrivingLicience_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
           



        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
           
            
        }

        private void buttonNext_Click(object sender, EventArgs e)
        {
            tabControl2.SelectedIndex = 1;
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {



            DataRow row4 = dt3.Rows[comboBox3.SelectedIndex];
            DataTable dataTable = ClsUsers.SerchByUserName(labeluserName.Text);
            row3 = dataTable.Rows[0];
            if (ClsApplication.ISLocalApplicationExists(Convert.ToInt32(labelId.Text), Convert.ToInt32(row4[0]))==false)
            {
                int appID = ClsApplication.AddNewApplication(Convert.ToInt32(labelId.Text), DateTime.Now, 1, 1, DateTime.Now, 15, Convert.ToInt32(row3[0]));
                if (appID == -1)
                {
                    MessageBox.Show("Faild");


                }
                else
                {
                    if (ClsApplication.AddNewLocalApplication(appID, Convert.ToInt32(row4[0])) == -1)
                    {
                        MessageBox.Show("Faild");
                    }
                    else
                    {
                        MessageBox.Show("Done");
                        this.Hide();
                        FormLocalDrivingLicenceApplications form = new FormLocalDrivingLicenceApplications();
                        form.ShowDialog();
                    }

                }

            }
            else
            {
                MessageBox.Show("The application Is already existed");
            }


        }

        private void labelFees_Click(object sender, EventArgs e)
        {

        }

        private void label19_Click(object sender, EventArgs e)
        {

        }

        private void buttonSerch_Click(object sender, EventArgs e)
        {
            try
            {

                if (comboBox2.SelectedIndex == 0)
                {


                    dt1 = Person.SerchByID(Convert.ToInt32(textBox1.Text));
                    row2 = dt1.Rows[0];
                    labelId.Text = Convert.ToString(row2[0]);
                    labelNo.Text = Convert.ToString(row2[1]);
                    labelfname.Text = Convert.ToString(row2[2]);
                    labelsname.Text = Convert.ToString(row2[3]);
                    labeltname.Text = Convert.ToString(row2[4]);
                    labeltname.Text = Convert.ToString(row2[5]);
                    labelBirth.Text = Convert.ToString(row2[6]);
                    if (Convert.ToInt32(row2[7]) == 0)
                    {
                        labelGender.Text = "Male";
                    }
                    if (Convert.ToInt32(row2[7]) == 1)
                    {
                        labelGender.Text = "Female";
                    }
                    labelAdress.Text = Convert.ToString(row2[8]);

                    labelphone.Text = Convert.ToString(row2[9]);
                    labelEmail.Text = Convert.ToString(row2[10]);
                    comboBox1.SelectedIndex = Convert.ToInt32(row2[11]) - 1;
                    try
                    {
                        pictureBox1.Image = Image.FromFile(Convert.ToString(row2[12]));
                    }
                    catch { }


                }


                if (comboBox2.SelectedIndex == 1)
                {
                    try
                    {
                        string i = Convert.ToString(textBox1.Text);
                        dt1 = Person.SerchByNationalNo(i);
                        row2 = dt1.Rows[0];
                        labelId.Text = Convert.ToString(row2[0]);
                        labelNo.Text = Convert.ToString(row2[1]);
                        labelfname.Text = Convert.ToString(row2[2]);
                        labelsname.Text = Convert.ToString(row2[3]);
                        labeltname.Text = Convert.ToString(row2[4]);
                        labeltname.Text = Convert.ToString(row2[5]);
                        labelBirth.Text = Convert.ToString(row2[6]);
                        if (Convert.ToInt32(row2[7]) == 0)
                        {
                            labelGender.Text = "Male";
                        }
                        if (Convert.ToInt32(row2[7]) == 1)
                        {
                            labelGender.Text = "Female";
                        }
                        labelAdress.Text = Convert.ToString(row2[8]);

                        labelphone.Text = Convert.ToString(row2[9]);
                        labelEmail.Text = Convert.ToString(row2[10]);
                        comboBox1.SelectedIndex = Convert.ToInt32(row2[11]) - 1;
                        try
                        {
                            pictureBox1.Image = Image.FromFile(Convert.ToString(row2[12]));
                        }
                        catch { }



                    }
                    catch { }
                }



            }

            catch { }

            if (textBox1.Text == "")
            {


                labelId.Text =
                labelNo.Text =
                labelfname.Text = "";
                labelsname.Text = "";
                labeltname.Text = "";
                labeltname.Text = "";
                labelBirth.Text = "";

                labelGender.Text = "";





                labelAdress.Text = "";

                labelphone.Text = "";
                labelEmail.Text = "";
                comboBox1.SelectedIndex = 89;

                pictureBox1.Image = Resources.user;






            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
