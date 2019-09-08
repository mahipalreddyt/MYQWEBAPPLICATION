using BAL.Factory;
using BAL.Interfaces;
using Components.ResponseObjects;
using EcommerceWEBApplication.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EcommerceWEBApplication.Controllers.Customer
{
    [UserAuthenticationFilter]
    public class CustomerController : Controller
    {
        // GET: CustomerDashboard
        private readonly ICategoryManagementService _categoryManagementService;

        public CustomerController()
        {
            CategoryManagementServiceFactory cmsFactory = new CategoryManagementServiceFactory();
            _categoryManagementService = cmsFactory.GetCategoryManagementService();
        }
        public ActionResult Dashboard()
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

        public ActionResult MyAds()
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

        public ActionResult ArchivedAds()
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

        public ActionResult PendingApproval()
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

        public ActionResult CloseAccount()
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