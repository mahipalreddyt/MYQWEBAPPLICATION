using Components.RequestObjects;
using Components.ResponseObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAL.Interfaces
{
   public  interface IYPAdmanagementService
    {
        ProcessResponse SaveServiceAd(YPServicePostRequest request);
    }
}
