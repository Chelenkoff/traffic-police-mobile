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
using MvvmCross.Binding.Droid.BindingContext;
using MvvmCross.Droid.Support.V4;
using MvvmCross.Droid.Views;
using Android.Content.PM;

namespace TrafficPolice.UI.Droid.Views.Tabs
{
    [Activity(Label ="Регистрация", ScreenOrientation = ScreenOrientation.SensorPortrait)]
    public class RegistrationChildView : MvxActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.View_RegistrationChild);
        }

    }
}