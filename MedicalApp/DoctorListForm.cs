using Microsoft.Data.SqlClient;
using System;
using System.Configuration;
using System.Windows.Forms;
using System.Data;


namespace MedicalApp
{
    public partial class DoctorListForm : Form
    {
        private DataGridView gridDoctors;
        public DoctorListForm()
        {

            InitializeComponent();
            gridDoctors = new DataGridView
            {
                Dock = DockStyle.Fill,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                ReadOnly = true
            };
            this.Controls.Add(gridDoctors);
            this.Load += DoctorListForm_Load;
        }

       

        private void DoctorListForm_Load(object sender, EventArgs e)
        {
            using (SqlConnection conn = DBConnection.GetConnection())
            {
                string query = "SELECT DoctorID, FullName, Specialty, Availability FROM Doctors";
                SqlCommand cmd = new SqlCommand(query, conn);

                try
                {
                    SqlDataReader reader = cmd.ExecuteReader();
                    var table = new System.Data.DataTable();
                    table.Load(reader);
                    dataGridView1.DataSource = table;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }
    }
}
