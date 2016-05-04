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
    }
}