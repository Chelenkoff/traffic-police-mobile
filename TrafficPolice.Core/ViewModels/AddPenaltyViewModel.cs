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
        Service1Client client;

        IMvxLocationWatcher _watcher;
        public AddPenaltyViewModel(IMvxLocationWatcher watcher)
        {
            _watcher = watcher;

            //watcher.Start(new MvxLocationOptions(), OnLocation, OnError);
            //LocationingInfoMessage = "Позициониране . . .";
            Relocate();

            client = new Service1Client();
            client.addPenaltyToDriverOwnerCompleted += client_addPenaltyToDriverOwnerCompleted;



        }

        private void Relocate()
        {
            _watcher.Start(new MvxLocationOptions(), OnLocation, OnError);
            LocationingInfoMessage = "Позициониране . . .";
        }

        void client_addPenaltyToDriverOwnerCompleted(object sender, addPenaltyToDriverOwnerCompletedEventArgs e)
        {
            if (e.Error == null)
            {
                string addPenaltyResponse = e.Result;

                switch (addPenaltyResponse)
                {
                    case "SUCCESS":
                        WarningMessage = "Нарушението бе успешно добавено";
                        break;
                    case "QUERY_ERROR":
                        WarningMessage = "Неуспешно добавяне на нарушението";
                        break;
                    case "DB_ERROR":
                        WarningMessage = "Проблем при връзката с базата";
                        break;
                    default:
                        break;
                }
                stopLoading();

            }

        }

        public ICommand AddPenaltyCommand
        {
            get { return new DelegateCommand(addPenalty); }
        }
        private void addPenalty()
        {
            //clearInfoMessage();

            //if (!uiDataValidation(ID)) return;
            Penalty pen = new Penalty();
            pen.IssuerId = IssuerId;
            pen.DriverOwnerId = CriminalId;
            pen.IssuedDateTime = PenaltyIssuedDate;
            pen.HappenedDateTime = PenaltyHappenedDate;
            pen.Location = "";
            pen.Latitude = Latitude;
            pen.Longtitude = Longtitude;
            pen.Description = PenaltyDescription;
            pen.Disagreement = PenaltyDisagreement;
            client.addPenaltyToDriverOwnerAsync(pen);
            startLoading();
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
            WarningMessage = string.Empty;
            
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

        public ICommand RelocateCommand
        {
            get { return new DelegateCommand(Relocate); }
        }



        private double _latitude;
        public double Latitude
        {
            get { return _latitude; }
            set { _latitude = value; RaisePropertyChanged(() => Latitude); }
        }

        private string _warningMessage;
        public string WarningMessage
        {
            get { return _warningMessage; }
            set { _warningMessage = value; RaisePropertyChanged(() => WarningMessage); }
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



        //IsProgressRingVisible property
        private bool _isProgressRingVisible;
        public bool IsProgressRingVisible
        {
            get { return _isProgressRingVisible; }
            set
            {
                _isProgressRingVisible = value;
                RaisePropertyChanged(() => IsProgressRingVisible);
            }
        }
        private void startLoading()
        {
            IsProgressRingVisible = true;

        }
        private void stopLoading()
        {
            IsProgressRingVisible = false;
            clearMessageAfterDelay();

        }

        private async void clearMessageAfterDelay()
        {
            await Task.Delay(5000);
            WarningMessage = string.Empty ;
        }
    }
}
