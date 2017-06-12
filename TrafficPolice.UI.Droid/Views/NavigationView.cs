using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using MvvmCross.Droid.Views;
using TrafficPolice.Core.ViewModels;
using TrafficPolice.UI.Droid.Views.Tabs;
using MvvmCross.Droid.Support.V4;
using Android.Support.V4.Content;
using Android.Content.PM;

namespace TrafficPolice.UI.Droid.Views
{
    [Activity(Label = "Справки", ScreenOrientation = ScreenOrientation.SensorPortrait)]
    public class NavigationView : MvxTabActivity
    {
        protected NavigationViewModel NavigationViewModel
        {
            get { return base.ViewModel as NavigationViewModel; }
        }
        
        protected override void OnCreate(Android.OS.Bundle bundle)
        {
            base.OnCreate(bundle);

            SetContentView(Resource.Layout.View_Navigation);

            TabHost.TabSpec spec;
            Intent intent;

            spec = TabHost.NewTabSpec("Регистрация");
            spec.SetIndicator("Регистрация");
            spec.SetContent(this.CreateIntentFor(NavigationViewModel.RegistrationChildVM));
            TabHost.AddTab(spec);

            spec = TabHost.NewTabSpec("Водач");
            spec.SetIndicator("Водач" );
            spec.SetContent(this.CreateIntentFor(NavigationViewModel.DriverOwnerChildVM));
            TabHost.AddTab(spec);




        }
        
        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Menu.navigation_menu, menu);
            return true;
        }


        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            switch (item.ItemId)
            {
                case Resource.Id.logout:
                    NavigationViewModel.Logout.Execute(null);
                    NavigationViewModel.DriverOwnerChildVM.Logout.Execute(null);
                    NavigationViewModel.RegistrationChildVM.Logout.Execute(null);
                    return true;
                case Resource.Id.penalty:
                    NavigationViewModel.CreatePenaltyCommand.Execute(null);
                    return true;
                default:
                    return false;
            }
        }




    }
}