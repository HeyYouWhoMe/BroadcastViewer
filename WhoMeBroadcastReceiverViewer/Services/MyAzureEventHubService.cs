using System;
using Microsoft.Azure.EventHubs;
using System.Text;
using System.Threading.Tasks;
using WhoMeBroadcastReceiverViewer.Models;
using Newtonsoft.Json;
using System.Diagnostics;

namespace WhoMeBroadcastReceiverViewer.Services
{
    public class MyAzureEventHubService : IMyAzureEventHubService
    {
        private static EventHubClient eventHubClient;
        private const string EventHubConnectionString = "[Put your SHARED ACCESS POLICY SAS 'Hub Connection' String here!!!]";
        private const string EventHubName = "[Put thE NAME of your EVENT HUB here!!!!]";

        public MyAzureEventHubService()
        {
            // Creates an EventHubsConnectionStringBuilder object from the connection string, and sets the EntityPath.
            // Typically, the connection string should have the entity path in it, but this simple scenario
            // uses the connection string from the namespace.
            var connectionStringBuilder = new EventHubsConnectionStringBuilder(EventHubConnectionString)
            {
                EntityPath = EventHubName
            };

            eventHubClient = EventHubClient.CreateFromConnectionString(connectionStringBuilder.ToString());
        }

        public async Task Send(string receivedSerialisation, string guidFilter)
        {
            BroadcastInfoDic sharedModel = JsonConvert.DeserializeObject<BroadcastInfoDic>(receivedSerialisation);
            
            try
            {
                if (sharedModel.PersonaGuid.Equals(guidFilter))
                {

                    var eventHubDataTransmission = new EventHubModel(sharedModel.PersonaGuid, sharedModel.InfoDic);
                    var serialisedTransmission = JsonConvert.SerializeObject(eventHubDataTransmission);

                    Debug.WriteLine("EVENT HUB TRANSMISSION---------------------");
                    Debug.WriteLine(serialisedTransmission);
                    Debug.WriteLine("END---------------------");

                    await eventHubClient.SendAsync(new EventData(Encoding.UTF8.GetBytes(serialisedTransmission)));
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine($"{DateTime.Now} > Exception: {exception.Message}");
            }
        }

        public async Task CloseEventHubConnection()
        {
            await eventHubClient.CloseAsync();
        }
    }
}
