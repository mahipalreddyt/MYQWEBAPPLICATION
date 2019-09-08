using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


namespace Components.RequestObjects
{
    public class CustomerSaveRequest
    {
        public int Id { get; set; }

        public string Username { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "E-mail is not valid")]
         
        public string Email { get; set; }


        public string EmailToRevalidate { get; set; }

        public string AdminComment { get; set; }

        public bool IsTaxExempt { get; set; }

        public int AffiliateId { get; set; }

        public int VendorId { get; set; }

        public bool HasShoppingCartItems { get; set; }

        public bool RequireReLogin { get; set; }

        public int FailedLoginAttempts { get; set; }

        public DateTime? CannotLoginUntilDateUtc { get; set; }

        public bool Active { get; set; }

        public bool Deleted { get; set; }

        public bool IsSystemAccount { get; set; }

        public string SystemName { get; set; }

        public string LastIpAddress { get; set; }

        public DateTime CreatedOnUtc { get; set; }

        public DateTime? LastLoginDateUtc { get; set; }

        public DateTime LastActivityDateUtc { get; set; }

        public int RegisteredInStoreId { get; set; }

        public int? BillingAddress_Id { get; set; }

        public int? ShippingAddress_Id { get; set; }

        [Required(ErrorMessage = "Customer type is Mandatory")]
        public string CustomerType { get; set; }

        // address table

        [Required(ErrorMessage = "Firstname is mandatory")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Lastname is mandatory")]
        public string LastName { get; set; }

        public string Company { get; set; }

        public int? CountryId { get; set; }

        public int? StateProvinceId { get; set; }

        public string County { get; set; }

        [Required(ErrorMessage = "City is Mandatory")]
        public string City { get; set; }

        [Required(ErrorMessage = "HNo, Street is mandatory")]
        public string Address1 { get; set; }


        public string Address2 { get; set; }

        [Required(ErrorMessage = "Postal Code is mandatory")]
        public string ZipPostalCode { get; set; }

        [Required(ErrorMessage = "Phone number is mandatory")]
        public string PhoneNumber { get; set; }

        public string FaxNumber { get; set; }

        public string CustomAttributes { get; set; }

        // pw
        [Required(ErrorMessage = "Password is mandatory")]
        [DataType(DataType.Password)]
        public string password { get; set; }

        [Required(ErrorMessage = "Confirm Password is mandatory")]
        [Compare("password",ErrorMessage ="Password are not identical")]
        [DataType(DataType.Password)]
        public string cnfpassword { get; set; }
    }
}
