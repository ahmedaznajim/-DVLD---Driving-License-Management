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

namespace DVLI
{
    public partial class FormUpdateApplicationType : Form
    {
        public int ApplicationTypeID;
        public string ApplicationTypeTitle;
        public int ApplicationFees;

        public FormUpdateApplicationType(int applicationTypeID, string applicationTypeTitle, int applicationFees)
        {
            InitializeComponent();
            ApplicationTypeID = applicationTypeID;
            ApplicationTypeTitle = applicationTypeTitle;
            ApplicationFees = applicationFees;


        }

        private void FormUpdateApplicationType_Load(object sender, EventArgs e)
        {
            labelId.Text = ApplicationTypeID.ToString();
            textBoxApplicationFees.Text=ApplicationFees.ToString();
            textBoxApplicationTypeTitle.Text = ApplicationTypeTitle.ToString();

        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (ClsApplication.UpdateApplcationType(ApplicationTypeID, Convert.ToInt32(textBoxApplicationFees.Text), textBoxApplicationTypeTitle.Text))
                {
                    MessageBox.Show("Done");
                    
                }
                else
                {
                    MessageBox.Show("Faild");

                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }


        }
    }
}
