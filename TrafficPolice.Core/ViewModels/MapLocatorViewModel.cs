using MvvmCross.Core.ViewModels;
using MvvmCross.Platform;
using MvvmCross.Plugins.Location;
using System;
using System.Collections.Generic;
using System.Device.Location;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrafficPolice.Core.Utilities;
using Windows.Devices.Geolocation;

namespace TrafficPolice.Core.ViewModels
{
    class MapLocatorViewModel : MvxViewModel
    {
        //private readonly IMvxLocationWatcher _watcher;
        public MapLocatorViewModel(IMvxLocationWatcher watcher)
        {

            //_watcher = watcher;
            //watcher.Start(new MvxLocationOptions(), OnLocation, OnError);
        }

        public void Init(CoordinatesParameters coordinates)
        {
            //Latitude = coordinates.Latitude;
            //Longtitude = coordinates.Longtitude;

            Location = new GeoCoordinate(coordinates.Latitude,coordinates.Longtitude);

        }

        private void OnError(MvxLocationError error)
        {
            Mvx.Error("Location error {0}", error.Code);
        }

        private void OnLocation(MvxGeoLocation location)
        {
            Longtitude = location.Coordinates.Longitude;
            Latitude = location.Coordinates.Latitude;
        }

        public override void Start()
        {
            base.Start();
        }

        private double _latitude;
        public double Latitude
        {
            get { return _latitude; }
            set { _latitude = value; RaisePropertyChanged(() => Latitude); }
        }

        private GeoCoordinate _location;
        public GeoCoordinate Location
        {
            get { return _location; }
            set { _location = value; RaisePropertyChanged(() => Location); }
        }

        private double _longtitude;
        public double Longtitude
        {
            get { return _longtitude; }
            set { _longtitude = value; RaisePropertyChanged(() => Longtitude); }
        }


    }
}
