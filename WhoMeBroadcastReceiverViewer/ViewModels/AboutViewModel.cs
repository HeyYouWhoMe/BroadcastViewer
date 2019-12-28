using System;
using System.Windows.Input;

using Xamarin.Forms;

namespace WhoMeBroadcastReceiverViewer.ViewModels
{
    public class AboutViewModel : BaseViewModel
    {
        public AboutViewModel()
        {
            OpenWebCommand = new Command(() => Device.OpenUri(new Uri("https://github.com/HeyYouWhoMe/BroadcastViewer")));
        }

        public ICommand OpenWebCommand { get; }
    }
}