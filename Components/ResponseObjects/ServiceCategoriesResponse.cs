using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Components.ResponseObjects
{
    public class ServiceCategoriesResponse
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string CategoryCode { get; set; }
        public string CategoryImage { get; set; }
        public bool IsDeleted { get; set; }
        public int SequenceNumber { get; set; }
        public int CountryId { get; set; }

    }
}
