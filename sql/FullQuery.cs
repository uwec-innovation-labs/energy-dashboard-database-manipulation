using EnergyDashboardDatabaseManipulation.TableHelper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace EnergyDashboardDatabaseManipulation.sql
{
    public class FullQuery
    {
        public async static Task<List<DBDocType>> FullDBQuery()
        {
            var data = new List<DBDocType>();
            try
            {
                using SqlConnection connection = new SqlConnection(DatabaseDriver.SQLConnectionString().ConnectionString);
                await connection.OpenAsync();
                var tables = TableHelper.TableHelper.GetTables();
                foreach (var table in tables) 
                { 
                    String sql = $"SELECT t.TIMESTAMP, t.VALUE FROM {table.TableName} as t;";

                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        using (SqlDataReader reader = await command.ExecuteReaderAsync())
                        {
                            while (reader.Read())
                            {
                                var date = reader.GetValue(0);
                                var value = reader.GetValue(1);
                                if (date is DBNull d)
                                {
                                   
                                } else if (value is DBNull d1)
                                {
                                    var dateOffset = new DateTimeOffset((DateTime)date);
                                    var epoch = dateOffset.ToUnixTimeSeconds();

                                    data.Add(new DBDocType
                                    {
                                        BuildingName = table.BuildingName,
                                        EnergyType = table.EnergyType,
                                        EnergyUnit = table.EnergyUnit,
                                        UnixTimeValue = epoch,
                                        EnergyValue = 0
                                    });
                                } else
                                {
                                    var dateOffset = new DateTimeOffset((DateTime)date);
                                    var epoch = dateOffset.ToUnixTimeSeconds();

                                    data.Add(new DBDocType
                                    {
                                        BuildingName = table.BuildingName,
                                        EnergyType = table.EnergyType,
                                        EnergyUnit = table.EnergyUnit,
                                        UnixTimeValue = epoch,
                                        EnergyValue = (float)Convert.ToDouble(reader.GetValue(1))
                                    }); 
                                }
                               
                            }
                        }
                    }
                }
                return data;
                
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.ToString());
                return null;
            }
            
        }
    }
}
