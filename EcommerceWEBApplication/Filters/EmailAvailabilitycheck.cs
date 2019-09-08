using BAL.Factory;
using BAL.Interfaces;
using Components.RequestObjects;
using Components.ResponseObjects;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EcommerceWEBApplication.Filters
{
    public class EmailAvailabilitycheck : ValidationAttribute
    {
        private readonly IUserManagentService _userManagementService;

        public EmailAvailabilitycheck()
        {
            UserManagentServiceFactory usFactory = new UserManagentServiceFactory();
            _userManagementService = usFactory.GetUserManagmentService();
        }
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            string Message = string.Empty;
            string email = (string)value;
            LoginRequest request = new LoginRequest();
            ProcessResponse ps = _userManagementService.EmailAvailableCheck(request);
            if (ps.StatusCode == 0)
            {
                Message = "Emailid not available";
                return new ValidationResult(Message);
            }
            else
            {
                return ValidationResult.Success;
            }
        }
    }
}
