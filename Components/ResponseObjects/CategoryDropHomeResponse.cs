using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Components.ResponseObjects
{
    public class CategoryDropHomeResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string CategoryImage { get; set; }
        public int TotalPosted { get; set; }
    }
}
