using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Presentation;

namespace DVLI
{
    public partial class FormAddTestAppointment : Form
    {
        DataRow row;
        int PartToenable;
        int UserId;
        public FormAddTestAppointment(DataRow row, int PartToenable, int UserId)
        {
            InitializeComponent();
            this.row = row;
       this.PartToenable = PartToenable;
            this.UserId = UserId;

            groupBox2.Enabled = false;

            labelDLAPPID.Text = row[0].ToString();
            labelDLCLass.Text = row[13].ToString();
          
            labelName.Text = row[10].ToString();
          
            labelFees.Text = row[9].ToString();
            if(PartToenable == 0)
            {
                groupBox1.Enabled=true;
                groupBox2.Enabled=false;
                

            }
            if (PartToenable == 1)
            {
                labelRFees.Text = "5";
                labelTotalFees.Text = "15";
             
                groupBox2.Enabled = true;
                groupBox1.Enabled = false;


            }


        }

        private void FormAddTestAppointment_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (PartToenable == 0)
            {

                if (ClsTest.AddAnTestAppointment(1, Convert.ToInt32(row[0]), dateTimePicker1.Value, 10, Convert.ToInt32(row[10]), 0) == -1)
                {
                    MessageBox.Show("Faild");

                }
                else
                {

                    MessageBox.Show("Done");
                    this.Hide();
                }
            }

                if (PartToenable == 1)
                {
                    int APPID = ClsApplication.AddNewApplication(Convert.ToInt32(row[4]), DateTime.Now, 8, 1, DateTime.Now, 5, 1);
                    labelRAppId.Text=APPID.ToString();
                    
                   if (APPID>0)
                    {
                       if (ClsTest.AddAnTestAppointment(1, Convert.ToInt32(row[0]), dateTimePicker2.Value, 15, 1, 0) == -1)
                        {
                            MessageBox.Show("Faild");

                        }
                        else
                        {
                            MessageBox.Show("Done");
                        this.Hide();

                    }

                    }

                }
            }
        }
    }

