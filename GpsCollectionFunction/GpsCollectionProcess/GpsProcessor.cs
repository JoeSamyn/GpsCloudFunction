using System;
using GpsCollectionProcess.Entities;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;
using MongoDB.Driver;
using Newtonsoft.Json;

namespace GpsCollectionProcess
{
    public static class GpsProcessor
    {

        static string telemtryDbName = "TelemetryData";
        static string gpsCollectionName = "GpsEvents";

        [FunctionName("Function1")]
        public static async void Run([ServiceBusTrigger("gps-data", Connection = "ServiceBusConnection")]string gpsEvent, ILogger log)
        {
            try {
                // Obtain GPS collection
                var collection = GetGpsCollection();

                var evt = JsonConvert.DeserializeObject<GpsEvent>(gpsEvent);

                await collection.InsertOneAsync(evt);

            } 
            catch(Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        /**
         * Configure the MongoDB instance 
         **/
        private static IMongoCollection<GpsEvent> GetGpsCollection()
        {
            var client = new MongoClient(System.Environment.GetEnvironmentVariable("MongoDbConnectionString"));
            var db = client.GetDatabase(telemtryDbName);
            var collection = db.GetCollection<GpsEvent>(gpsCollectionName);
            return collection;
        }
    }
}
