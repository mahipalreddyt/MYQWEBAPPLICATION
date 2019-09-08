using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Components.RequestObjects
{
    public class ServiceImagesRequest
    {
        public int ImageId { get; set; }

        public string ImageUrl { get; set; }

        public string ImageType { get; set; }

        public bool? IsDeleted { get; set; }

        public int? ServiceAdMasterId { get; set; }
    }
}
