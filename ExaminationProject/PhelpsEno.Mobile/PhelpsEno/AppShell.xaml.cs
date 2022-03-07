using PhelpsEno.ViewModels;
using PhelpsEno.Views;
using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace PhelpsEno
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(ItemDetailPage), typeof(ItemDetailPage));
            Routing.RegisterRoute(nameof(NewItemPage), typeof(NewItemPage));
        }

    }
}
