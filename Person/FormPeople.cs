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


namespace DVLI
{
    public partial class peopleForm : Form
    {
        public peopleForm()
        {
            InitializeComponent();
        }

        private void peopleForm_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = Person.GetPplInfo();
        }

        private void AddPplbtn_Click(object sender, EventArgs e)
        {
            FormAddPerson save = new FormAddPerson();
            save.ShowDialog();


        }

        private void contextMenuStrip2_Opening(object sender, CancelEventArgs e)
        {

        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (dataGridView1.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];

                FormupdatePerson update = new FormupdatePerson(
                     Convert.ToInt32(selectedRow.Cells[0].Value),
                    Convert.ToString(selectedRow.Cells[1].Value), 
                    Convert.ToString(selectedRow.Cells[2].Value),  
                    Convert.ToString(selectedRow.Cells[3].Value),  
                    Convert.ToString(selectedRow.Cells[4].Value),  
                    Convert.ToString(selectedRow.Cells[5].Value),  
                    Convert.ToDateTime(selectedRow.Cells[6].Value), 
                    Convert.ToInt32(selectedRow.Cells[7].Value),
                    Convert.ToString(selectedRow.Cells[8].Value),
                    Convert.ToString(selectedRow.Cells[9].Value),
                     Convert.ToString(selectedRow.Cells[10].Value),
                     Convert.ToInt32(selectedRow.Cells[11].Value),
                     Convert.ToString(selectedRow.Cells[12].Value)

                );

                update.ShowDialog();
            }
            else
            {
                MessageBox.Show("Please select a row first.");
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void deletToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try { 
            DataGridViewRow s = dataGridView1.SelectedRows[0];
            
            

                if (Person.DeletPerson(Convert.ToInt32(s.Cells[0].Value)))
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
                MessageBox.Show("No Row Selected ");

            }


        }

        private void refreshToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = Person.GetPplInfo();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBoxSerch_TextChanged(object sender, EventArgs e)
        {


            if (comboBox1.SelectedIndex == 1)
            {


                dataGridView1.DataSource = Person.SerchByLName(textBoxSerch.Text);


            }

            if (comboBox1.SelectedIndex == 2)
            {
                try
                {
                    int i = Convert.ToInt32(textBoxSerch.Text);
                    dataGridView1.DataSource = Person.SerchByID(i);
                }
                catch { }

            }
            if (comboBox1.SelectedIndex == 3)
            {
                try
                {
                    string i = Convert.ToString(textBoxSerch.Text);
                    dataGridView1.DataSource = Person.SerchByNationalNo(i); 
                }
                catch { }

            }

            if (textBoxSerch.Text == "")
            {
                dataGridView1.DataSource = Person.GetPplInfo();


            }


        }
    }
}
