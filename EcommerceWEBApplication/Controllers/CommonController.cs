using BAL.Factory;
using BAL.Interfaces;
using Components.RequestObjects;
using Components.ResponseObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EcommerceWEBApplication.Controllers
{
    public class CommonController : Controller
    {
        private readonly ICategoryManagementService _categoryManagementService;
        // GET: Common
        public CommonController()
        {
            CategoryManagementServiceFactory cmsFactory = new CategoryManagementServiceFactory();
            _categoryManagementService = cmsFactory.GetCategoryManagementService();
        }
        public List<CategoryDropHomeResponse> GetHomeDropdowns()
        {
            List<CategoryDropHomeResponse> myList = new List<CategoryDropHomeResponse>();
            try
            {
                var apiResponse = _categoryManagementService.GetCatHomeDrop();
                if (apiResponse.Succeded)
                {
                    myList = apiResponse.Response;

                }
            }
            catch (Exception ex)
            {

            }
            return myList;
        }
        public List<ServiceCategoriesResponse> GetServiceCategories()
        {
            List<ServiceCategoriesResponse> myList = new List<ServiceCategoriesResponse>();
            try
            {
                int CountryId = 101;
                CountryListRequest clr = new CountryListRequest();
                clr.CountryId = CountryId;
                var apiResponse = _categoryManagementService.GetServicesDrop(clr);
                if (apiResponse.Succeded)
                {
                    myList = apiResponse.Response;

                }
            }
            catch (Exception ex)
            {

            }
            return myList;
        }

        [HttpPost]
        public ActionResult GetStatesByCountry(int id)
        {
            List<USPGetStatesResponse> myList = new List<USPGetStatesResponse>();
            myList = _categoryManagementService.GetStates(id);
            return Json(new { res = myList },JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult GetCitiesByState(int id)
        {
            List<USPCitiesListResponse> myList = new List<USPCitiesListResponse>();
            myList = _categoryManagementService.GetCities(id);
            return Json(new { res = myList }, JsonRequestBehavior.AllowGet);
        }

    }
}