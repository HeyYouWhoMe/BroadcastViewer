using Android.Content;
using GalaSoft.MvvmLight.Ioc;
using WhoMeBroadcastReceiverViewer.Services;
using WhoMeBroadcastReceiverViewer.ViewModels;

namespace WhoMeBroadcastReceiverViewer.Droid.BroadcastReceivers
{
    public class RegularPersonaBroadcastReceiver : BroadcastReceiver
    {
        private MainActivity _mainActivity;
        private IUpdateMacroInfo _updater;
        private IMyAzureEventHubService _eventHub;

        public RegularPersonaBroadcastReceiver(MainActivity mainActivity, IUpdateMacroInfo updater)
        {
            _mainActivity = mainActivity;
            _updater = updater;
            _eventHub = SimpleIoc.Default.GetInstance<IMyAzureEventHubService>();
        }

        public override void OnReceive(Context context, Intent intent)
        {
            string receivedText = intent.GetStringExtra("cloud.whome.apps.whome.SERIALISED_REGULAR_INFODIC");

            System.Diagnostics.Debug.WriteLine("cloud.whome.apps.whome.SERIALISED_REGULAR_INFODIC");
            System.Diagnostics.Debug.WriteLine(receivedText);

            _updater.UpdateMacroInfo(receivedText);

            // If you want to send this infoamtion over a network, create a service and pass the info to it here!
        }
    }
}
