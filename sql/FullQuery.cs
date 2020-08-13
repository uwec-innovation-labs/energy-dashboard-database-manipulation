using System;
using System.Data.SqlClient;
using System.Text;

namespace EnergyDashboardDatabaseManipulation.sql
{
    public class FullQuery
    {
        public FullQuery(SqlConnection connection)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("SELECT TOP 20 pc.Name as CategoryName, p.name as ProductName ");
            sb.Append("FROM [SalesLT].[ProductCategory] pc ");
            sb.Append("JOIN [SalesLT].[Product] p ");
            sb.Append("ON pc.productcategoryid = p.productcategoryid;");
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
