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
    public class CategoryManagementRepository : ICategoryManagementRepository
    {
        EcommerceProxy _ecommerceProxy;
        public CategoryManagementRepository()
        {
            _ecommerceProxy = new EcommerceProxy();
        }

        public ApiResponse<List<CategoryDropHomeResponse>> GetCategoryDropHome(string Uri)
        {
            //return _ecommerceProxy.GetApi<CategoryDropHomeResponse, Uri>;
            return _ecommerceProxy.GetApi<List<CategoryDropHomeResponse>>(Uri);
        }
        public ApiResponse<List<ServiceCategoriesResponse>> GetServiceCategories(CountryListRequest cl, string Uri)
        {            
            return _ecommerceProxy.PostApi<CountryListRequest, List<ServiceCategoriesResponse>>(cl,Uri, "Post");
        }

        public ApiResponse<List<ServiceSubCategory>> GetServiceSubByCatId(SubCategoryListRequest req, string Uri)
        {
            return _ecommerceProxy.PostApi<SubCategoryListRequest, List<ServiceSubCategory>>(req, Uri, "Post");
        }

        public ApiResponse<List<Category>> GetSubCategories(SubCategoryListRequest request, string Uri)
        {
            return _ecommerceProxy.PostApi<SubCategoryListRequest, List<Category>>(request, Uri, "Post");
        }

        public ApiResponse<List<USPAddTypesReponse>> GetAddTypes(string Uri)
        {
            return _ecommerceProxy.GetApi<List<USPAddTypesReponse>>(Uri);
        }

        public ApiResponse<List<USPGetOpeningDaysResponse>> GetOpeningDays(string Uri)
        {
            return _ecommerceProxy.GetApi<List<USPGetOpeningDaysResponse>>(Uri);
        }

        public ApiResponse<List<USPCitiesListResponse>> GetcitiesList(string Uri)
        {
            return _ecommerceProxy.GetApi<List<USPCitiesListResponse>>(Uri);
        }

        public ApiResponse<List<USPGetCountriesListResponse>> GetCountries(string Uri)
        {
            return _ecommerceProxy.GetApi<List<USPGetCountriesListResponse>>(Uri);
        }

        public ApiResponse<List<USPGetStatesResponse>> GetStates(string Uri)
        {
            return _ecommerceProxy.GetApi<List<USPGetStatesResponse>>(Uri);
        }

    }

}
