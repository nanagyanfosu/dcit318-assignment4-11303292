using System;
using System.Data;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;

public static class DBConnection
{
   
    private static readonly string connectionString =
        @"Data Source=localhost\SQLEXPRESS;Initial Catalog=medicalDB_11259806;Integrated Security=True;TrustServerCertificate=True";

    
    public static SqlConnection GetConnection()
    {
        SqlConnection connection = new SqlConnection(connectionString);

        try
        {
            connection.Open();
        }
        catch (SqlException ex)
        {
            MessageBox.Show($"Database connection failed:\n{ex.Message}", "Connection Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
            connection = null; 
        }

        return connection;
    }

    
    public static void TestConnection()
    {
        try
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                MessageBox.Show("Connected to database successfully!", "Success",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        catch (SqlException ex)
        {
            MessageBox.Show($"Database connection failed:\n{ex.Message}", "Connection Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
