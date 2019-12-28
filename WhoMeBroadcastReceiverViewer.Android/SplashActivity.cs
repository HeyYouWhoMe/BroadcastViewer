using System;
using Android.App;
using Android.Support.V7.App;

namespace WhoMeBroadcastReceiverViewer.Droid
{
    [Activity(Label = "Broadcast Viewer", Icon = "@mipmap/icon", Theme = "@style/splashscreen", MainLauncher = true, NoHistory = true)]
    public class SplashActivity : AppCompatActivity
    {
        protected override void OnResume()
        {
            base.OnResume();
            StartActivity(typeof(MainActivity));
        }
    }
}
