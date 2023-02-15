using AdaptITAcademy.BusinessLogic.Custom_validations;
using AdaptITAcademy.BusinessLogic.Data_transfer_objects.Physical_address;
using AdaptITAcademy.BusinessLogic.Data_transfer_objects.Postal_address;
using AdaptITAcademy.BusinessLogic.Data_transfer_objects.User;
using AdaptITAcademyAPI.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdaptITAcademy.BusinessLogic.Data_transfer_objects
{
    public class RegisterDelegateDTO
    {
        // user start
        [Required(ErrorMessage = "First name required")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last name required")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Phone number required")]
        [MaxLength(10, ErrorMessage = "Phone number should be 10 numbers")]
        [RegularExpression(@"0(\d{9}|\d{2} \d{3} \d{4}|\d{2}-\d{3}-\d{4})", ErrorMessage = " Use Eg 071-144-6789 or 067 145 8521 or 0647894563")]
        public string PhonenNumer { get; set; }

        [Required(ErrorMessage = "Email required")]
        // negate all non-alphabet characters at the end of the email.
        [RegularExpression("^[a-zA-Z0-9+\\._-]+@[a-zA-Z]+\\.[a-zA-Z\\.-]+[^()._;*\\[\\]{}+-=|\"'><?&^$#!~%\\\\]$", ErrorMessage = "Incorrect email pattern")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Dietary option required")]
        [DietaryRequirementCheck]
        public DietaryRequirements DietaryRequirements { get; set; }

        [Required(ErrorMessage = "Company name required")]
        public string CompanyName { get; set; }
        // user end

        // physical address start

        [Required(ErrorMessage = "Address name required")]
        public string StreetAddress { get; set; }

        [Required(ErrorMessage = "Suburb required")]
        public string Suburb { get; set; }

        [Required(ErrorMessage = "Province required")]
        public string Province { get; set; }

        [Required(ErrorMessage = "Postal code required")]
        [PostalCodeCheckAttribute]
        public int PostalCodePhysicalAddress { get; set; }
        // physical address end

        // postal address start
        [Required(ErrorMessage = "Area required")]
        public string Area { get; set; }

        [Required(ErrorMessage = "Country required")]
        public string Country { get; set; }

        [Required(ErrorMessage = "Postal code required")]
        [PostalCodeCheckAttribute]
        public int PostalCodePostalAddress { get; set; }
        // postal address end

        [Required(ErrorMessage = "Training id required")]
        public int TrainingId { get; set; }

        [Required(ErrorMessage = "Payment status required")]
        [PaymentStatusCheck]
        public string PaymentStatus { get; set; }
    }
}
