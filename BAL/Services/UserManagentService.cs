using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Interfaces;
using Components.ResponseObjects;
using Components.RequestObjects;
using Components;
using BAL.Interfaces;

namespace BAL.Services
{
    public class UserManagentService : IUserManagentService
    {
        public readonly IUserMgmtRepository _userMgmtRepository;
        public UserManagentService(IUserMgmtRepository repo)
        {
            _userMgmtRepository = repo;
        }
        public ApiResponse<LoginResponse> LoginCheck(LoginRequest request)
        {
            return _userMgmtRepository.LoginCheck(request, APIUri.LoginCheck);
        }

        public ProcessResponse EmailAvailableCheck(LoginRequest request)
        {
            ProcessResponse pr = new ProcessResponse();
            var apiResponse = _userMgmtRepository.EmailAvailableCheck(request, APIUri.EmailAwailabiltyCheck);
            if (apiResponse.Succeded)
            {
                pr = apiResponse.Response;
            }
            return pr;
        }

        public ProcessResponse RegisterUser(CustomerSaveRequest request)
        {
            ProcessResponse pr = new ProcessResponse();
            var apiResponse = _userMgmtRepository.RegisterUser(request, APIUri.RegiserUser);
            if (apiResponse.Succeded)
            {
                pr = apiResponse.Response;
            }
            return pr;
        }
    }
}
