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
using Presentation;

namespace DVLI
{
    public partial class UserControlShowCarLicence : UserControl
    {
        public UserControlShowCarLicence()
        {
            InitializeComponent();
        }

        private void labelCarName_Click(object sender, EventArgs e)
        {

        }

        private void labelYear_Click(object sender, EventArgs e)
        {

        }

        private void labelDoors_Click(object sender, EventArgs e)
        {

        }

        private void labelFuleType_Click(object sender, EventArgs e)
        {

        }

        private void labelEngine_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void UserControlShowCarLicence_Load(object sender, EventArgs e)
        {

        }

        public void ShowInfo(int CarId)
        {
            DataTable dt = ClsCar.GetCarInfoByCarID(CarId);
            DataTable dt2 = Person.SerchByID(Convert.ToInt32(dt.Rows[0][1]));
            if (dt.Rows.Count > 0)
            {
                labelFname.Text = dt2.Rows[0][2].ToString() + " " + dt2.Rows[0][3].ToString() + " " + dt2.Rows[0][4].ToString() + " " + dt2.Rows[0][5].ToString();
                labelCarName.Text = dt.Rows[0][3].ToString();
                labelYear.Text = dt.Rows[0][13].ToString();
                labelDoors.Text = dt.Rows[0][6].ToString();
                labelFuleType.Text = dt.Rows[0][5].ToString();
                labelEngine.Text = dt.Rows[0][4].ToString();
                labelColor.Text = dt.Rows[0][8].ToString();
                labelVIN.Text = dt.Rows[0][7].ToString();
                
                labelSDate.Text = dt.Rows[0][9].ToString();
                labelEDate.Text = dt.Rows[0][10].ToString();

            }
            else
            {
                MessageBox.Show("No Data Found");




            }
        }
    }
}
