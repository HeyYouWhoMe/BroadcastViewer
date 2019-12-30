using System;
using System.Threading.Tasks;

namespace WhoMeBroadcastReceiverViewer.Services
{
    public interface IMyAzureEventHubService
    {
        Task Send(string receivedSerialisation, string guidFilter);
    }
}
