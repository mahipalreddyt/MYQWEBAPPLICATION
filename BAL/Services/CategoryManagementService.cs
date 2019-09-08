using BAL.Interfaces;
using Components;
using Components.RequestObjects;
using Components.ResponseObjects;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAL.Services
{
    public class CategoryManagementService  : ICategoryManagementService
    {
        private readonly ICategoryManagementRepository _categoryManagmentRepository;
        public CategoryManagementService(ICategoryManagementRepository repo)
        {
            _categoryManagmentRepository = repo;
        }
        public ApiResponse<List<CategoryDropHomeResponse>> GetCatHomeDrop()
        {
            return _categoryManagmentRepository.GetCategoryDropHome(APIUri.CategoryDropDownHome);
        }

        public ApiResponse<List<ServiceCategoriesResponse>> GetServicesDrop(CountryListRequest clr)
        {

            
            return _categoryManagmentRepository.GetServiceCategories(clr, APIUri.ServiceCategories);
        }

        public ApiResponse<List<Category>> GetSubcategories(SubCategoryListRequest request)
        {


            return _categoryManagmentRepository.GetSubCategories(request, APIUri.SubCategoryDropdown);
        }

        public ApiResponse<List<ServiceSubCategory>> GetServicesSubCategories(SubCategoryListRequest request)
        {
            return _categoryManagmentRepository.GetServiceSubByCatId(request,APIUri.ServiceSubCategories);
        }

        public List<USPGetCountriesListResponse> GetCountries()
        {
            List<USPGetCountriesListResponse> myList = new List<USPGetCountriesListResponse>();
            var apiResponse = _categoryManagmentRepository.GetCountries(APIUri.CountriesList);
            if (apiResponse.Succeded)
            {
                myList = apiResponse.Response;

            }
            return myList;
        }
        public List<USPGetStatesResponse> GetStates(int CountryId)
        {
            List<USPGetStatesResponse> myList = new List<USPGetStatesResponse>();
            var apiResponse = _categoryManagmentRepository.GetStates(APIUri.StatesList + "?CountryId=" + CountryId);
            if (apiResponse.Succeded)
            {
                myList = apiResponse.Response;
            }
            return myList;
        }
        public List<USPCitiesListResponse> GetCities(int StateId)
        {
            List<USPCitiesListResponse> myList = new List<USPCitiesListResponse>();
            var apiResponse =  _categoryManagmentRepository.GetcitiesList(APIUri.CitiesList + "?StateId=" + StateId);
            if (apiResponse.Succeded)
            {
                myList = apiResponse.Response;
            }
            return myList;
        }
        public ApiResponse<List<USPGetOpeningDaysResponse>> GetOpeningDays()
        {
            return _categoryManagmentRepository.GetOpeningDays(APIUri.OpeningDays);
        }
        public ApiResponse<List<USPAddTypesReponse>> GetAddTypes()
        {
            return _categoryManagmentRepository.GetAddTypes(APIUri.AdTypeMaster);
        }
    }
}
