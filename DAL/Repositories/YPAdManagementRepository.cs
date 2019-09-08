using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Components.ResponseObjects;
using Components.RequestObjects;
using DAL.Interfaces;
namespace DAL.Repositories
{
    public class YPAdManagementRepository : IYPAdManagementRepository
    {
        EcommerceProxy _ecommerceProxy;
        public YPAdManagementRepository()
        {
            _ecommerceProxy = new EcommerceProxy();
        }

        public Task<ApiResponse<ProcessResponse>> SaveServiceAd(YPServicePostRequestFinal request, string Uri)
        {
            //return _ecommerceProxy.PostApi<YPServicePostRequest, ProcessResponse>(request, Uri, "Post");
            return   _ecommerceProxy.PostAsyncApi<YPServicePostRequestFinal, ProcessResponse>(request, Uri);

        }

        
    }
}
