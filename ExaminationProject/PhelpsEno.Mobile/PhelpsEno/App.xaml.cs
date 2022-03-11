using PhelpsEno.Services;
using PhelpsEno.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PhelpsEno
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();

            DependencyService.Register<MockDataStore>();
            Sharpnado.Tabs.Initializer.Initialize(false, false);
            Sharpnado.Shades.Initializer.Initialize(loggerEnable: false);
            MainPage = new AuthorizePage();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
