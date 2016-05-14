using MvvmCross.Core.ViewModels;
using MvvmCross.Platform;
using MvvmCross.Plugins.Location;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TrafficPolice.Core.ServiceReference1;
using TrafficPolice.Core.Utilities;
using static TrafficPolice.Core.Utilities.DriverOwnerDetailsVMParams;

namespace TrafficPolice.Core.ViewModels
{
    class AddPenaltyViewModel : MvxViewModel
    {
        IMvxLocationWatcher _watcher;
        public AddPenaltyViewModel(IMvxLocationWatcher watcher)
        {
            _watcher = watcher;

            watcher.Start(new MvxLocationOptions(), OnLocation, OnError);
            LocationingInfoMessage = "Позициониране . . .";
            

        }
        public override void Start()
        {
            _penaltyIssuedDate = DateTime.Now;
            _penaltyHappenedDate = DateTime.Now;
            base.Start();
        }



        //Init VM with parameters (from DriverOwnerDetails VM
        public void Init(PenaltyVMParams parameters)
        {
            IssuerId = parameters.IssuerID;
            CriminalId = parameters.DriverOwnerID;
            
        }


        public ICommand ShowLocationCommand
        {
            get { return new DelegateCommand(showLocation); }
        }

        private void showLocation()
        {
            ShowViewModel<MapLocatorViewModel>(new CoordinatesParameters
            {
                Latitude = _latitude,
                Longtitude = _longtitude
                
            });


        }

        private double _latitude;
        public double Latitude
        {
            get { return _latitude; }
            set { _latitude = value; RaisePropertyChanged(() => Latitude); }
        }

        private string _penaltyDescription;
        public string PenaltyDescription
        {
            get { return _penaltyDescription; }
            set { _penaltyDescription = value; RaisePropertyChanged(() => PenaltyDescription); }
        }

        private string _penaltyDisagreement;
        public string PenaltyDisagreement
        {
            get { return _penaltyDisagreement; }
            set { _penaltyDisagreement = value; RaisePropertyChanged(() => PenaltyDisagreement); }
        }

        private long _criminalId;
        public long CriminalId
        {
            get { return _criminalId; }
            set { _criminalId = value; RaisePropertyChanged(() => CriminalId); }
        }

        private long _issuerId;
        public long IssuerId
        {
            get { return _issuerId; }
            set { _issuerId = value; RaisePropertyChanged(() => IssuerId); }
        }

        private DateTime _penaltyHappenedDate;
        public DateTime PenaltyHappenedDate
        {
            get { return _penaltyHappenedDate; }
            set { _penaltyHappenedDate = value; RaisePropertyChanged(() => PenaltyHappenedDate); }
        }

        private DateTime _penaltyIssuedDate;
        public DateTime PenaltyIssuedDate
        {
            get { return _penaltyIssuedDate; }
            set { _penaltyIssuedDate = value; RaisePropertyChanged(() => PenaltyIssuedDate); }
        }


        private string _locationingInfoMessage;
        public string LocationingInfoMessage
        {
            get { return _locationingInfoMessage; }
            set { _locationingInfoMessage = value; RaisePropertyChanged(() => LocationingInfoMessage); }
        }

        private double _longtitude;
        public double Longtitude
        {
            get { return _longtitude; }
            set { _longtitude = value; RaisePropertyChanged(() => Longtitude); }
        }

        private void OnError(MvxLocationError error)
        {
            //Mvx.Error("Location error {0}", error.Code);
            LocationingInfoMessage = "Позиционирането е неуспешно";
            _watcher.Stop();
        }

        private void OnLocation(MvxGeoLocation location)
        {
            Longtitude = location.Coordinates.Longitude;
            Latitude = location.Coordinates.Latitude;
            LocationingInfoMessage =String.Format("Позиционирането е успешно\nДълж: {0} Шир: {1}",Longtitude,Latitude);

            _watcher.Stop();
        }
    }
}
