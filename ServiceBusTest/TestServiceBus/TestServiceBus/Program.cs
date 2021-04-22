using Azure.Messaging.ServiceBus;
using Newtonsoft.Json;
using System;
using System.Threading.Tasks;

namespace TestServiceBus
{
    class Program
    {

        static string connectionString = "Endpoint=sb://test-telemetry-sb-mobile.servicebus.windows.net/;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=+W9MDCVGdODk8DK5Dpn3CLFaF/80PRNo1+HwWkxzip8=";
        static string queueName = "gps-data";

        static async Task Main(string[] args)
        {
            await SendMessage();
        }

        static async Task SendMessage()
        {
            await using (ServiceBusClient client = new ServiceBusClient(connectionString))
            {
                try
                {
                    var test = new GpsEvent
                    {
                        Username = "jtest",
                        Device = "S10e",
                        Manufacturer = "Samsung",
                        Polyline = "askldfjh",
                        Accuracy = 10,
                        Speed = 30,
                        Bearing = 100,
                        Timestamp = DateTimeOffset.Now
                    };

                    ServiceBusSender sender = client.CreateSender(queueName);

                    var message = JsonConvert.SerializeObject(test);
                    ServiceBusMessage busMessage = new ServiceBusMessage(message);

                    await sender.SendMessageAsync(busMessage);
                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex);
                }
            }
        }
    }
}
