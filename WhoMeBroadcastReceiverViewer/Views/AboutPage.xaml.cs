using WhoMeBroadcastReceiverViewer.ViewModels;
using Xamarin.Forms;

namespace WhoMeBroadcastReceiverViewer.Views
{
    public partial class AboutPage : ContentPage
    {
        public AboutPage()
        {
            InitializeComponent();

            this.BindingContext = new AboutViewModel();
        }
    }
}