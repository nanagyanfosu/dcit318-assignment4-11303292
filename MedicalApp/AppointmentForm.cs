using System;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Windows.Forms;

namespace MedicalApp
{
    public partial class AppointmentForm : Form
    {
        public AppointmentForm()
        {
            InitializeComponent();
            LoadDoctors();
            LoadPatients();
        }

        private void LoadDoctors()
        {
            using (SqlConnection conn = DBConnection.GetConnection())
            {
                string query = "SELECT DoctorID, FullName FROM Doctors WHERE Availability = 1";
                SqlCommand cmd = new SqlCommand(query, conn);

                try
                {
                    SqlDataReader reader = cmd.ExecuteReader();
                    var dt = new DataTable();
                    dt.Load(reader);

                    cmbDoctors.DataSource = dt;
                    cmbDoctors.DisplayMember = "FullName";
                    cmbDoctors.ValueMember = "DoctorID";

                    if (cmbDoctors.Items.Count > 0)
                        cmbDoctors.SelectedIndex = 0; // force show first doctor
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading doctors: " + ex.Message);
                }
            }
        }



        private void LoadPatients()
        {
            using (SqlConnection conn = DBConnection.GetConnection())
            {
                string query = "SELECT PatientID, FullName FROM Patients";
                SqlCommand cmd = new SqlCommand(query, conn);

                try
                {
                    SqlDataReader reader = cmd.ExecuteReader();
                    var dt = new DataTable();
                    dt.Load(reader);

                    cmbPatients.DataSource = dt;
                    cmbPatients.DisplayMember = "FullName";
                    cmbPatients.ValueMember = "PatientID";

                    if (cmbPatients.Items.Count > 0)
                        cmbPatients.SelectedIndex = 0; // force show first patient
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading patients: " + ex.Message);
                }
            }
        }



        private void btnBook_Click(object sender, EventArgs e)
        {
            if (cmbDoctors.SelectedValue == null || cmbPatients.SelectedValue == null)
            {
                MessageBox.Show("Please select both a doctor and a patient.");
                return;
            }
            using (SqlConnection conn = DBConnection.GetConnection())
            {

                string query = "INSERT INTO Appointments (DoctorID, PatientID, AppointmentDate, Notes) " +
                               "VALUES (@DoctorID, @PatientID, @Date, @Notes)";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@DoctorID", cmbDoctors.SelectedValue);
                cmd.Parameters.AddWithValue("@PatientID", cmbPatients.SelectedValue);
                cmd.Parameters.AddWithValue("@Date", dtpDate.Value);
                cmd.Parameters.AddWithValue("@Notes", txtNotes.Text);

               
                int rows = cmd.ExecuteNonQuery();

                if (rows > 0)
                    MessageBox.Show("Appointment booked successfully!");
                else
                    MessageBox.Show("Failed to book appointment.");
            }
        }
    }
}
