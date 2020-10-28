using Couchbase;
using EnergyDashboardDatabaseManipulation.sql;
using EnergyDashboardDatabaseManipulation.TableHelper;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EnergyDashboardDatabaseManipulation.Couchbase
{
    public class FullPopulation
    {
        public async static Task FullDBPopulation()
        {
            var cluster = await Cluster.ConnectAsync(
                Environment.GetEnvironmentVariable("COUCH_ADDR").ToString(),
                Environment.GetEnvironmentVariable("COUCH_USER").ToString(),
                Environment.GetEnvironmentVariable("COUCH_PASS").ToString());

            var dataList = await FullQuery.FullDBQuery();

            foreach (var doc in dataList)
            {
                var id = Guid.NewGuid().ToString();
                if (doc.EnergyUnit == "kw")
                {
                    var bucket = await cluster.BucketAsync("kw");
                    var collection = bucket.DefaultCollection();
                    await collection.UpsertAsync(id, doc);
                }
                else if (doc.EnergyUnit == "kwh")
                {
                    var bucket = await cluster.BucketAsync("kwh");
                    var collection = bucket.DefaultCollection();
                    await collection.UpsertAsync(id, doc);
                }
            }
        }
    }
}
