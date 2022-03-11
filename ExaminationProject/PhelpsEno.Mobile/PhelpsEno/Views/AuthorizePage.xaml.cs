using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PhelpsEno.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AuthorizePage : ContentPage
    {
        public AuthorizePage()
        {
            InitializeComponent();
        }
        
        private void SignIn_OnClicked(object sender, EventArgs e)
        {
            Application.Current.MainPage = new Tab();
        }
    }
}