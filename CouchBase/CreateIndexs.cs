using Couchbase;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EnergyDashboardDatabaseManipulation.CouchBase
{
    /* TODO: Implement
    class CreateIndexs
    {
        public async Task<bool> CreateIndexKW()
        {
            var cluster = await Cluster.ConnectAsync(
                Environment.GetEnvironmentVariable("COUCH_ADDR").ToString(),
                Environment.GetEnvironmentVariable("COUCH_USER").ToString(),
                Environment.GetEnvironmentVariable("COUCH_PASS").ToString());

            var bucket = await cluster.BucketAsync("kw");
            var bucketManager = bucket.CreateManager();
            await bucketManager.CreateN1qlPrimaryIndexAsync();
            await bucketManager.CreateN1qlIndexAsync("index_name", new string[] { "name" });
            await bucketManager.CreateN1qlIndexAsync("index_emai", new string[] { "email" });
        }
        public async Task<bool> CreateIndexKWH()
        {

        }
    }
    */
}
