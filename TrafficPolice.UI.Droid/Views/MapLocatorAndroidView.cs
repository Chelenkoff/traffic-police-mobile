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
using Android.Content.PM;
using TrafficPolice.Core.ViewModels;
using MvvmCross.Droid.Support.V4;
using Android.Gms.Maps;

namespace TrafficPolice.UI.Droid.Views
{
    [Activity(Label = "Карта",  ScreenOrientation = ScreenOrientation.SensorPortrait)]
    public class MapLocatorAndroidView : MvxActivity, IOnMapReadyCallback
    {
        private GoogleMap _map;
        private MapFragment _mapFragment;

        protected MapLocatorAndroidViewModel AndroidMapLocatorViewModel
        {
            get { return base.ViewModel as MapLocatorAndroidViewModel; }
        }

        public void OnMapReady(GoogleMap googleMap)
        {
            _map = googleMap;
        }

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.View_AndroidMapLocator);


            InitMapFragment();

        }


        private void InitMapFragment()
        {
            _mapFragment = FragmentManager.FindFragmentById<MapFragment>(Resource.Id.map);
            if (_mapFragment == null)
            {
                _mapFragment.GetMapAsync(this);


                //GoogleMapOptions mapOptions = new GoogleMapOptions()
                //    .InvokeMapType(GoogleMap.MapTypeSatellite)
                //    .InvokeZoomControlsEnabled(false)
                //    .InvokeCompassEnabled(true);

                //FragmentTransaction fragTx = FragmentManager.BeginTransaction();
                //_mapFragment = MapFragment.NewInstance(mapOptions);
                //fragTx.Add(Resource.Id.map, _mapFragment, "map");

                //fragTx.Commit();
            }
            //_mapFragment.GetMapAsync(this);
        }

        protected override void OnViewModelSet()
        {
            SetContentView(Resource.Layout.View_AndroidMapLocator);
        }


    }
}