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
        public string PhonenNumer { get; set; }

        [Required(ErrorMessage = "Email required")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Dietary option required")]
        public DietaryRequirements DietaryRequirements { get; set; }

        [Required(ErrorMessage = "Company name required")]
        public string CompanyName { get; set; }
        // user end


        // user physical address start
        [Required(ErrorMessage = "Address name required")]
        public string StreetAddress { get; set; }

        [Required(ErrorMessage = "Suburb required")]
        public string Suburb { get; set; }

        [Required(ErrorMessage = "Province required")]
        public string Province { get; set; }

        [Required(ErrorMessage = "Postal code required")]
        [Range(4, 4, ErrorMessage = "Postal code should be 4 numbers")]
        public int PostalCodePhysicalAddress { get; set; }
        // user physical address end

        // postal address start
        [Required(ErrorMessage = "Area required")]
        public string Area { get; set; }

        [Required(ErrorMessage = "Country required")]
        public string Country { get; set; }

        [Required(ErrorMessage = "Postal code required")]
        [Range(4, 4, ErrorMessage = "Postal code should be 4 numbers")]
        public int PostalCodePostalAddress { get; set; }
        // postal address end.

        [Required(ErrorMessage = "Training id required")]
        public int TrainingId { get; set; }

        [Required(ErrorMessage = "Payment status required")]
        public string PaymentStatus { get; set; }
    }
}
