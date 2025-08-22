using System;
using Microsoft.Data.SqlClient;
using System.Windows.Forms;
using System.Data;

namespace MedicalApp
{
    public partial class ManageAppointmentsForm : Form
    {
        private SqlDataAdapter adapter;
        private DataSet ds;
        public ManageAppointmentsForm()
        {
            InitializeComponent();
            LoadAppointments();
        }

        private void LoadAppointments()
        {
            using (SqlConnection conn = DBConnection.GetConnection())
            {
                string query = "SELECT AppointmentID, DoctorID, PatientID, AppointmentDate, Notes FROM Appointments";
                adapter = new SqlDataAdapter(query, conn);
                ds = new DataSet();
                adapter.Fill(ds, "Appointments");
                dataGridView1.DataSource = ds.Tables["Appointments"];
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select an appointment to update.");
                return;
            }
            int appointmentId = Convert.ToInt32(
                dataGridView1.SelectedRows[0].Cells["AppointmentID"].Value
            );
            try
            {
                adapter.Update(ds, "Appointments");
                MessageBox.Show("Appointments updated successfully.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select an appointment to delete.");
                return;
            }            
            int appointmentId = Convert.ToInt32(
                dataGridView1.SelectedRows[0].Cells["AppointmentID"].Value
            );

            using (SqlConnection conn = DBConnection.GetConnection())
            {
                string query = "DELETE FROM Appointments WHERE AppointmentID = @AppointmentID";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@AppointmentID", appointmentId);

                int rows = cmd.ExecuteNonQuery();

                if (rows > 0)
                {
                    MessageBox.Show("Appointment deleted successfully!");
                    LoadAppointments(); 
                }
                else
                {
                    MessageBox.Show("Failed to delete appointment.");
                }
            }
        }

    }
}
