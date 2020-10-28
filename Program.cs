using System;
using System.Threading.Tasks;
using EnergyDashboardDatabaseManipulation.Couchbase;
using EnergyDashboardDatabaseManipulation.CouchBase;
using EnergyDashboardDatabaseManipulation.sql;
using EnergyDashboardDatabaseManipulation.TableHelper;


namespace EnergyDashboardDatabaseManipulation
{
    class Program
    {
        public static void Main(string[] args)
        {
            MainAsync().GetAwaiter().GetResult();

        }

        private static async Task MainAsync()
        {
            await FullPopulation.FullDBPopulation();
        }

    }
}
