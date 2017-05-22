using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using TrafficPoliceWcfHost.Model;

namespace TrafficPoliceWcfHost
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface ITrafficPoliceService
    {
        [OperationContract]
        User GetUserByIdAndPass(string id, string password);


        [OperationContract]
        DriverOwner GetDriverOwnerById(string id);


        [OperationContract]
        Registration getRegByRegNum(string regNum);

        [OperationContract]
        string addPenaltyToDriverOwner(Penalty pen);

        // TODO: Add your service operations here
    }



}
