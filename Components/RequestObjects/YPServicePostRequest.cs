using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Web;

namespace Components.RequestObjects
{
    public class YPServicePostRequest
    {
        public int ServiceAdMasterId { get; set; }

        [Required(ErrorMessage ="Title is Mandatory")]
        public string AdTitle { get; set; }

        [Required(ErrorMessage ="Decription is Mandatory")]
        public string AboutTheCompany { get; set; }


        public int? PostedBy { get; set; }

        public DateTime? PostedOn { get; set; }

        public int? AdOwner { get; set; }

        public int? LastmodifiedBy { get; set; }

        public int? LastmodifiedOn { get; set; }

        [Required(ErrorMessage ="Ad type is mandatory")]
        public int? AddTypeId { get; set; }

        [Required(ErrorMessage = "Category is Mandatory")]
        public int? CategoryId { get; set; }
        public string SelectedCategoryName { get; set; }


        [Required(ErrorMessage = "Subcategory is Mandatory")]
        public int? SubcategoryId { get; set; }

        public string SelectedSubCategoryName { get; set; }
        public string CurrentStatus { get; set; }

        public int? PriorityNumber { get; set; }

        public DateTime? EffectiveDateTo { get; set; }

        public bool? IsDeleted { get; set; }

        [Required(ErrorMessage = "City is Mandagory")]
        public int? CityId { get; set; }
        public string OtherCity { get; set; }


        public string Location { get; set; }

        [Required(ErrorMessage = "Contact Number is mandatory")]

        public string ContactNumber { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "E-mail is not valid")]
        public string EmailId { get; set; }


        public bool? IsContactDetailsShown { get; set; }

        public int? ViewCount { get; set; }

        public string PageUrl { get; set; }

        public string ServicesProvided { get; set; }

        public string FoundedYear { get; set; }

        public string NoOfEmployees { get; set; }

        public string WorkingDays { get; set; }

        [Required(ErrorMessage = "Address is mandatory")]
        public string BusinessAddress { get; set; }


        public int? OpeningDayId { get; set; }

        public string FaceBookLink { get; set; }

        public string googlePlusLink { get; set; }

        public string twitterLink { get; set; }

        public string googleMapLink { get; set; }

        public string TSDegreeView { get; set; }

        [Required(ErrorMessage = "Contact Person is mandatory")]
        public string ContactPerson { get; set; }

        public decimal? CurrentRating { get; set; }

        public int[] SpecIdPosted { get; set; }
        public string[] SpecNamePosted { get; set; }

        public List<HttpPostedFileBase> adImages { get; set; }
         

        public HttpPostedFileBase coverPhoto { get; set; }
        public string mainImage { get; set; }

        public int CountryId { get; set; }
        public int StateId { get; set; }

        public string otherImages { get; set; }
    }

    public class YPServicePostRequestFinal
    {
        public int ServiceAdMasterId { get; set; }

        public string AdTitle { get; set; }

        public string AboutTheCompany { get; set; }

        public int? PostedBy { get; set; }

        public DateTime? PostedOn { get; set; }

        public int? AdOwner { get; set; }

        public int? LastmodifiedBy { get; set; }

        public int? LastmodifiedOn { get; set; }

        public int? AddTypeId { get; set; }

        public int? CategoryId { get; set; }

        public int? SubcategoryId { get; set; }

        public string CurrentStatus { get; set; }

        public int? PriorityNumber { get; set; }

        public DateTime? EffectiveDateTo { get; set; }

        public bool? IsDeleted { get; set; }

        public int? CityId { get; set; }
        public string OtherCity { get; set; }

        public string Location { get; set; }

        public string ContactNumber { get; set; }

        public string EmailId { get; set; }

        public bool? IsContactDetailsShown { get; set; }

        public int? ViewCount { get; set; }

        public string PageUrl { get; set; }

        public string ServicesProvided { get; set; }

        public string FoundedYear { get; set; }

        public string NoOfEmployees { get; set; }

        public string WorkingDays { get; set; }

        public string BusinessAddress { get; set; }

        public int? OpeningDayId { get; set; }

        public string FaceBookLink { get; set; }

        public string googlePlusLink { get; set; }

        public string twitterLink { get; set; }

        public string googleMapLink { get; set; }

        public string TSDegreeView { get; set; }

        public string ContactPerson { get; set; }

        public decimal? CurrentRating { get; set; }

        public string otherImages { get; set; }

        public string mainImage { get; set; }
        public int CountryId { get; set; }
        public int StateId { get; set; }
    }
}
