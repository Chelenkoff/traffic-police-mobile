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
        Service1Client client = new Service1Client();
        public new LoginViewModel ViewModel
        {
            get { return (LoginViewModel)base.ViewModel; }
            set { base.ViewModel = value; }
        }
        public LoginView()
        {
            client = new Service1Client();
            //client.GetUserByIdAndPassCompleted += client_GetUserByIdAndPassCompleted;
            InitializeComponent();
        }



        //void client_GetUserByIdAndPassCompleted(object sender, GetUserByIdAndPassCompletedEventArgs e)
        //{
        //    if (e.Error == null)
        //    {
        //        MessageBox.Show(e.Result.FirstName);
        //    }
        //}


    }
}