using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PerformingValidationsDemo.Models
{
    public class UserDetails : IValidatableObject
    {
        [Required(ErrorMessage = "User Name is Required")]
        [StringLength(15, ErrorMessage = "User Name cannot be more than 15 characters")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Password Required")]
        [StringLength(11, MinimumLength = 5, ErrorMessage = "Mininum Length of Password is 5 letters or Max Length is 11 letters.")]
        [DataType(DataType.Password)]
        public string NewPassword { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm new password")]
        [System.ComponentModel.DataAnnotations.Compare("NewPassword", ErrorMessage = "The new password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = "Date Of Birth is Required")]
        [Display(Name = "Date of Birth")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:d}", ApplyFormatInEditMode = true)]
        public DateTime DateOfBirth { get; set; }

        [Required(ErrorMessage = "Email is Required")]
        [EmailAddress(ErrorMessage = "Please enter valid Email Id")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Postal Code is Required")]
        [Range(100, 1000, ErrorMessage = "Must be between 100 and 1000")]
        public int PostalCode { get; set; }

        [Required(ErrorMessage = "Phone Number is Required")]
        [DataType(DataType.PhoneNumber)]
        [DisplayName("Phone Number")]
        public int PhoneNo { get; set; }

        [Required(ErrorMessage = "Profile is Required")]
        [DataType(DataType.MultilineText)]
        public string Profile { get; set; }

        [FileExtensions(Extensions = "png,jpg,jpeg,gif")]
        public string Photo { get; set; }

        [AllowHtml()]
        [Display(Name = "Additional Comments")]
        public string AdditionalComments { get; set; }

        [CustomValidation(typeof(CityValidator), "IsCityValid")]
        public string City { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            ValidationResult vr = null;

            if (City.ToLower() == "hyderabad" && PostalCode > 500)
                vr = new ValidationResult("Invalid Postal Code for Hyderabad City.");

            return new List<ValidationResult>() { vr };
        }
    }
}