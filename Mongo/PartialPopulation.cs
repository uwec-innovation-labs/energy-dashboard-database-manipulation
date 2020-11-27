using EnergyDashboardDatabaseManipulation.sql;
using EnergyDashboardDatabaseManipulation.TableHelper;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EnergyDashboardDatabaseManipulation.Mongo
{
    public class PartialPopulation{
        public async static Task PartialDBPopulation(string collectionId)
        {
            // mongodb://myDBReader:D1fficultP%40ssw0rd@mongodb0.example.com:27017/?authSource=admin
            var clientConnStr =
                $"mongodb://{Environment.GetEnvironmentVariable("MONGO_USR")}:" +
                $"{Environment.GetEnvironmentVariable("MONGO_PASS")}" +
                $"@{Environment.GetEnvironmentVariable("MONGO_URL")}" +
                $"/?authSource={Environment.GetEnvironmentVariable("MONGO_AUTHDB")}";
            var client = new MongoClient(clientConnStr);
            var database = client.GetDatabase("energy-dashboard");

            var dataList = await PartialQuery.MinuteCycleQuery();
            var returnDataList = new List<DBDocType>();

            if (collectionId == "kw")
            {
                foreach (var doc in dataList)
                {
                    returnDataList.Add(doc);
                }
                var collection = database.GetCollection<DBDocType>("kw");
                await collection.InsertManyAsync(returnDataList);
            }
            else if (collectionId == "kwh")
            {
                foreach (var doc in dataList)
                {
                    returnDataList.Add(doc);
                }
                var collection = database.GetCollection<DBDocType>("kwh");
                await collection.InsertManyAsync(returnDataList);
            }
        }
    }
}
