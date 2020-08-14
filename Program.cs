using System;
using EnergyDashboardDatabaseManipulation.sql;
using EnergyDashboardDatabaseManipulation.TableHelper;

namespace EnergyDashboardDatabaseManipulation
{
    class Program
    {
        static void Main(string[] args)
        {
            sql.FullQuery.FullDBQuery(sql.DatabaseDriver.SQLConnect());
        }
    }
}
