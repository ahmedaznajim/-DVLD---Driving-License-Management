using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DVLI.Licence;
using Presentation;

namespace DVLI.Driver
{
    public partial class FormDriver : Form
    {
        public FormDriver()
        {
            InitializeComponent();
            dataGridView1.DataSource = ClsDriver.GetAllDriver();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void FormDriver_Load(object sender, EventArgs e)
        {

        }

        private void viewLicenceToolStripMenuItem_Click(object sender, EventArgs e)
        {
       
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ClsDriver.DeleteDriver(Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value)))
            {
                MessageBox.Show("Driver Deleted");
                dataGridView1.DataSource = ClsDriver.GetAllDriver();
            }
            else { MessageBox.Show("Driver Not Deleted"); }

        }

        private void viewLicenceHistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormViewLicenceHistory form = new FormViewLicenceHistory(Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value));
            form.ShowDialog();
        }
    }
}
