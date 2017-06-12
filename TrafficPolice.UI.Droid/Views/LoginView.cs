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
using System.ServiceModel;
using Android.Content.PM;

namespace TrafficPolice.UI.Droid.Views
{
    [Activity(Label = "КАТ - Пътна полиция", MainLauncher = true, ScreenOrientation = ScreenOrientation.SensorPortrait)]
    public class LoginView : MvxActivity
    {

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            SetContentView(Resource.Layout.View_Login);
        }

        protected override void OnViewModelSet()
        {
            SetContentView(Resource.Layout.View_Login);
        }
    }
}