using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;

namespace MedicalApp
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            TestConnection();
        }

        // Testing connection to MedicalDB database in SQL Server
        private void TestConnection()
        {
            using (SqlConnection conn = DBConnection.GetConnection())
            {
                if (conn.State == System.Data.ConnectionState.Open)
                {
                    MessageBox.Show("Successfully connected to database!");
                }
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        private void MainForm_Load_1(object sender, EventArgs e)
        {

        }

        private void btnDoctors_Click(object sender, EventArgs e)
        {
            new DoctorListForm().ShowDialog();
        }
        private void btnBook_Click(object sender, EventArgs e)
        {
            new AppointmentForm().ShowDialog();
        }
        private void btnManage_Click(object sender, EventArgs e)
        {
            new ManageAppointmentsForm().ShowDialog();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }







        //private void btnDoctors_Click(object sender, EventArgs e)
        //{
        //    new DoctorListForm().ShowDialog();
        //}

        //private void btnBook_Click(object sender, EventArgs e)
        //{
        //    new AppointmentForm().ShowDialog();
        //}

        //private void btnManage_Click(object sender, EventArgs e)
        //{
        //    new ManageAppointmentsForm().ShowDialog();
        //}

    }
}
