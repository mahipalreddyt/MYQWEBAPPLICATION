using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Components.ResponseObjects
{
    public class USPGetServiceSubCategoryResponse
    {
        public int SubCategoryId { get; set; }
        public string SubCategoryName { get; set; }
        public string SubCategoryCode { get; set; }
        public string SubCategoryImage { get; set; }
        public Nullable<bool> IsDeleted { get; set; }
        public Nullable<int> SequenceNumber { get; set; }
        public Nullable<int> CategoryId { get; set; }

    }
}
