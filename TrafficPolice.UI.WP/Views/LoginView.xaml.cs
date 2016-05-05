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
using TrafficPolice.Core.ViewModels;
using TrafficPolice.Core.ServiceReference1;

namespace TrafficPolice.UI.WP.Views
{
    public partial class LoginView : MvxPhonePage
    {
        public new LoginViewModel ViewModel
        {
            get { return (LoginViewModel)base.ViewModel; }
            set { base.ViewModel = value; }
        }
        public LoginView()
        {
            
            InitializeComponent();
            

        }

        private void MvxPhonePage_Loaded(object sender, RoutedEventArgs e)
        {
            Service1Client client = new Service1Client();
            client.GetDriverOwnerByIdAsync("9403122826");
            client.GetDriverOwnerByIdCompleted += client_GetDriverOwnerByIdCompleted;
        }

        void client_GetDriverOwnerByIdCompleted(object sender, GetDriverOwnerByIdCompletedEventArgs e)
        {
            if (e.Error == null)
            {
                MessageBox.Show(e.Result.FirstName);
            }
        }


    }
}