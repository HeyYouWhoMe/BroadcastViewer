using Android.Content;
using GalaSoft.MvvmLight.Ioc;
using WhoMeBroadcastReceiverViewer.Services;
using WhoMeBroadcastReceiverViewer.ViewModels;

namespace WhoMeBroadcastReceiverViewer.Droid.BroadcastReceivers
{
    public class RelayablePersonaBroadcastReceiver : BroadcastReceiver
    {
        private MainActivity _mainActivity;
        private IUpdateMacroInfo _updater;
        private IMyAzureEventHubService _eventHub;

        public RelayablePersonaBroadcastReceiver(MainActivity mainActivity, IUpdateMacroInfo updater)
        {
            _mainActivity = mainActivity;
            _updater = updater;
            _eventHub = SimpleIoc.Default.GetInstance<IMyAzureEventHubService>();
        }

        public override void OnReceive(Context context, Intent intent)
        {
            string receivedText = intent.GetStringExtra("cloud.whome.apps.whome.SERIALISED_RELAYABLE_INFODIC");

            System.Diagnostics.Debug.WriteLine("cloud.whome.apps.whome.SERIALISED_RELAYABLE_INFODIC");
            System.Diagnostics.Debug.WriteLine(receivedText);

            _updater.UpdateMacroInfo(receivedText);

            // If you want to send this infoamtion over a network, create a service and pass the info to it here!

            _eventHub.Send(receivedText, "86f9519b-fbde-4f86-828e-75f37df17665"); // Put the Persona Guid you want to filter for, here! 
        }
    }
}
