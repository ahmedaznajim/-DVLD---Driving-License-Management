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
using DVLI.Properties;
using Presentation;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace DVLI
{
    public partial class UserControlUserInfo : UserControl
    {
        DataTable dt = new DataTable();
        DataRow row1;
    public    DataTable dt1 = new DataTable();
        DataRow row2;
        DataTable dt3 = new DataTable();
        DataRow row3;
        public int id= 0;
        public UserControlUserInfo()
        {
            InitializeComponent();
     

            try
            {

                dt = ClsCountry.GetCountries();
                comboBox1.Enabled = false;

                foreach (DataRow row in dt.Rows)
                {
                    comboBox1.Items.Add(row[1].ToString());


                }
                dt3 = ClsLicense.getLicensesClasses();



            }
            catch { }
        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        public void buttonSerch_Click(object sender, EventArgs e)
        {
            try
            {
                string i = Convert.ToString(textBox1.Text);
                dt1 = Person.SerchByNationalNo(i);
                row2 = dt1.Rows[0];
                labelId.Text = Convert.ToString(row2[0]);
                id = Convert.ToInt32(row2[0]);
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
                id = 0;





}



        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void UserControlUserInfo_Load(object sender, EventArgs e)
        {

        }
    }
}
