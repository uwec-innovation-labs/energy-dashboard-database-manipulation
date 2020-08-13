using System;
using System.Data.SqlClient;
using System.Text;

namespace EnergyDashboardDatabaseManipulation.sql
{
    public class DatabaseDriver
    {
        public SqlConnection SQLConnect()
        {
            try
            {
                SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();

                builder.DataSource = "<your_server.database.windows.net>";
                builder.UserID = "<your_username>";
                builder.Password = "<your_password>";
                builder.InitialCatalog = "<your_database>";

                using (SqlConnection connection = new SqlConnection(builder.ConnectionString))
                { 
                    connection.Open();
                   
                }
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.ToString());
            }
        }
    }
}
