using Components.RequestObjects;
using Components.ResponseObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IUserMgmtRepository
    {
        ApiResponse<LoginResponse> LoginCheck(LoginRequest request, string Uri);
        ApiResponse<ProcessResponse> EmailAvailableCheck(LoginRequest request, string Uri);
        ApiResponse<ProcessResponse> RegisterUser(CustomerSaveRequest request, string Uri);
    }
}
