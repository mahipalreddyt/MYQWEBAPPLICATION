using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Components.ResponseObjects
{
    public class USPGetCountriesListResponse
    {
        public int CountryId { get; set; }
        public string CountryName { get; set; }
        public Nullable<bool> IsActive { get; set; }
        public string CountryCode { get; set; }
        public string PhoneCode { get; set; }
        public string CurrencyCode { get; set; }
        public string CurrencyNumber { get; set; }
        public string CurrencyHtmlcode { get; set; }
    }
}
