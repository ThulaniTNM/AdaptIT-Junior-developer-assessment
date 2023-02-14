using AdaptITAcademy.BusinessLogic.Data_transfer_objects;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdaptITAcademy.BusinessLogic.Custom_validations
{
    public class PostalCodeCheckAttribute : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            int postalCode = (int)value;

            if (postalCode.ToString().Length !=4)
            {
                return new ValidationResult("Postal address should be four numbers");
            }

            return ValidationResult.Success;
        }
    }
}
