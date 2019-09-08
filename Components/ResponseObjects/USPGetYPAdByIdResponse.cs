using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Components.ResponseObjects
{
    public class USPGetYPAdByIdResponse
    {
        public string AboutTheCompany { get; set; }
        public Nullable<int> AddTypeId { get; set; }
        public Nullable<int> AdOwner { get; set; }
        public string AdTitle { get; set; }
        public string BusinessAddress { get; set; }
        public Nullable<int> CategoryId { get; set; }
        public Nullable<int> CityId { get; set; }
        public string ContactNumber { get; set; }
        public string ContactPerson { get; set; }
        public Nullable<decimal> CurrentRating { get; set; }
        public string CurrentStatus { get; set; }
        public Nullable<System.DateTime> EffectiveDateTo { get; set; }
        public string EmailId { get; set; }
        public string FaceBookLink { get; set; }
        public string FoundedYear { get; set; }
        public string googleMapLink { get; set; }
        public string googlePlusLink { get; set; }
        public Nullable<bool> IsContactDetailsShown { get; set; }
        public Nullable<bool> IsContactDetailsShown1 { get; set; }
        public Nullable<bool> IsDeleted { get; set; }
        public string Location { get; set; }
        public string NoOfEmployees { get; set; }
        public Nullable<int> OpeningDayId { get; set; }
        public Nullable<int> PostedBy { get; set; }
        public Nullable<System.DateTime> PostedOn { get; set; }
        public Nullable<int> PriorityNumber { get; set; }
        public int ServiceAdMasterId { get; set; }
        public string ServicesProvided { get; set; }
        public Nullable<int> SubcategoryId { get; set; }
        public string TSDegreeView { get; set; }
        public string twitterLink { get; set; }
        public Nullable<int> ViewCount { get; set; }
        public string WorkingDays { get; set; }
        public string AdOwner_Name { get; set; }
        public string PostedBy_Name { get; set; }
        public string AddTypeId_Name { get; set; }
        public string OpeningDayId_Name { get; set; }
        public string CategoryName { get; set; }
        public string SubCategoryName { get; set; }
        public string CityName { get; set; }
        public string StateName { get; set; }
    }
}
