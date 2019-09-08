using BAL.Interfaces;
using BAL.Services;
using DAL.Interfaces;
using DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAL.Factory
{
    public class YPAdmanagementServiceFactory  : IDisposable, IYPAdmanagementServiceFactory
    {
        public  readonly IYPAdManagementRepository iYPAdManagementRepository;
        public YPAdmanagementServiceFactory()
        {
            iYPAdManagementRepository = new YPAdManagementRepository();

        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public IYPAdmanagementService GetYPAdmanagementService()
        {
            return new YPAdmanagementService(iYPAdManagementRepository);
        }
    }
}
