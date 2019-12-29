using System;
using System.Collections.Generic;
using System.Diagnostics;
using GalaSoft.MvvmLight.Ioc;
using WhoMeBroadcastReceiverViewer.ViewModels;
using Xamarin.Forms;

namespace WhoMeBroadcastReceiverViewer.Views
{
    public partial class RelayedPage : ContentPage
    {
        public RelayedPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            this.BindingContext = SimpleIoc.Default.GetInstance<RelayableViewModel>();

            Debug.WriteLine("RelayableViewModel Bound");
        }
    }
}
