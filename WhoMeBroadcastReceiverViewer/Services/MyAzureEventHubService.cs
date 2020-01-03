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
        private const string EventHubConnectionString = "Endpoint=sb://faademonamespace.servicebus.windows.net/;SharedAccessKeyName=faademosas;SharedAccessKey=15XEv+I5J3RyFX4GC0B9+nZJlyFZqpcL/1Fkcv8afTI=;EntityPath=faademoeventhub";
        private const string EventHubName = "faademoeventhub";

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
                    string jsonString = string.Empty;

                    // Event Hub Property Model serialisation
                    
                    var eventHubInfoDicDataTransmission = new EventHubInfoDicModel(sharedModel.PersonaGuid, sharedModel.InfoDic);
                    var serialisedEventHubInfoDicDataTransmission = JsonConvert.SerializeObject(eventHubInfoDicDataTransmission);
                    jsonString = serialisedEventHubInfoDicDataTransmission;
                   
                    Debug.WriteLine("EVENT HUB TRANSMISSION---------------------");
                    Debug.WriteLine(jsonString);
                    Debug.WriteLine("END---------------------");

                    await eventHubClient.SendAsync(new EventData(Encoding.UTF8.GetBytes(jsonString)));
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
