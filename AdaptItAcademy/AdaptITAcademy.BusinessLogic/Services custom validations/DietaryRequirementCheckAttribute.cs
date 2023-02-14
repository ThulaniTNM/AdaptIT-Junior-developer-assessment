using AdaptITAcademy.BusinessLogic.Data_transfer_objects;
using AdaptITAcademyAPI.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdaptITAcademy.BusinessLogic.Custom_validations
{
    public class DietaryRequirementCheckAttribute : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            int dietaryRequirements = (int)value;
            int[] dietaryValues = new int[] { 1, 2, 3, 4 };

            if (!dietaryValues.Contains(dietaryRequirements))
            {
                return new ValidationResult("Dietary value not in range");
            }

            return ValidationResult.Success;
        }
    }
}
