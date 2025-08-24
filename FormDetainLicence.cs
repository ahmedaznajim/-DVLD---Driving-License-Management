using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DVLI.Licence;
using Presentation;

namespace DVLI
{
    public partial class FormDetainLicence : Form
    {
        public FormDetainLicence()
        {
            InitializeComponent();
        }

        private void buttonDetain_Click(object sender, EventArgs e)
        {
            DataTable dt2 = ClsUsers.SerchByUserName(ClassCurrentUser.userName);
            DataRow dr2 = dt2.Rows[0];
            DateTime dt = userControlLCImfo1.ExDate;
            if (userControlLCImfo1.IsActive == 0)
            {
                MessageBox.Show("cant Detain an inactive Licence");
                return;
            }
            if (ClsLicense.IsLicenceDetained(Convert.ToInt32(userControlLCImfo1.dt.Rows[0][0])) == "Yes")
            {
                MessageBox.Show("The License is already Detained");
                return;
            }

            if (ClsLicense.DetainLicenec(Convert.ToInt32(userControlLCImfo1.dt.Rows[0][0]), DateTime.Now, Convert.ToInt32(textBoxFine.Text), Convert.ToInt32(dr2[0])) == -1)
            {
                MessageBox.Show("Faild");
            }
            else
            {
                MessageBox.Show("Done");
               
                this.Hide();
                this.Close();
                FormViewDrivingLicenceInfromations form = new FormViewDrivingLicenceInfromations(userControlLCImfo1.dt);
                form.ShowDialog();

            }
        }

        private void userControlLCImfo1_Load(object sender, EventArgs e)
        {

        }
    }
}
