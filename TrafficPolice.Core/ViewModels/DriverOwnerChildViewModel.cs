using MvvmCross.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrafficPolice.Core.ViewModels
{
    public class DriverOwnerChildViewModel : MvxViewModel
    {
        public DriverOwnerChildViewModel()
        {

        }
        public override void Start()
        {
            base.Start();
        }


        private string _foo = "Hello foo";
        public string Foo
        {
            get { return _foo; }
            set { _foo = value; RaisePropertyChanged(() => Foo); }
        }
    }
}
