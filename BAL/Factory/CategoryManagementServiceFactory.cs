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
    public class CategoryManagementServiceFactory : ICategoryManagementServiceFactory, IDisposable
    {
        public readonly ICategoryManagementRepository categoryManagementRepository;

        public CategoryManagementServiceFactory()
        {
            categoryManagementRepository = new CategoryManagementRepository();
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public ICategoryManagementService GetCategoryManagementService()
        {
            return new CategoryManagementService(categoryManagementRepository);
        }

    }
}
