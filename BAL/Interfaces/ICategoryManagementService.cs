using Components.RequestObjects;
using Components.ResponseObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAL.Interfaces
{
    public interface ICategoryManagementService
    {
        ApiResponse<List<CategoryDropHomeResponse>> GetCatHomeDrop();
        ApiResponse<List<ServiceCategoriesResponse>> GetServicesDrop(CountryListRequest clr);
        ApiResponse<List<ServiceSubCategory>> GetServicesSubCategories(SubCategoryListRequest request);
        List<USPGetCountriesListResponse> GetCountries();
        List<USPGetStatesResponse> GetStates(int CountryId);
        List<USPCitiesListResponse> GetCities(int StateId);
        ApiResponse<List<USPGetOpeningDaysResponse>> GetOpeningDays();
        ApiResponse<List<USPAddTypesReponse>> GetAddTypes();
        ApiResponse<List<Category>> GetSubcategories(SubCategoryListRequest request);
    }
}
