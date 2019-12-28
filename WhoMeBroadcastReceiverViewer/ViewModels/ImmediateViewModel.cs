using System;
using System.Windows.Input;
using GalaSoft.MvvmLight.Command;

namespace WhoMeBroadcastReceiverViewer.ViewModels
{
    public class ImmediateViewModel : BaseViewModel, IUpdateMacroInfo
    {
        private bool _isDisplaying = true;

        public ICommand ClearCommand { get; set; }
        public ICommand ToggleCommand { get; set; }

        string _macroInfo = string.Empty;
        public string MacroInfo
        {
            get { return _macroInfo; }
            set { SetProperty(ref _macroInfo, value); }
        }

        string _toggleButtonText = string.Empty;
        public string ToggleButtonText
        {
            get { return _toggleButtonText; }
            set { SetProperty(ref _toggleButtonText, value); }
        }

        string _clearButtonText = string.Empty;
        public string ClearButtonText
        {
            get { return _clearButtonText; }
            set { SetProperty(ref _clearButtonText, value); }
        }

        string _timestamp = string.Empty;
        public string Timestamp
        {
            get { return _timestamp; }
            set { SetProperty(ref _timestamp, value); }
        }

        public ImmediateViewModel()
        {
            ClearButtonText = "Clear";
            ToggleButtonText = "Pause";

            ClearCommand = new RelayCommand(() =>
            {
                MacroInfo = string.Empty;
                Timestamp = string.Empty;
            });

            ToggleCommand = new RelayCommand(() =>
            {
                _isDisplaying = !_isDisplaying;

                if(_isDisplaying)
                {
                    ToggleButtonText = "Pause";
                }
                else
                {
                    ToggleButtonText = "Listen";
                }
            });
        }

        public void UpdateMacroInfo(string info)
        {
            if (_isDisplaying)
            {
                MacroInfo = info;
                Timestamp = "at " + DateTime.Now.ToLongTimeString();
            }
        }
    }

    public interface IUpdateMacroInfo
    {
        void UpdateMacroInfo(string info);
    }
}
