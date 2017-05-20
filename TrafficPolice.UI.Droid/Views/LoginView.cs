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

namespace TrafficPolice.UI.Droid.Views
{
    [Activity(Label = "КАТ - Пътна полиция", MainLauncher = true)]
    public class LoginView : MvxActivity
    {

        protected override void OnViewModelSet()
        {
            SetContentView(Resource.Layout.LoginView);
        }

    }
}