using Components.ResponseObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EcommerceWEBApplication.Controllers
{
    public class PostProductController : Controller
    {
        // GET: PostProduct
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult SelectType()
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

        public ActionResult SetPostRoute(string Type)
        {
            if (string.IsNullOrEmpty(Type))
            {
                return RedirectToAction("SelectType");
            }
            if (Type == "YP")
            {
                return RedirectToAction("PostService", "Services");
            }
            else if (Type == "CL")
            {
                return RedirectToAction("PostProduct", "Products");
            }
            else {
                return RedirectToAction("SelectType");
            }
        }

    }
}