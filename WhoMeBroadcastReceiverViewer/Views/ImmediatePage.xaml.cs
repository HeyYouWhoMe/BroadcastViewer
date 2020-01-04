using System.Diagnostics;
using GalaSoft.MvvmLight.Ioc;
using WhoMeBroadcastReceiverViewer.ViewModels;
using Xamarin.Forms;

namespace WhoMeBroadcastReceiverViewer.Views
{
    public partial class ImmediatePage : ContentPage
    {
        public ImmediatePage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            this.BindingContext = SimpleIoc.Default.GetInstance<ImmediateViewModel>();
        }
    }
}
