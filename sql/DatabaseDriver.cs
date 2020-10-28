using System;
using System.Data.SqlClient;
using System.Text;

namespace EnergyDashboardDatabaseManipulation.sql
{
    public class DatabaseDriver
    {
        public static SqlConnectionStringBuilder SQLConnectionString()
        {
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder
            {
                DataSource = Environment.GetEnvironmentVariable("SQL_ADDR"),
                UserID = Environment.GetEnvironmentVariable("SQL_USER"),
                Password = Environment.GetEnvironmentVariable("SQL_PASS"),
                InitialCatalog = Environment.GetEnvironmentVariable("SQL_DATABASE")
            };

            return builder;

        }
    }
}
