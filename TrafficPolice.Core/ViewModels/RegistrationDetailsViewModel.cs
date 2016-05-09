using MvvmCross.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrafficPolice.Core.ServiceReference1;

namespace TrafficPolice.Core.ViewModels
{
    public class RegistrationDetailsViewModel : MvxViewModel
    {

        public RegistrationDetailsViewModel()
        {

        }
        public override void Start()
        {
            Title = string.Format("Рег. номер: {0}", Registration.RegNum);
            base.Start();
        }

        public void Init(Registration reg)
        {
            Registration  = reg;
            // use the parameters here
        }


        private Registration _registration;
        public Registration Registration
        {
            get { return _registration; }
            set { _registration = value; RaisePropertyChanged(() => Registration); }
        }

        private string _title;
        public string Title
        {
            get { return _title; }
            set { _title = value; RaisePropertyChanged(() => Title); }
        }


    }
}
