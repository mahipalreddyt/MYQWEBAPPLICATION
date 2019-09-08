using Components.RequestObjects;
using Components.ResponseObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IYPAdManagementRepository
    {
        //ApiResponse<ProcessResponse> SaveServiceAd(YPServicePostRequest request, string Uri);
        Task<ApiResponse<ProcessResponse>> SaveServiceAd(YPServicePostRequestFinal request, string Uri);
    }
}
