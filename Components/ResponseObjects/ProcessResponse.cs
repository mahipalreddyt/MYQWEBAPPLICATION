using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Components.ResponseObjects
{
    public class ProcessResponse
    {
        public string Message { get; set; }
        public int StatusCode {get;set;}
        public int CurrentId { get; set; }
    }
}
