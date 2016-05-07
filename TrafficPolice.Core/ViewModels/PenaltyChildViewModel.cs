using MvvmCross.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrafficPolice.Core.ViewModels
{
    public class PenaltyChildViewModel : MvxViewModel
    {
        public PenaltyChildViewModel()
        {

        }
        public override void Start()
        {
            base.Start();
        }

        private string _oink = "Hello oink";
        public string Oink
        {
            get { return _oink; }
            set { _oink = value; RaisePropertyChanged(() => Oink); }
        }


    }
}
