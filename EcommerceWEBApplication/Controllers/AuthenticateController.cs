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
    public class AuthenticateController : Controller
    {
        private readonly IUserManagentService _userManagementService;
        private readonly ICategoryManagementService _categoryManagementService;
        public AuthenticateController()
        {
            UserManagentServiceFactory usFactory = new UserManagentServiceFactory();
            _userManagementService = usFactory.GetUserManagmentService();
            CategoryManagementServiceFactory catFactory = new CategoryManagementServiceFactory();
            _categoryManagementService = catFactory.GetCategoryManagementService();
        }

        public ActionResult Login(string returnUrl="")
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

            ViewBag.ErrorMessage = "";
            ViewBag.returnUrl = returnUrl;
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginRequest request)
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

            LoginResponse result = new LoginResponse();

            

            if (ModelState.IsValid)
            {
                try
                {
                    var apiResponse = _userManagementService.LoginCheck(request);
                    if (apiResponse.Succeded)
                    {
                        result = apiResponse.Response;
                        if (result.SuccessCode == 1)
                        {
                        
                            Session["currentUserId"] = result.Id;
                            Session["CurrentUserName"] = result.Username;
                            Session["CustomerType"] = result.CustomerType;
                            if (!string.IsNullOrEmpty(request.returnUrl))
                            {
                                return Redirect(request.returnUrl);
                            }
                            else {
                                return Redirect("/Home/Index");
                            }
                            
                        }
                        else
                        {
                            ViewBag.ErrorMessage = result.Message;
                            return View(request);
                        }
                    }
                    else {
                        //send error message to view;
                        ViewBag.ErrorMessage = "Unable to login now, please try again";
                        return View(request);
                    }

                }
                catch (Exception ex)
                {

                }
            }
            ViewBag.ErrorMessage = "";
            return View(request);

        }

        public ActionResult Register()
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
            ViewBag.ErrorMessage = "";
            List<USPGetCountriesListResponse> Countries = new List<USPGetCountriesListResponse>();
            Countries = _categoryManagementService.GetCountries();
            ViewBag.CountryId= Countries;
            return View();
        }


        [HttpPost]
        public ActionResult Register(CustomerSaveRequest request)
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
            ViewBag.ErrorMessage = "";
            List<USPGetCountriesListResponse> Countries = new List<USPGetCountriesListResponse>();
            Countries = _categoryManagementService.GetCountries();
            ViewBag.CountryId = Countries;
            
            int? CountryIdSelected = 0;
            int? StateIdSelected = 0;
            string CityIdSelected = string.Empty;
            if (request.CountryId > 0) CountryIdSelected = request.CountryId;
            if (request.StateProvinceId > 0) StateIdSelected = request.StateProvinceId;
            if (!string.IsNullOrEmpty(request.City)) CityIdSelected = request.City;

            if (ModelState.IsValid)
            {
                
                //check for emailavalable
                ProcessResponse ps = new ProcessResponse();
                LoginRequest lr = new LoginRequest();
                lr.emailId = request.Email;
                ps = _userManagementService.EmailAvailableCheck(lr);
                if (ps.StatusCode == 0)
                {
                    ModelState.AddModelError("Email", "Emailid not avaialble");
                }
            }
            if (ModelState.IsValid)
            {

                ProcessResponse pr = new ProcessResponse();
                pr = _userManagementService.RegisterUser(request);
                if (pr.CurrentId > 0)
                {
                    return RedirectToAction("RegistrationSuccess", new { UserType = request.CustomerType, Id = pr.CurrentId });
                }
                else
                {
                    ViewBag.ErrorMessage = "Unable to register now, please try later : " + pr.Message;
                    return View(request);
                }



                
            }



            return View(request);
        }


        public ActionResult RegistrationSuccess(string UserType, int Id)
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

            List<USPGetCountriesListResponse> Countries = new List<USPGetCountriesListResponse>();
            Countries = _categoryManagementService.GetCountries();
            ViewBag.CountryId = Countries;
            return View();
        }

        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("Index", "Home");
        }
    
    }
}