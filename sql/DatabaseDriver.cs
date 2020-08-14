using System;
using System.Data.SqlClient;
using System.Text;

namespace EnergyDashboardDatabaseManipulation.sql
{
    public class DatabaseDriver
    {
        public static SqlConnection SQLConnect()
        {
            try
            {
                SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder
                {
                    DataSource = Environment.GetEnvironmentVariable("SQL_ADDR"),
                    UserID = Environment.GetEnvironmentVariable("SQL_USER"),
                    Password = Environment.GetEnvironmentVariable("SQL_PASS"),
                    InitialCatalog = Environment.GetEnvironmentVariable("SQL_DATABASE")
                };

                using (SqlConnection connection = new SqlConnection(builder.ConnectionString))
                { 
                    connection.Open();
                    return connection;
                }
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.ToString());
                return null; 
            }
        }
    }
}
