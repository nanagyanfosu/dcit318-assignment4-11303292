using Microsoft.Data.SqlClient;
using System;
using System.Data;
using System.Windows.Forms;

namespace PharmacyApp
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void btnAddMedicine_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = DBConnection.GetConnection())
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("AddMedicine", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Name", txtName.Text);
                cmd.Parameters.AddWithValue("@Category", txtCategory.Text);
                cmd.Parameters.AddWithValue("@Price", decimal.Parse(txtPrice.Text));
                cmd.Parameters.AddWithValue("@Quantity", int.Parse(txtQuantity.Text));
                
                cmd.ExecuteNonQuery();
                MessageBox.Show("Medicine added successfully!");
                LoadMedicines();
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtSearch.Text))
            {
                LoadMedicines();
                return;
            }

            try
            {
                using (SqlConnection conn = DBConnection.GetConnection())
                using (SqlCommand cmd = new SqlCommand("SearchMedicine", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@SearchTerm", txtSearch.Text);

                    conn.Open();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dataGridView1.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error searching medicine: " + ex.Message);
            }
        }

        private void btnUpdateStock_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow == null)
            {
                MessageBox.Show("Select a medicine to update.");
                return;
            }

            if (!int.TryParse(txtQuantity.Text, out int newQty) || newQty < 0)
            {
                MessageBox.Show("Enter valid stock quantity.");
                return;
            }

            int medicineId = Convert.ToInt32(dataGridView1.CurrentRow.Cells["MedicineID"].Value);

            try
            {
                using (SqlConnection conn = DBConnection.GetConnection())
                using (SqlCommand cmd = new SqlCommand("UpdateStock", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@MedicineID", medicineId);
                    cmd.Parameters.AddWithValue("@Quantity", newQty);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                }

                MessageBox.Show("Stock updated!");
                LoadMedicines();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating stock: " + ex.Message);
            }
        }

        private void btnRecordSale_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow == null)
            {
                MessageBox.Show("Select a medicine first.");
                return;
            }

            
            int medicineId = Convert.ToInt32(dataGridView1.CurrentRow.Cells["MedicineID"].Value);

            if (!int.TryParse(txtQuantity.Text, out int quantitySold) || quantitySold <= 0)
            {
                MessageBox.Show("Enter a valid sale quantity.");
                return;
            }

            try
            {
                using (SqlConnection conn = DBConnection.GetConnection())
                using (SqlCommand cmd = new SqlCommand("dbo.RecordSale", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@MedicineID", medicineId);
                    cmd.Parameters.AddWithValue("@QuantitySold", quantitySold);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                }

                MessageBox.Show("Sale recorded!");
                LoadMedicines(); 
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error recording sale: " + ex.Message);
            }
        }


        private void btnViewAll_Click(object sender, EventArgs e)
        {
            LoadMedicines();
        }

        private void LoadMedicines()
        {
            using (SqlConnection conn = DBConnection.GetConnection())
            {
                SqlCommand cmd = new SqlCommand("GetAllMedicines", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(reader);
                dataGridView1.DataSource = dt;
            }
        }
       
    }
}
