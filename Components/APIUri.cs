using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Components
{
    public static class APIUri
    {
        public static string BaseURI = ConfigurationManager.AppSettings["APIBaseURI"];

        // user management
        public static string LoginCheck = BaseURI + "/api/UserManagementAPI/LoginCheck";
        public static string RegiserUser = BaseURI + "/api/UserManagementAPI/RegisterUser";
        public static string UpdateUser = BaseURI + "/api/UserManagementAPI/UpdateUser";
        public static string DeleteUser = BaseURI + "/api/UserManagementAPI/DeleteUser";
        public static string EmailAwailabiltyCheck = BaseURI + "/api/UserManagementAPI/EmailAvailabilityCheck";

        //categoryies, cities, states, countryies and other masters
        public static string CategoryDropDownHome = BaseURI + "/api/CategoryManagementAPI/GetCategoryHomeDrop";
        public static string SubCategoryDropdown = BaseURI + "/api/CategoryManagementAPI/GetSubcategoriesByCategory";
        public static string ServiceCategories = BaseURI + "/api/CategoryManagementAPI/GetServiceCategories";
        public static string ServiceSubCategories = BaseURI + "/api/CategoryManagementAPI/GetServiceSubCategories";
        public static string OpeningDays = BaseURI + "/api/CategoryManagementAPI/GetOpeningDays";
        public static string AdTypeMaster = BaseURI + "/api/CategoryManagementAPI/AdTypeMaster";
        public static string CountriesList = BaseURI + "/api/CategoryManagementAPI/GetCountries";
        public static string StatesList = BaseURI + "/api/CategoryManagementAPI/GetStates";
        public static string CitiesList = BaseURI + "/api/CategoryManagementAPI/GetCities";
        

        //YP product management
        public static string PostYPAdd = BaseURI + "/api/YPServicesManagementAPI/SaveYPAd";
        public static string GetYPAdById = BaseURI + "/api/YPServicesManagementAPI/GetYPAdById"; // send Id
        public static string GetYpByCategory = BaseURI + "/api/YPServicesManagementAPI/GetYPByCategory"; //send CategoryId
        public static string GetYpBySubCategory = BaseURI + "/api/YPServicesManagementAPI/GetYPBySubCategory"; //send SubCategoryId
        public static string GetYpByCountry = BaseURI + "/api/YPServicesManagementAPI/GetYPByCountry"; //send CountryId




    }
}
