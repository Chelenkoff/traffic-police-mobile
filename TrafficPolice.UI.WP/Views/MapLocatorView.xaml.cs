using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using MvvmCross.WindowsPhone.Views;

namespace TrafficPolice.UI.WP.Views
{
    public partial class MapLocatorView : MvxPhonePage
    {
        public MapLocatorView()
        {
            InitializeComponent();
        }


        private void Map_Loaded_1(object sender, RoutedEventArgs e)
        {
            Microsoft.Phone.Maps.MapsSettings.ApplicationContext.ApplicationId = "62a9fcbd-6a12-41cc-afa5-a09000b97ff8";
            Microsoft.Phone.Maps.MapsSettings.ApplicationContext.AuthenticationToken = "jkQkTkbUhZxB5R23TKGgIw";
        }
    }
}