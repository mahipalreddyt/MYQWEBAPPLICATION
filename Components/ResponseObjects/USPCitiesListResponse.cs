using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Components.ResponseObjects
{
    public class USPCitiesListResponse
    {
        public int CityId { get; set; }
        public string CityName { get; set; }
        public Nullable<int> StateId { get; set; }
        public string Longitude { get; set; }
        public string Latitude { get; set; }
        public string PostalCode { get; set; }

    }
}
