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
using Windows.ApplicationModel.Core;
using Windows.ApplicationModel.Activation;

namespace TrafficPolice.UI.WP.Views
{
    public partial class NavigationView : MvxPhonePage
    {
        public NavigationView()
        {

            InitializeComponent();
            var view = CoreApplication.GetCurrentView();
            view.Activated += ViewOnActivated;
        }

        private void ViewOnActivated(CoreApplicationView sender, IActivatedEventArgs args)
        {
            var continuationArgs = args as FileOpenPickerContinuationEventArgs;
            if (continuationArgs == null) return;

        }
    }
}