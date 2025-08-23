using Microsoft.Data.SqlClient;
using System;
using System.Data;


namespace PharmacyApp
{
    public static class DBConnection
    {
        private static readonly string connString =
            "Server=localhost\\SQLEXPRESS;Database=PharmacyDB;Trusted_Connection=True;Integrated Security=True;TrustServerCertificate=True";

        public static SqlConnection GetConnection()
        {
            return new SqlConnection(connString);
        }
    }
}
