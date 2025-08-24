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
    public partial class ApplicationInfo : UserControl
    {
        int ApplicationID;
        DataTable DataTable;
        public ApplicationInfo(int ApplicationID)
        {
            InitializeComponent();
            this.ApplicationID = ApplicationID;
            DataTable = ClsApplication.GetApplicationsByAppID(ApplicationID);
            DataRow row = DataTable.Rows[0];
            labelDLAPPID.Text = row[0].ToString();
            labelDLCLass.Text = row[13].ToString();
            labelPassedTests.Text = row[11].ToString();
            labelId.Text = row[1].ToString();
            labelSataus.Text = row[7].ToString();
            labelType.Text = row[6].ToString();
            labelDate.Text = row[5].ToString();
            labelCreatedBy.Text = row[10].ToString();
            labelstatusType.Text = row[8].ToString();
        }

        private void ApplicationInfo_Load(object sender, EventArgs e)
        {

        }
    }
}
