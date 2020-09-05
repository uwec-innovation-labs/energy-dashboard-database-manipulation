using EnergyDashboardDatabaseManipulation.TableHelper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace EnergyDashboardDatabaseManipulation.sql
{
    public class DataPointCountQuery
    {
        public static void CountQuery()
        {
            int totalDataPoints = 0;
            try
            {
                using SqlConnection connection = new SqlConnection(DatabaseDriver.SQLConnectionString().ConnectionString);
                connection.Open();
                var tables = TableHelper.TableHelper.GetTables();
                tables.ForEach(table =>
                {
                    String sql = $"SELECT COUNT(*) FROM {table.TableName} as t;";

                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                totalDataPoints += (int)reader.GetValue(0);
                            }
                        }
                    }
                });

                Console.WriteLine(totalDataPoints);
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.ToString());
            }

        }

    }

}
