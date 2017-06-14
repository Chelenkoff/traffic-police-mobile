using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using TrafficPolice.Core.ViewModels;
using Android.Widget;
using MvvmCross.Droid.Views;
using Android.Content.PM;

namespace TrafficPolice.UI.Droid.Views
{


    [Activity(Label = "Нарушение", ScreenOrientation = ScreenOrientation.SensorLandscape)]


    public class AddPenaltyView : MvxActivity
    {
        protected AddPenaltyViewModel AddPenaltyViewModel
        {
            get { return base.ViewModel as AddPenaltyViewModel; }
        }

        TabHost tabHost;
        TabHost.TabSpec spec;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            SetContentView(Resource.Layout.View_AddPenalty);

            tabHost = (TabHost)FindViewById(Resource.Id.tabhost);
            tabHost.Setup();

            spec = tabHost.NewTabSpec("Обща информация");
            spec.SetContent(Resource.Id.tab_penalty_data);
            spec.SetIndicator("Обща информация");
            tabHost.AddTab(spec);

            spec = tabHost.NewTabSpec("Описание");
            spec.SetContent(Resource.Id.tab_penalty_description);
            spec.SetIndicator("Описание");
            tabHost.AddTab(spec);

            spec = tabHost.NewTabSpec("Възражение");
            spec.SetContent(Resource.Id.tab_penalty_protest);
            spec.SetIndicator("Възражение");
            tabHost.AddTab(spec);
        }



        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Menu.add_penalty_menu, menu);
            return true;
        }


        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            switch (item.ItemId)
            {
                case Resource.Id.relocation:
                    AddPenaltyViewModel.RelocateCommand.Execute(null);
                    return true;
                case Resource.Id.save:
                    AddPenaltyViewModel.AddPenaltyCommand.Execute(null);
                    return true;

                default:
                    return false;
            }
        }

    }
}