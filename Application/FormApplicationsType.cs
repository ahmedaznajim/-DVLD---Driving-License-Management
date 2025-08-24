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
    public partial class FormApplicationsType : Form
    {
        public FormApplicationsType()
        {
            InitializeComponent();
            dataGridView1.DataSource=ClsApplication.GetAllApplicationsType();
        }

        private void FormApplicationsType_Load(object sender, EventArgs e)
        {

        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];

               FormUpdateApplicationType formUpdateApplicationType=new FormUpdateApplicationType(
                     Convert.ToInt32(selectedRow.Cells[0].Value),
                    Convert.ToString(selectedRow.Cells[1].Value),
                    Convert.ToInt32(selectedRow.Cells[2].Value)
                  

                );

                formUpdateApplicationType.ShowDialog();
            }
            else
            {
                MessageBox.Show("Please select a row first.");
            }
        }

        private void refreshToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = ClsApplication.GetAllApplicationsType();
        }
    }
}
