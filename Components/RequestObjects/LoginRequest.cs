using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Components.RequestObjects
{
    public class LoginRequest
    {
        [Required(ErrorMessage = "Email is required")]
        [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "E-mail is not valid")]

        public string emailId { get; set; }

        [Required(ErrorMessage ="Password is required")]
        public string pword { get; set; }

        public string returnUrl { get; set; }
    }
}
