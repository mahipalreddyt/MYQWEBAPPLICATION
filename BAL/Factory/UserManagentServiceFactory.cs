using BAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Repositories;
using DAL.Interfaces;
using BAL.Services;

namespace BAL.Factory
{
    public class UserManagentServiceFactory : IUserManagentServiceFactory, IDisposable
    {
        public readonly IUserMgmtRepository userMgmtRepository;

        public UserManagentServiceFactory()
        {
            userMgmtRepository = new UserMgmtRepository();
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public IUserManagentService GetUserManagmentService()
        {
            return new UserManagentService(userMgmtRepository);
        }
    }
}
