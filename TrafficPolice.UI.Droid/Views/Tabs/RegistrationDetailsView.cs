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
using Android.Content.PM;

namespace TrafficPolice.UI.Droid.Views.Tabs
{
    [Activity(Label = "Справка за регистрация", ScreenOrientation = ScreenOrientation.SensorPortrait)]

    public class RegistrationDetailsView : MvxActivity
    {

        protected RegistrationDetailsViewModel RegistrationDetailsViewModel
        {
            get { return base.ViewModel as RegistrationDetailsViewModel; }

        }

        TabHost tabHost;
        TabHost.TabSpec spec;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            SetContentView(Resource.Layout.View_RegistrationDetails);

            tabHost = (TabHost)FindViewById(Resource.Id.tabhost);
            tabHost.Setup();

            spec = tabHost.NewTabSpec("Застраховка");
            spec.SetContent(Resource.Id.tab_insurance);
            spec.SetIndicator("Застраховка");
            tabHost.AddTab(spec);

            spec = tabHost.NewTabSpec("Техн. х-ки");
            spec.SetContent(Resource.Id.tab_tech_details);
            spec.SetIndicator("Техн. х-ки");
            tabHost.AddTab(spec);

            spec = tabHost.NewTabSpec("Общи данни");
            spec.SetContent(Resource.Id.tab_common_data);
            spec.SetIndicator("Общи данни");
            tabHost.AddTab(spec);
        }

        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Menu.registration_navigation_menu, menu);
            return true;
        }


        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            switch (item.ItemId)
            {
                case Resource.Id.driverowner:
                    RegistrationDetailsViewModel.ShowDriverOwnerCommand.Execute(null);
                    return true;

                default:
                    return false;
            }
        }


    }
}