using System;
using System.Data.SqlClient;
using System.Text;

namespace EnergyDashboardDatabaseManipulation.sql
{
    public class FullQuery
    {
        public static void FullDBQuery(SqlConnection connection)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("SELECT * ");
            sb.Append("FROM UWEC_HORAN_KW;");
            String sql = sb.ToString();

            using (SqlCommand command = new SqlCommand(sql, connection))
            {
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Console.WriteLine("{0} {1}", reader.GetString(0), reader.GetString(1));
                    }
                }
            }
        }
    }
}
