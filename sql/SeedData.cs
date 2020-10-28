using EnergyDashboardDatabaseManipulation.TableHelper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Threading.Tasks;

namespace EnergyDashboardDatabaseManipulation.sql
{
    /* This is a work in progress 
    public class SeedData
    {
        public async static Task<List<DBDocType>> FullSeed()
        {
            var data = new List<DBDocType>();
            var exportData = TableHelper.TableHelper.GetSampleData();
            foreach (var dataPoint in exportData)
            {

                data.Add(new DBDocType
                {
                    BuildingName = dataPoint.BuildingName,
                    EnergyType = dataPoint.EnergyType,
                    EnergyUnit = dataPoint.EnergyUnit,
                    UnixTimeValue = dataPoint.UnixTimeValue,
                    EnergyValue = dataPoint.EnergyValue
                });
            }
            return data;
        }
    }
    */
}



