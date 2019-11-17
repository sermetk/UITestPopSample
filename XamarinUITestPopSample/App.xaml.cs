using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XamarinUITestPopSample
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            MainPage = new MainTabbedPage();
        }
    }
}
