using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Android.Content;
using Xamarin.Forms;
using WhoMeBroadcastReceiverViewer.ViewModels;
using GalaSoft.MvvmLight.Ioc;

namespace WhoMeBroadcastReceiverViewer.Droid
{
    [Activity(Label = "Broadcast Viewer", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = false, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        private ImmediatePersonaBroadcastReceiver _immediatePersonaBroadcastReceiver;
        private RelayablePersonaBroadcastReceiver _relayablePersonaBroadcastReceiver;
        private RegularPersonaBroadcastReceiver _regularPersonaBroadcastReceiver;

        private ImmediateViewModel _immediateViewModel;
        private RelayableViewModel _relayableViewModel;
        private RegularViewModel _regularViewModel;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(savedInstanceState);

            if (!SimpleIoc.Default.IsRegistered<ImmediateViewModel>())
            {
                SimpleIoc.Default.Register<ImmediateViewModel>(() => _immediateViewModel);
            }

            if (!SimpleIoc.Default.IsRegistered<RelayableViewModel>())
            {
                SimpleIoc.Default.Register<RelayableViewModel>(() => _relayableViewModel);
            }

            if (!SimpleIoc.Default.IsRegistered<RegularViewModel>())
            {
                SimpleIoc.Default.Register<RegularViewModel>(() => _regularViewModel);
            }

            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);
            LoadApplication(new App());
        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
        protected override void OnStart()
        {
            base.OnStart();

            _immediateViewModel = new ImmediateViewModel();
            _immediatePersonaBroadcastReceiver = new ImmediatePersonaBroadcastReceiver(this, (IUpdateMacroInfo)_immediateViewModel);

            IntentFilter immediateFilter = new IntentFilter(action: "cloud.whome.apps.whome.BROADCAST_IMMEDIATE_PERSONA");

            RegisterReceiver(_immediatePersonaBroadcastReceiver, immediateFilter);

            _relayableViewModel = new RelayableViewModel();
            _relayablePersonaBroadcastReceiver = new RelayablePersonaBroadcastReceiver(this, (IUpdateMacroInfo)_relayableViewModel);

            IntentFilter relayableFilter = new IntentFilter(action: "cloud.whome.apps.whome.BROADCAST_RELAYABLE_PERSONA");

            RegisterReceiver(_relayablePersonaBroadcastReceiver, relayableFilter);

            _regularViewModel = new RegularViewModel();
            _regularPersonaBroadcastReceiver = new RegularPersonaBroadcastReceiver(this, (IUpdateMacroInfo)_regularViewModel);

            IntentFilter regularFilter = new IntentFilter(action: "cloud.whome.apps.whome.BROADCAST_REGULAR_PERSONA");

            RegisterReceiver(_regularPersonaBroadcastReceiver, regularFilter);
        }

        protected override void OnDestroy()
        {
            base.OnDestroy();

            UnregisterReceiver(_immediatePersonaBroadcastReceiver);
            UnregisterReceiver(_relayablePersonaBroadcastReceiver);
            UnregisterReceiver(_regularPersonaBroadcastReceiver);
        }

        internal void MakeToast(string receivedText)
        {
            Device.BeginInvokeOnMainThread(() =>
            {
                Toast.MakeText(this, receivedText, ToastLength.Long).Show();
            });
        }
    }

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
        }
    }

    public class RelayablePersonaBroadcastReceiver : BroadcastReceiver
    {
        private MainActivity _mainActivity;
        private IUpdateMacroInfo _updater;

        public RelayablePersonaBroadcastReceiver(MainActivity mainActivity, IUpdateMacroInfo updater)
        {
            _mainActivity = mainActivity;
            _updater = updater;
        }

        public override void OnReceive(Context context, Intent intent)
        {
            string receivedText = intent.GetStringExtra("cloud.whome.apps.whome.SERIALISED_RELAYABLE_INFODIC");

            System.Diagnostics.Debug.WriteLine("cloud.whome.apps.whome.SERIALISED_RELAYABLE_INFODIC");
            System.Diagnostics.Debug.WriteLine(receivedText);

            _updater.UpdateMacroInfo(receivedText);
        }
    }

    public class RegularPersonaBroadcastReceiver : BroadcastReceiver
    {
        private MainActivity _mainActivity;
        private IUpdateMacroInfo _updater;

        public RegularPersonaBroadcastReceiver(MainActivity mainActivity, IUpdateMacroInfo updater)
        {
            _mainActivity = mainActivity;
            _updater = updater;
        }

        public override void OnReceive(Context context, Intent intent)
        {
            string receivedText = intent.GetStringExtra("cloud.whome.apps.whome.SERIALISED_REGULAR_INFODIC");

            System.Diagnostics.Debug.WriteLine("cloud.whome.apps.whome.SERIALISED_REGULAR_INFODIC");
            System.Diagnostics.Debug.WriteLine(receivedText);

            _updater.UpdateMacroInfo(receivedText);
        }
    }
}