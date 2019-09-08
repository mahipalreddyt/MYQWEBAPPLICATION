using Components.RequestObjects;
using Components.ResponseObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface ICategoryManagementRepository
    {
        ApiResponse<List<CategoryDropHomeResponse>> GetCategoryDropHome(string Uri);
        ApiResponse<List<ServiceCategoriesResponse>> GetServiceCategories(CountryListRequest cl, string Uri);
        ApiResponse<List<ServiceSubCategory>> GetServiceSubByCatId(SubCategoryListRequest req, string Uri);
        ApiResponse<List<USPAddTypesReponse>> GetAddTypes(string Uri);
        ApiResponse<List<USPGetOpeningDaysResponse>> GetOpeningDays(string Uri);
        ApiResponse<List<USPCitiesListResponse>> GetcitiesList(string Uri);
        ApiResponse<List<USPGetCountriesListResponse>> GetCountries(string Uri);
        ApiResponse<List<USPGetStatesResponse>> GetStates(string Uri);
        ApiResponse<List<Category>> GetSubCategories(SubCategoryListRequest request, string Uri);
    }
}
