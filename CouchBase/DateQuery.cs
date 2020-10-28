using Couchbase;
using Couchbase.Query;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EnergyDashboardDatabaseManipulation.CouchBase
{
    class DateQuery
    {
        /* Only works when primary and date index has been created on bucket */
        public static async Task<DateTimeOffset> GetLatestDate(string bucketID)
        {
            DateTimeOffset returnDate; 
            var cluster = await Cluster.ConnectAsync(
                Environment.GetEnvironmentVariable("COUCH_ADDR").ToString(),
                Environment.GetEnvironmentVariable("COUCH_USER").ToString(),
                Environment.GetEnvironmentVariable("COUCH_PASS").ToString());


            var queryString = $"SELECT MAX(unixTimeValue) AS maxTime FROM `{bucketID}`";
            var result = await cluster.QueryAsync<dynamic>(queryString);

            if (result.MetaData.Status != QueryStatus.Success)
            {
                // error 
            }

            await foreach (var row in result)
            {
                if (row.maxTime == null)
                {
                    return DateTimeOffset.Now;
                }
                var date = (long)row.maxTime;
                Console.WriteLine(date);
                returnDate = DateTimeOffset.FromUnixTimeSeconds(date);
                return returnDate;
            }

            return DateTimeOffset.Now; 
        }
    }
}

