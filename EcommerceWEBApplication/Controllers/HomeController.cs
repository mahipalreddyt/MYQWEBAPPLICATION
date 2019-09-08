using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BAL.Factory;
using BAL.Interfaces;
using Components.ResponseObjects;

namespace EcommerceWEBApplication.Controllers
{
    public class HomeController : Controller
    {

        private readonly ICategoryManagementService _categoryManagementService;

        public HomeController()
        {
            CategoryManagementServiceFactory cmsFactory = new CategoryManagementServiceFactory();
            _categoryManagementService = cmsFactory.GetCategoryManagementService();
        }
        public ActionResult Index()
        {
            List<CategoryDropHomeResponse> catDropsHome = new List<CategoryDropHomeResponse>();
            if (Session["CatDrop"] != null)
            {
                catDropsHome = (List<CategoryDropHomeResponse>)Session["CatDrop"];
            }
            else
            {
                catDropsHome = new CommonController().GetHomeDropdowns();
                if(catDropsHome.Count > 0) Session["CatDrop"] = catDropsHome;
            }
            ViewBag.CatsDrop = catDropsHome;
            List<ServiceCategoriesResponse> serviceDrop = new List<ServiceCategoriesResponse>();
            if (Session["ServiceDrop"] != null)
            {
                serviceDrop = (List<ServiceCategoriesResponse>)Session["ServiceDrop"];
            }
            else
            {
                serviceDrop = new CommonController().GetServiceCategories();
                if(serviceDrop.Count>0) Session["ServiceDrop"] = serviceDrop;
            }
            ViewBag.ServiceDrop = serviceDrop;

            return View();
        }

        
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
         
        

    }
}