using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Presentation;

namespace DVLI.Licence
{
    public partial class UserControlLCImfo : UserControl
    {
        public DateTime ExDate;
        public DataTable dt;
        public string Isdetained;
        public int IsActive;
        public UserControlLCImfo()
        {
            InitializeComponent();
        }

        public void UserControlLCImfo_Load(object sender, EventArgs e)
        {

        }
        public string ExpirationDateText
        {
            get => lblExpirationDate.Text;
            set => lblExpirationDate.Text = value;
        }
        public void buttonSerch_Click(object sender, EventArgs e)
        {
            if(textBox1.Text == "")
            {
                MessageBox.Show("Please Enter a License ID");
                return;
            }
            try
            {
                dt = ClsLicense.ShowLicenceInfo(Convert.ToInt32(textBox1.Text));
                DataRow dr;
                dr = dt.Rows[0];
                lblClass.Text = Convert.ToString(dr[1]);
                lblFullName.Text = Convert.ToString(dr[2]) + " " + Convert.ToString(dr[3]);
                lblLicenseID.Text = Convert.ToString(dr[4]);
                lblNationalNo.Text = Convert.ToString(dr[5]);
                lblGendor.Text = Convert.ToString(dr[6]);
                lblIssueDate.Text = Convert.ToString(dr[7]);
                lblIssueReason.Text = Convert.ToString(dr[8]);
                lblNotes.Text = Convert.ToString(dr[9]);
                lblIsActive.Text = Convert.ToString(dr[10]);
                IsActive = Convert.ToInt32(dr[10]);
                lblDateOfBirth.Text = Convert.ToString(dr[11]);
                lblDriverID.Text = Convert.ToString(dr[12]);
                lblExpirationDate.Text = Convert.ToString(dr[13]);
                ExDate = Convert.ToDateTime(dr[13]);
                lblIsDetained.Text = ClsLicense.IsLicenceDetained(Convert.ToInt32(dr[4]));
                Isdetained = ClsLicense.IsLicenceDetained(Convert.ToInt32(dr[4])); 
            }
            catch (Exception ex)
            {
                MessageBox.Show("Please Enter a Valid License ID");
            }

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }
    }
}
