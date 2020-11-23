using System;
using System.Threading.Tasks;
using EnergyDashboardDatabaseManipulation.TableHelper;
using MongoDB.Driver;

namespace EnergyDashboardDatabaseManipulation.Mongo
{
    class DateQuery
    {
     

        public static DateTimeOffset GetLatestDate()
        {
            DateTimeOffset returnDate;
            // mongodb://myDBReader:D1fficultP%40ssw0rd@mongodb0.example.com:27017/?authSource=admin
            var clientConnStr =
                $"mongodb://{Environment.GetEnvironmentVariable("MONGO_USR")}:" +
                $"{Environment.GetEnvironmentVariable("MONGO_PASS")}" +
                $"@{Environment.GetEnvironmentVariable("MONGO_URL")}" +
                $"/?authSource={Environment.GetEnvironmentVariable("MONGO_AUTHDB")}";
            var client = new MongoClient(clientConnStr);
            
            var database = client.GetDatabase("energy-dashboard");
            var collection = database.GetCollection<MongoDocType>("kw");

            var result = collection.Find("{ }").Sort("{ UnixTimeValue : -1  }").Limit(1).FirstOrDefault();

            //print result 
            Console.WriteLine(result); 
            

            var date = (long) result.UnixTimeValue;
            Console.WriteLine(date);
            returnDate = DateTimeOffset.FromUnixTimeSeconds(date);
            return returnDate;


        }

    }

}
