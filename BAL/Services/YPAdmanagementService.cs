using BAL.Interfaces;
using Components;
using Components.RequestObjects;
using Components.ResponseObjects;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAL.Services
{
    public class YPAdmanagementService : IYPAdmanagementService
    {
        private readonly IYPAdManagementRepository _iIYPAdManagementRepository;

        public YPAdmanagementService(IYPAdManagementRepository repo)
        {
            this._iIYPAdManagementRepository = repo;
        }
        public ProcessResponse SaveServiceAd(YPServicePostRequest request)
        {
            ProcessResponse pr = new ProcessResponse();
            YPServicePostRequestFinal final = new YPServicePostRequestFinal();
            CloneObjects.CopyPropertiesTo(request, final);
            var apiResponse = _iIYPAdManagementRepository.SaveServiceAd(final, APIUri.PostYPAdd);
            
            return pr;
        }
    }


    
}
