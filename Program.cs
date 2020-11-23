using System;
using System.Threading.Tasks;
using EnergyDashboardDatabaseManipulation.Mongo;
using EnergyDashboardDatabaseManipulation.sql;
using EnergyDashboardDatabaseManipulation.TableHelper;


namespace EnergyDashboardDatabaseManipulation
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
           
            DateTimeOffset date = DateQuery.GetLatestDate();
            Console.WriteLine(date); 

            //MainAsync().GetAwaiter().GetResult();

        }

        private static async Task MainAsync()
        {
            // await FullPopulation.FullDBPopulation();
        }

    }
}
