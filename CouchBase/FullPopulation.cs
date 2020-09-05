using Couchbase;
using EnergyDashboardDatabaseManipulation.sql;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EnergyDashboardDatabaseManipulation.Couchbase
{
    public class FullPopulation
    {
        public async static Task FullDBPopulation()
        {
            int countkw = 0;
            int countkwh = 0;
            var cluster = await Cluster.ConnectAsync(
                Environment.GetEnvironmentVariable("COUCH_ADDR").ToString(),
                Environment.GetEnvironmentVariable("COUCH_USER").ToString(),
                Environment.GetEnvironmentVariable("COUCH_PASS").ToString());

            var dataList = await FullQuery.FullDBQuery();

           // var upsertTasks = new List<Task>();

            foreach (var doc in dataList)
            {
                var id = Guid.NewGuid().ToString();
                if (doc.EnergyUnit == "kw")
                {
                    var bucket = await cluster.BucketAsync("kw");
                    var collection = bucket.DefaultCollection();
                    // upsertTasks.Add(collection.UpsertAsync(id, doc));
                    await collection.UpsertAsync(id, doc);
                    Console.WriteLine(countkw);
                    countkw++;
                }
                else if (doc.EnergyUnit == "kwh")
                {
                    var bucket = await cluster.BucketAsync("kwh");
                    var collection = bucket.DefaultCollection();
                    //  upsertTasks.Add(collection.UpsertAsync(id, doc));
                    await collection.UpsertAsync(id, doc);
                    Console.WriteLine(countkwh);
                    countkwh++;
                }
            }
            Console.WriteLine(countkw + " " + countkwh);
          //  await Task.WhenAll(upsertTasks);
            
        }
    }
}
