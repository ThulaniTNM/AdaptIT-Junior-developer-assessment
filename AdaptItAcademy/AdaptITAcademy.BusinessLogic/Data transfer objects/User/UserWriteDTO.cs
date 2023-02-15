using AdaptITAcademy.BusinessLogic.Custom_validations;
using AdaptITAcademyAPI.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdaptITAcademy.BusinessLogic.Data_transfer_objects.User
{
    public class UserWriteDTO
    {
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
    }
}
