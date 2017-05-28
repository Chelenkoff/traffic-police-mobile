using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using MvvmCross.Binding.Droid.BindingContext;
using MvvmCross.Droid.FullFragging.Fragments;
using MvvmCross.Droid.Views;
using Android.App;

namespace TrafficPolice.UI.Droid.Views.Tabs
{
    [Activity(Label = "Водач")]

    public class DriverOwnerChildView : MvxActivity
    {

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.View_DriverOwnerChild);
        }
    }
}