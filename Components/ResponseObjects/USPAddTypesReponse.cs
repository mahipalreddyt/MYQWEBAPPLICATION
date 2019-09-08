using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Components.ResponseObjects
{
    public class USPAddTypesReponse
    {
        public int AddTypeId { get; set; }
        public string AddTypeName { get; set; }
        public Nullable<bool> IsDeleted { get; set; }
        public Nullable<decimal> Price { get; set; }
        public Nullable<int> ValidFor { get; set; }
        public Nullable<int> countryId { get; set; }
    }
}
