using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Xamarin.Forms;

namespace XamarinUITestPopSample
{
    public class ThirdPageViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #region Properties
        private string _labelText;
        public string LabelText
        {
            get { return _labelText; }
            set { _labelText = value; OnPropertyChanged(); }
        }
        private string _entryValidationStatusText;
        public string EntryValidationStatusText
        {
            get { return _entryValidationStatusText; }
            set { _entryValidationStatusText = value; OnPropertyChanged(); }
        }
        #endregion

        #region Commands
        public ICommand EntryButtonCommand { get; set; }
        public ICommand OpenPushModalCommand { get; set; }
        #endregion

        public ThirdPageViewModel()
        {
            EntryButtonCommand = new Command(() =>
            {
                if (LabelText == "Test")
                    EntryValidationStatusText = "Valid";
                else
                    EntryValidationStatusText = string.Empty;
            });
            OpenPushModalCommand = new Command(() =>
            {
                Application.Current.MainPage.Navigation.PushModalAsync(new ContentPage { AutomationId = "PushModalPage_AutomationId" });
            });
        }
    }
}

