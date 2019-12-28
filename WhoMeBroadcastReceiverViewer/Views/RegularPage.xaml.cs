using System;
using System.Collections.Generic;
using GalaSoft.MvvmLight.Ioc;
using WhoMeBroadcastReceiverViewer.ViewModels;
using Xamarin.Forms;

namespace WhoMeBroadcastReceiverViewer.Views
{
    public partial class RegularPage : ContentPage
    {
        public RegularPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            this.BindingContext = SimpleIoc.Default.GetInstance<RegularViewModel>();
        }
    }
}
