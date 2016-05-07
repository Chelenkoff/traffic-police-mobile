using MvvmCross.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrafficPolice.Core.ViewModels
{
    public class RegistrationChildViewModel : MvxViewModel
    {
        public RegistrationChildViewModel()
        {

        }

        public override void Start()
        {
            base.Start();
        }

        private string _bar = "Hello bar";
        public string Bar
        {
            get { return _bar; }
            set { _bar = value; RaisePropertyChanged(() => Bar); }
        }
    }
}
