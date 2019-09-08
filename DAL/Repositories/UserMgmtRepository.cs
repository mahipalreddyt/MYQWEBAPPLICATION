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
    public class UserMgmtRepository : IUserMgmtRepository
    {
        EcommerceProxy _ecommerceProxy;
        public UserMgmtRepository()
        {
            _ecommerceProxy = new EcommerceProxy();
        }

        public ApiResponse<LoginResponse> LoginCheck(LoginRequest request, string Uri)
        {
            return _ecommerceProxy.PostApi<LoginRequest, LoginResponse>(request, Uri,"Post");
        }

        public ApiResponse<ProcessResponse> EmailAvailableCheck(LoginRequest request, string Uri)
        {
            return _ecommerceProxy.PostApi<LoginRequest, ProcessResponse>(request, Uri, "Post");
             
        }

        public ApiResponse<ProcessResponse> RegisterUser(CustomerSaveRequest request, string Uri)
        {
            return _ecommerceProxy.PostApi<CustomerSaveRequest, ProcessResponse>(request, Uri, "Post");

        }
    }
}
