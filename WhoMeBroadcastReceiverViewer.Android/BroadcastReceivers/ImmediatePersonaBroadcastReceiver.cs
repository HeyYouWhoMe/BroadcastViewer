using Android.Content;
using WhoMeBroadcastReceiverViewer.ViewModels;

namespace WhoMeBroadcastReceiverViewer.Droid.BroadcastReceivers
{
    public class ImmediatePersonaBroadcastReceiver : BroadcastReceiver
    {
        private MainActivity _mainActivity;
        private IUpdateMacroInfo _updater;

        public ImmediatePersonaBroadcastReceiver(MainActivity mainActivity, IUpdateMacroInfo updater)
        {
            _mainActivity = mainActivity;
            _updater = updater;
        }

        public override void OnReceive(Context context, Intent intent)
        {
            string receivedText = intent.GetStringExtra("cloud.whome.apps.whome.SERIALISED_IMMEDIATE_INFODIC");

            System.Diagnostics.Debug.WriteLine("cloud.whome.apps.whome.SERIALISED_IMMEDIATE_INFODIC");
            System.Diagnostics.Debug.WriteLine(receivedText);

            _updater.UpdateMacroInfo(receivedText);

            // If you want to send this infoamtion over a network, create a service and pass the info to it here!
        }
    }
}
