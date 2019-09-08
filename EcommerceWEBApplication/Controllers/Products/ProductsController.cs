using BAL.Interfaces;
using Components.ResponseObjects;
using Components.RequestObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BAL.Factory;

namespace EcommerceWEBApplication.Controllers.Products
{
    public class ProductsController : Controller
    {
        // GET: Products
        private readonly ICategoryManagementService _categoryManagementService;
        public ProductsController()
        {
            CategoryManagementServiceFactory cmsFactory = new CategoryManagementServiceFactory();
            _categoryManagementService = cmsFactory.GetCategoryManagementService();
        }

        public ActionResult ProductList(int CategoryId = 0, string CategoryName="")
        {
            List<CategoryDropHomeResponse> catDropsHome = new List<CategoryDropHomeResponse>();
            if (Session["CatDrop"] != null)
            {
                catDropsHome = (List<CategoryDropHomeResponse>)Session["CatDrop"];
            }
            else
            {
                catDropsHome = new CommonController().GetHomeDropdowns();
                Session["CatDrop"] = catDropsHome;
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
                Session["ServiceDrop"] = serviceDrop;
            }
            ViewBag.ServiceDrop = serviceDrop;

            List<Category> SubCats = new List<Category>();
            SubCategoryListRequest requestSub = new SubCategoryListRequest();
            requestSub.CategoryId = CategoryId;
            var apiResponse = _categoryManagementService.GetSubcategories(requestSub);
            SubCats = apiResponse.Response;


            ViewBag.SubCats = SubCats;
            ViewBag.CategoryId = CategoryId;
            ViewBag.CategoryName = CategoryName;

            return View();
        }

        public ActionResult ProductDetail(int Id = 0)
        {
            List<CategoryDropHomeResponse> catDropsHome = new List<CategoryDropHomeResponse>();
            if (Session["CatDrop"] != null)
            {
                catDropsHome = (List<CategoryDropHomeResponse>)Session["CatDrop"];
            }
            else
            {
                catDropsHome = new CommonController().GetHomeDropdowns();
                Session["CatDrop"] = catDropsHome;

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
                Session["ServiceDrop"] = serviceDrop;
            }
            ViewBag.ServiceDrop = serviceDrop;


            return View();
        }

        public ActionResult PostProduct()
        {
            List<ServiceCategoriesResponse> serviceDrop = new List<ServiceCategoriesResponse>();
            List<CategoryDropHomeResponse> catDropsHome = new List<CategoryDropHomeResponse>();
            if (Session["CatDrop"] != null)
            {
                catDropsHome = (List<CategoryDropHomeResponse>)Session["CatDrop"];
            }
            if (Session["ServiceDrop"] != null)
            {
                serviceDrop = (List<ServiceCategoriesResponse>)Session["ServiceDrop"];
            }
            ViewBag.CatsDrop = catDropsHome;
            ViewBag.ServiceDrop = serviceDrop;

            return View();
        }
        public ActionResult FinalPost()
        {
            List<ServiceCategoriesResponse> serviceDrop = new List<ServiceCategoriesResponse>();
            List<CategoryDropHomeResponse> catDropsHome = new List<CategoryDropHomeResponse>();
            if (Session["CatDrop"] != null)
            {
                catDropsHome = (List<CategoryDropHomeResponse>)Session["CatDrop"];
            }
            if (Session["ServiceDrop"] != null)
            {
                serviceDrop = (List<ServiceCategoriesResponse>)Session["ServiceDrop"];
            }
            ViewBag.CatsDrop = catDropsHome;
            ViewBag.ServiceDrop = serviceDrop;

            return View();
        }

        public ActionResult PostSuccess()
        {
            List<ServiceCategoriesResponse> serviceDrop = new List<ServiceCategoriesResponse>();
            List<CategoryDropHomeResponse> catDropsHome = new List<CategoryDropHomeResponse>();
            if (Session["CatDrop"] != null)
            {
                catDropsHome = (List<CategoryDropHomeResponse>)Session["CatDrop"];
            }
            if (Session["ServiceDrop"] != null)
            {
                serviceDrop = (List<ServiceCategoriesResponse>)Session["ServiceDrop"];
            }
            ViewBag.CatsDrop = catDropsHome;
            ViewBag.ServiceDrop = serviceDrop;

            return View();
        }
    }
}