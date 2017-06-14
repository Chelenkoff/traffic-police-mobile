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
using Android.Icu.Text;
using Java.Sql;
using Android.Content.PM;

namespace TrafficPolice.UI.Droid.Views.Tabs
{
    [Activity(Label = "Справка за водач", ScreenOrientation = ScreenOrientation.SensorPortrait)]
    public class DriverOwnerDetailsView : MvxActivity
    {

        protected DriverOwnerDetailsViewModel DriverOwnerDetailsViewModel
        {
            get { return base.ViewModel as DriverOwnerDetailsViewModel; }
        }

        TabHost tabHost;
        TabHost.TabSpec spec;



        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            SetContentView(Resource.Layout.View_DriverOwnerDetails);

            tabHost = (TabHost)FindViewById(Resource.Id.tabhost);
            tabHost.Setup();

            spec = tabHost.NewTabSpec("Книжка");
            spec.SetContent(Resource.Id.tab_licence);
            spec.SetIndicator("Книжка");
            tabHost.AddTab(spec);

            spec = tabHost.NewTabSpec("Категории");
            spec.SetContent(Resource.Id.tab_categories);
            spec.SetIndicator("Категории");
            tabHost.AddTab(spec);

            spec = tabHost.NewTabSpec("Шофьор");
            spec.SetContent(Resource.Id.tab_personal_data);
            spec.SetIndicator("Шофьор");
            tabHost.AddTab(spec);


        }

        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Menu.driverowner_navigation_menu, menu);
            return true;
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            switch (item.ItemId)
            {
                case Resource.Id.penalty:
                    DriverOwnerDetailsViewModel.CreatePenaltyForDriverCommand.Execute(null);
                    return true;


                default:
                    return false;
            }
        }



    }
}






