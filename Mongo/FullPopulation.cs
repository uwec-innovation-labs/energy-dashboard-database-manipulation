using EnergyDashboardDatabaseManipulation.sql;
using EnergyDashboardDatabaseManipulation.TableHelper;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EnergyDashboardDatabaseManipulation.Mongo
{
    class FullPopulation
    {
        public async static Task FullDBPopulation()
        {
            // mongodb://myDBReader:D1fficultP%40ssw0rd@mongodb0.example.com:27017/?authSource=admin
            var clientConnStr =
                $"mongodb://{Environment.GetEnvironmentVariable("MONGO_USR")}:" +
                $"{Environment.GetEnvironmentVariable("MONGO_PASS")}" +
                $"@{Environment.GetEnvironmentVariable("MONGO_URL")}" +
                $"/?authSource={Environment.GetEnvironmentVariable("MONGO_AUTHDB")}";
            var client = new MongoClient(clientConnStr);
            var database = client.GetDatabase("energy-dashboard");

            var dataList = await FullQuery.FullDBQuery();

            var kwDataList = new List<DBDocType>();
            var kwhDataList = new List<DBDocType>();

            foreach (var doc in dataList)
            {
                if (doc.EnergyUnit == "kw")
                {
                    kwDataList.Add(doc);

                }
                else if (doc.EnergyUnit == "kwh")
                {
                    kwhDataList.Add(doc);

                }
            }
            Console.WriteLine("done sort");

            var collection = database.GetCollection<DBDocType>("kw");
            await collection.InsertManyAsync(kwDataList);
            collection = database.GetCollection<DBDocType>("kwh");
            await collection.InsertManyAsync(kwhDataList);
        }
    }
}
