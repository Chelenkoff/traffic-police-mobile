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
using MvvmCross.Platform.Converters;
using MvvmCross.Platform.UI;
using System.Globalization;

namespace TrafficPolice.UI.Droid.Utilities
{
    public class BooleanToVisibilityValueConverter : MvxValueConverter<bool, MvxVisibility>
    {
        protected override MvxVisibility Convert(bool value, Type targetType, object parameter, CultureInfo culture)
        {
            return value ? MvxVisibility.Visible : MvxVisibility.Collapsed;
        }
    }
}