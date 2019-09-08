using BAL.Factory;
using BAL.Interfaces;
using Components.RequestObjects;
using Components.ResponseObjects;
using EcommerceWEBApplication.Filters; 
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;
using EcommerceWEBApplication.Models.Entity;
using Components;

namespace EcommerceWEBApplication.Controllers.Services
{
    public class ServicesController : Controller
    {
        // GET: Services
        private readonly ICategoryManagementService _categoryManagementService;
        private readonly IYPAdmanagementService _ypAdmgmtService;
        MyQShopsEntities context = new MyQShopsEntities();
        public ServicesController()
        {
            CategoryManagementServiceFactory cmsFactory = new CategoryManagementServiceFactory();
            _categoryManagementService = cmsFactory.GetCategoryManagementService();

            YPAdmanagementServiceFactory ypFactory = new YPAdmanagementServiceFactory();
            _ypAdmgmtService = ypFactory.GetYPAdmanagementService();
            context.Configuration.ProxyCreationEnabled = false;
        }

        public ActionResult ServiceList(int CategoryId =0, string CategoryName = "", 
            int SubCategoryId=0, string SubCategoryName="", int source = 0, int pagenumber = 1)            
        {
            string currentCurrency = Session["currentCurrency"] != null ? Session["currentCurrency"].ToString() : "Rs. ";
            int currentCountry = Session["currentyCountry"] != null ? Convert.ToInt32(Session["currentCountry"].ToString()) : 101;

            int currentPage = pagenumber;
            int fromRecords = (pagenumber - 1) * 10;
            int toRecords = fromRecords + 10;
            int totalRecords = 0;

            List<USPGetYPAdsByCountryResponse> finalResult =  new List<USPGetYPAdsByCountryResponse>();

            if (SubCategoryId > 0)
            {
               totalRecords =  context.Usp_GetYPAdsBySubCategory(SubCategoryId).ToList().Count();
                List<Usp_GetYPAdsBySubCategory_Result> tempList = context.Usp_GetYPAdsBySubCategory(SubCategoryId).Take(30).ToList();
                CloneObjects.CopyPropertiesTo(tempList, finalResult);
            }
            else
            {
                totalRecords = context.Usp_GetYPAdsByCategory(CategoryId).ToList().Count();
                List<Usp_GetYPAdsByCategory_Result> tempList = new List<Usp_GetYPAdsByCategory_Result>();
                tempList = context.Usp_GetYPAdsByCategory(CategoryId).Take(30).ToList();
                CloneObjects.CopyPropertiesTo(tempList, finalResult);
            }
            
            

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

            List<ServiceSubCategory> SubCats = new List<ServiceSubCategory>();
            SubCategoryListRequest slrs = new SubCategoryListRequest();
            slrs.CategoryId = CategoryId;
            var apiResponse = _categoryManagementService.GetServicesSubCategories(slrs);
            SubCats = apiResponse.Response;

            ViewBag.SubCats = SubCats;
            ViewBag.CategoryId = CategoryId;
            ViewBag.CategoryName = CategoryName;
            ViewBag.SubCategoryName = SubCategoryName;
            ViewBag.SubCategoryId = SubCategoryId;
            ViewBag.currentCurrency = currentCurrency;
            ViewBag.TotalRecords = totalRecords;
            ViewBag.CurrentPageNumber = pagenumber;
            return View(finalResult);
        }

        public ActionResult ServiceDetail(int Id = 0)
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

        public ActionResult PostService()
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
            int currentUserId = Session["currentUserId"] != null ? Convert.ToInt32(Session["currentUserId"]) : 0;
            if (currentUserId == 0)
            {
                return RedirectToAction("Login", "Authenticate", new { returnUrl = "/Services/PostService" });
            }

            return View();
        }

        [UserAuthenticationFilter]
        [HttpGet]
        public ActionResult FinalPost(int CategoryIdPost = 0, int SubCategoryIdPost=0, 
            string SelectedSubCategoryName="", string SelectedCategoryName = "")
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


            List<USPGetOpeningDaysResponse> openingDays = new List<USPGetOpeningDaysResponse>();
            var odResponse = _categoryManagementService.GetOpeningDays();
            List<USPAddTypesReponse> adTypes = new List<USPAddTypesReponse>();
            var adResponse = _categoryManagementService.GetAddTypes();


            adTypes = adResponse.Response;
            openingDays = odResponse.Response;

            int selectedAdTypeId = 0;
            int selectedOpeningDayId = 0;
            ViewBag.OpeningDayId = new SelectList(openingDays, "OpeningId", "DayTime", selectedOpeningDayId.ToString());
            ViewBag.AddTypeId = new SelectList(adTypes, "AddTypeId", "AddTypeName", selectedAdTypeId.ToString());
            ViewBag.SubcategoryName = SelectedSubCategoryName;
            ViewBag.SelectedSubCategoryName = SelectedSubCategoryName;
            ViewBag.SelectedCategoryName = SelectedCategoryName;
            ViewBag.SubcategoryId = SubCategoryIdPost;
            ViewBag.CategoryId = CategoryIdPost;
            ViewBag.CategoryName = SelectedCategoryName; 
            ViewBag.CountryIdSelected = 0;
            ViewBag.StateIdSelected = 0;
            ViewBag.CityIdSelected = 0;

            List<USPGetCountriesListResponse> Countries = new List<USPGetCountriesListResponse>();
            Countries = _categoryManagementService.GetCountries();
            ViewBag.CountryId = new SelectList(Countries,"CountryId","CountryName","0");




            return View();
        }

        [UserAuthenticationFilter]
        [HttpPost]
        public ActionResult FinalPost(YPServicePostRequest ypr)
        {
            if (!string.IsNullOrEmpty(ypr.OtherCity))
            {
                ModelState.Remove("CityId");
            }
            if (ModelState.IsValid)
            {
                bool res = SavePost(ypr);
                return RedirectToAction("PostSuccess");
            }
            else
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
                List<USPGetOpeningDaysResponse> openingDays = new List<USPGetOpeningDaysResponse>();
                var odResponse = _categoryManagementService.GetOpeningDays();
                List<USPAddTypesReponse> adTypes = new List<USPAddTypesReponse>();
                var adResponse = _categoryManagementService.GetAddTypes();
                adTypes = adResponse.Response;
                openingDays = odResponse.Response;

                ViewBag.OpeningDayId = new SelectList(openingDays, "OpeningId", "DayTime", ypr.OpeningDayId.ToString());
                ViewBag.AddTypeId = new SelectList(adTypes, "AddTypeId", "AddTypeName", ypr.AddTypeId.ToString());
                ViewBag.SelectedSubCategoryName = ypr.SelectedSubCategoryName;
                ViewBag.SelectedCategoryName = ypr.SelectedCategoryName;
                ViewBag.SubcategoryName = ypr.SelectedSubCategoryName;
                ViewBag.CategoryName = ypr.SelectedCategoryName;
                ViewBag.CategoryId = ypr.CategoryId;
                ViewBag.SubcategoryId = ypr.SubcategoryId;
                ViewBag.CountryIdSelected = ypr.CountryId;
                ViewBag.StateIdSelected = ypr.StateId;
                ViewBag.CityIdSelected = ypr.CityId;
                ViewBag.CountryIdSelected = ypr.CountryId ;
                ViewBag.StateIdSelected = ypr.StateId;
                ViewBag.CityIdSelected = ypr.CityId;

                List<USPGetCountriesListResponse> Countries = new List<USPGetCountriesListResponse>();
                Countries = _categoryManagementService.GetCountries();
                ViewBag.CountryId = new SelectList(Countries, "CountryId", "CountryName", ypr.CountryId.ToString());

            }



            return View();
        }

        [UserAuthenticationFilter]
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

        public ActionResult GetSucategories(int id)
        {
            List<ServiceSubCategory> subCats = new List<ServiceSubCategory>();
            SubCategoryListRequest sr = new SubCategoryListRequest();
            sr.CategoryId = id;
            var apiResponse = _categoryManagementService.GetServicesSubCategories(sr);
            subCats = apiResponse.Response;
            return PartialView("_SubcatsViewPost", subCats);

        }
        public bool SavePost(YPServicePostRequest ypr)
        {
            bool res = false;
            try
            {
                string myOtherList = string.Empty;
               
                // check for the image
                int mainImgCount = 1;
                if (ypr.coverPhoto != null)
                {
                    if (ypr.coverPhoto.ContentLength > 0)
                    {
                        string filename = string.Empty;
                        HttpPostedFileBase myFile = ypr.coverPhoto;
                        filename = DateTime.Now.ToString();
                        string pathToSave = Server.MapPath("~/UploadedImages");
                        filename = Regex.Replace(filename, @"[\[\]\\\^\$\.\|\?\*\+\(\)\{\}%,;: ><!@#&\-\+\/]", "");
                        string extention = Path.GetExtension(myFile.FileName);
                        filename = "Main" + ypr.CategoryId.ToString() + ypr.SubcategoryId.ToString() + filename + mainImgCount.ToString() + extention;
                        myFile.SaveAs(Path.Combine(pathToSave, filename));
                        ypr.mainImage = filename;

                    }
                }
                int otherImgCount = 1;
                if (ypr.adImages != null)
                {
                    foreach (HttpPostedFileBase upload in ypr.adImages)
                    {
                        if(upload!=null)
                        {
                            if (upload.ContentLength > 0)
                            {
                                string filename = string.Empty;
                                HttpPostedFileBase myFile = upload;
                                filename = DateTime.Now.ToString();
                                string pathToSave = Server.MapPath("~/UploadedImages");
                                filename = Regex.Replace(filename, @"[\[\]\\\^\$\.\|\?\*\+\(\)\{\}%,;: ><!@#&\-\+\/]", "");
                                string extention = Path.GetExtension(myFile.FileName);
                                filename = "Others" + ypr.CategoryId.ToString() + ypr.SubcategoryId.ToString() + filename + otherImgCount.ToString() + extention;
                                myFile.SaveAs(Path.Combine(pathToSave, filename));

                                if (otherImgCount == 1)
                                {
                                    myOtherList = filename;
                                }
                                else
                                {
                                    myOtherList += "," + filename;
                                }
                                
                                otherImgCount++;

                            }

                        }
                    }
                    
                }
                ypr.otherImages = myOtherList;
                ypr.CurrentRating = 0;
                ypr.CurrentStatus = "Active";
                ypr.EffectiveDateTo = DateTime.Now.AddMonths(3);
                ypr.IsContactDetailsShown = true;
                ypr.IsDeleted = false;
                ypr.LastmodifiedBy = (Session["currentUserId"] != null) ? Convert.ToInt32(Session["currentUserId"].ToString()) : 1;
                
                ypr.PostedBy = ypr.LastmodifiedBy;
                ypr.PostedOn = DateTime.Now;
                ypr.PriorityNumber = 100;

                ProcessResponse pr = new ProcessResponse();
                pr = _ypAdmgmtService.SaveServiceAd(ypr);
                

            }
            catch (Exception ex)
            {
                res = false;
            }
            
            


            return res;
        }
    }
}