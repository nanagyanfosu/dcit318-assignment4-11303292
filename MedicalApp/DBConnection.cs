using System;
using System.Data;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;

public class DBConnection
{
    private static string connectionString = @"Data Source=localhost\SQLEXPRESS;Initial Catalog=medicalDB;Integrated Security=True;TrustServerCertificate=True";

    public static SqlConnection GetConnection()
    {
        SqlConnection connection = new SqlConnection(connectionString);
        try
        {
            connection.Open();
        }
        catch (SqlException ex)
        {
            MessageBox.Show("Error connecting to database: " + ex.Message);
        }
        return connection;
    }

    // Add this method to test the connection
    public static void TestConnection()
    {
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            try
            {
                connection.Open();
                MessageBox.Show("Connection to database was successful!");
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Error connecting to database: " + ex.Message);
            }
        }
    }
}